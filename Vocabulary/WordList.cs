namespace Vocabulary
{
    public class WordList
    {
        private static readonly DirectoryInfo dataPath = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vocabulary"));
        private readonly List<Word> words;

        public string Name { get; }
        public string[] Languages { get; }

        public int Count => words.Count;

        public WordList(string name, params string[] languages)
        {
            words = new();

            Name = name.ToLower();
            Languages = languages
                .Select(x => x.ToLower())
                .ToArray();
        }

        public static string[] GetLists()
        {
            if (dataPath.Exists)
            {
                string[] lists = dataPath
                    .EnumerateFiles("*.dat", SearchOption.TopDirectoryOnly)
                    .Select(file => file.Name)
                    .ToArray();

                if (lists.Length > 0) return lists;
            }

            return new string[] { "No lists found" };
        }

        public static WordList LoadList(string name)
        {
            name = name.ToLower();

            FileInfo file = new(Path.Combine(dataPath.FullName, $"{name}.dat"));

            if(file.Exists)
            {
                using TextReader reader = new StreamReader(file.FullName);

                string? getLanguages = reader.ReadLine();
                string[] languages;
                if (getLanguages != null && getLanguages.Contains(';'))
                {
                    languages = getLanguages
                        .Split(";", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();
                }
                else throw new InvalidDataException("Read error, file is incorrectly formatted");

                WordList wordList = new(name, languages);
                
                string? row;
                while ((row = reader.ReadLine()) != null)
                {
                    if (row.Contains(';'))
                    {
                        string[] translations = row
                            .Split(";", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower())
                            .ToArray();

                        if(translations.Length == languages.Length) wordList.Add(translations);
                        else throw new InvalidDataException($"Read error, inconsistent translation:\n\"{row}\"");
                    }
                    else throw new InvalidDataException("Read error, file is incorrectly formatted");
                }

                return wordList;
            }
            else throw new ArgumentException($"No list with name \"{name}\" found", nameof(name));
        }

        public void Save()
        {
            if (!dataPath.Exists) dataPath.Create();

            string fullPath = Path.Combine(dataPath.FullName, $"{Name}.dat");
            using TextWriter writer = new StreamWriter(fullPath);

            writer.WriteLine(string.Join(";", Languages));

            foreach(Word word in words)
            {
                writer.WriteLine(string.Join(";", word.Translations));
            }

            writer.Close();
        }

        public void Add(params string[] translations)
        {
            if (translations.Length == Languages.Length) 
            {
                words.Add(new(translations
                    .Select(x => x.ToLower())
                    .ToArray())); 
            }
            else throw new ArgumentException($"Wrong number of translations, this WordList has {Languages.Length} languages");
        }

        public bool Remove(int translation, string word)
        {
            if (translation >= 0 && translation < Languages.Length)
            {
                Word? findWord = words.Find(w => w.Translations[translation].Equals(word));
                if (findWord != null)
                {
                    words.Remove(findWord);
                    return true;
                }
            }
            else throw new ArgumentOutOfRangeException(nameof(translation), translation, "Language does not exists");

            return false;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslation)
        {
            if (sortByTranslation >= 0 && sortByTranslation < Languages.Length)
            {
                var sorted = words.OrderBy(x => x.Translations[sortByTranslation]);

                foreach (Word word in sorted)
                {
                    showTranslation(word.Translations);
                }
            }
            else throw new ArgumentOutOfRangeException(nameof(sortByTranslation), sortByTranslation, "Language does not exists");
        }

        public Word GetWordToPractice()
        {
            if (Languages.Length > 1)
            {
                if (words.Count > 0)
                {
                    int fromLanguage = Random.Shared.Next(Languages.Length);
                    int toLanguage;
                    do
                    {
                        toLanguage = Random.Shared.Next(Languages.Length);
                    } while (fromLanguage == toLanguage);

                    Word randomWord = words.ElementAt(Random.Shared.Next(words.Count));

                    return new Word(fromLanguage, toLanguage, randomWord.Translations);
                }
                else throw new Exception("WordList does not contain any words");
            }
            else throw new Exception("WordList does not contain enough languages");
        }
    }
}
