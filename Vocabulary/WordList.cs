namespace Vocabulary
{
    public class WordList
    {
        private const char separatorChar = ';';

        private static readonly DirectoryInfo dataPath = new(Path
            .Combine(Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vocabulary"));

        private readonly List<Word> words = new();

        public string Name { get; }
        public string[] Languages { get; }
        public int Count => words.Count;

        public WordList(string name, params string[] languages)
        {
            Name = name.ToLower();

            Languages = languages
                .Select(language => language.ToLower())
                .ToArray();
        }

        public static string[] GetLists()
        {
            if (dataPath.Exists)
            {
                string[] lists = dataPath
                    .EnumerateFiles("*.dat", SearchOption.TopDirectoryOnly)
                    .Select(file => Path.GetFileNameWithoutExtension(file.FullName))
                    .ToArray();

                if (lists.Length > 0) return lists;
            }

            return Array.Empty<string>();
        }

        public static WordList LoadList(string name)
        {
            name = name.ToLower();

            FileInfo file = new(Path.Combine(dataPath.FullName, $"{name}.dat"));

            if (!file.Exists)
                throw new ArgumentException($"No list with name \"{name}\" found", nameof(name));

            using StreamReader reader = new(file.FullName);

            string[] languages;
            string? languageRow = reader.ReadLine();

            if (languageRow == null || !languageRow.Contains(separatorChar))
                throw new InvalidWordlListException("Read error, Languages are incorrectly formatted");

            languages = languageRow.Split(separatorChar, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            WordList wordList = new(name, languages);

            string? wordRow;
            while (!reader.EndOfStream)
            {
                wordRow = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(wordRow)) continue;

                if (!wordRow.Contains(separatorChar))
                    throw new InvalidWordlListException("Read error, words are incorrectly formatted");
                    
                string[] translations = wordRow
                    .Split(separatorChar, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();

                if (translations.Length != languages.Length)
                    throw new InvalidWordlListException($"Read error, inconsistent translation:\n\"{wordRow}\"");
                    
                wordList.Add(translations);
            }

            return wordList;
        }

        public void Save()
        {
            if (!dataPath.Exists) dataPath.Create();

            string fullPath = Path.Combine(dataPath.FullName, $"{Name}.dat");
            using StreamWriter writer = new(fullPath);

            writer.WriteLine(string.Join(separatorChar, Languages));

            foreach (Word word in words)
            {
                writer.WriteLine(string.Join(separatorChar, word.Translations));
            }
        }

        public void Add(params string[] translations)
        {
            if (translations.Length != Languages.Length)
                throw new ArgumentException($"Wrong number of translations, this WordList has {Languages.Length} languages");
           
            words.Add(new(translations
                .Select(translation => translation.ToLower())
                .ToArray()));           
        }

        public bool Remove(int translation, string word)
        {
            if (translation < 0 || translation >= Languages.Length)
                throw new ArgumentOutOfRangeException(nameof(translation), translation, "Language does not exists");
            
            Word? findWord = words.Find(w => w.Translations[translation] == word.ToLower());

            if (findWord != null) return words.Remove(findWord);
            
            return false;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslation)
        {
            if (sortByTranslation < 0 || sortByTranslation >= Languages.Length)
                throw new ArgumentOutOfRangeException(nameof(sortByTranslation), sortByTranslation, "Language does not exists");
            
            var sorted = words.OrderBy(word => word.Translations[sortByTranslation]);

            foreach (Word word in sorted)
            {
                showTranslation(word.Translations);
            }
        }

        public Word GetWordToPractice()
        {
            if (Languages.Length <= 1)
                throw new Exception($"List {Name} does not contain enough languages");
            
            if (words.Count <= 0)
                throw new Exception($"List {Name} does not contain any words");
                
            int fromLanguage = Random.Shared.Next(Languages.Length);
            int toLanguage = Random.Shared.Next(Languages.Length);

            while (fromLanguage == toLanguage)
            {
                toLanguage++;
                if (toLanguage >= Languages.Length) toLanguage = 0;
            }

            Word randomWord = words.ElementAt(Random.Shared.Next(words.Count));

            return new(fromLanguage, toLanguage, randomWord.Translations);            
        }
    }
}
