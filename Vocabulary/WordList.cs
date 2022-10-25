namespace Vocabulary
{
    public class WordList
    {
        private const char SeparatorChar = ';';

        private static readonly DirectoryInfo DataPath = new(Path
            .Combine(Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vocabulary"));

        private readonly List<Word> _words = new();

        public string Name { get; }
        public string[] Languages { get; }
        public int Count => _words.Count;

        public WordList(string name, params string[] languages)
        {
            Name = name.ToLower();

            Languages = languages
                .Select(language => language.ToLower())
                .ToArray();
        }

        public static string[] GetLists()
        {
            if (!DataPath.Exists) return Array.Empty<string>();
            
            string[] lists = DataPath
                .EnumerateFiles("*.dat", SearchOption.TopDirectoryOnly)
                .Select(file => Path.GetFileNameWithoutExtension(file.FullName))
                .ToArray();

            return lists;
        }

        public static WordList LoadList(string name)
        {
            name = name.ToLower();

            FileInfo file = new(Path.Combine(DataPath.FullName, $"{name}.dat"));

            if (!file.Exists)
                throw new ArgumentException($"No list with name \"{name}\" found");

            using StreamReader reader = new(file.FullName);

            string? languageRow = reader.ReadLine();

            if (languageRow == null || !languageRow.Contains(SeparatorChar))
                throw new FileLoadException("Read error, Languages are incorrectly formatted");

            string[] languages = languageRow.Split(SeparatorChar,
                StringSplitOptions.TrimEntries
                | StringSplitOptions.RemoveEmptyEntries);

            WordList wordList = new(name, languages);

            while (!reader.EndOfStream)
            {
                string? wordRow = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(wordRow)) continue;

                if (!wordRow.Contains(SeparatorChar))
                    throw new FileLoadException("Read error, words are incorrectly formatted");

                string[] translations = wordRow
                    .Split(SeparatorChar, 
                        StringSplitOptions.TrimEntries 
                        | StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.ToLower())
                    .ToArray();

                if (translations.Length != languages.Length)
                    throw new FileLoadException($"Read error, inconsistent translation:\n\"{wordRow}\"");

                wordList.Add(translations);
            }

            return wordList;
        }

        public void Save()
        {
            if (!DataPath.Exists) DataPath.Create();

            string fullPath = Path.Combine(DataPath.FullName, $"{Name}.dat");

            using StreamWriter writer = new(fullPath);

            writer.WriteLine(string.Join(SeparatorChar, Languages));

            foreach (Word word in _words)
            {
                writer.WriteLine(string.Join(SeparatorChar, word.Translations));
            }
        }

        public void Add(params string[] translations)
        {
            if (translations.Length != Languages.Length)
                throw new ArgumentException($"Wrong number of translations, this WordList has {Languages.Length} languages");

            _words.Add(new(translations
                .Select(translation => translation
                    .Replace(SeparatorChar, ' ')
                    .Trim()
                    .ToLower())
                .ToArray()));
        }

        public bool Remove(int translation, string word)
        {
            if (translation < 0 || translation >= Languages.Length)
                throw new ArgumentException("Language does not exists");

            Word? findWord = _words.Find(w => w.Translations[translation] == word.ToLower());

            return findWord != null && _words.Remove(findWord);
        }

        public void List(Action<string[]> showTranslation) => List(0, showTranslation);
        public void List(int sortByTranslation, Action<string[]> showTranslation)
        {
            if (sortByTranslation < 0 || sortByTranslation >= Languages.Length)
                throw new ArgumentException("Language does not exists");

            var sorted = _words.OrderBy(word => word.Translations[sortByTranslation]);

            foreach (Word word in sorted)
            {
                showTranslation(word.Translations);
            }
        }

        public Word GetWordToPractice()
        {
            if (Languages.Length < 2)
                throw new($"List {Name} does not contain enough languages");

            if (_words.Count <= 0)
                throw new($"List {Name} does not contain any words");

            int fromLanguage = Random.Shared.Next(Languages.Length);
            int toLanguage = Random.Shared.Next(Languages.Length);

            while (fromLanguage == toLanguage)
            {
                toLanguage++;
                if (toLanguage >= Languages.Length) toLanguage = 0;
            }

            Word randomWord = _words.ElementAt(Random.Shared.Next(_words.Count));

            return new(fromLanguage, toLanguage, randomWord.Translations);
        }
    }
}
