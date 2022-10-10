namespace Vocabulary
{
    public class Word
    {
        public string[] Translations { get; }
        public int FromLanguage { get; }
        public int ToLanguage { get; }

        public Word(params string[] translations) : this(-1, -1, translations) { }

        public Word(int fromLanguage, int toLanguage, params string[] translations)
        {
            Translations = translations;
            FromLanguage = fromLanguage;
            ToLanguage = toLanguage;
        }
    }
}