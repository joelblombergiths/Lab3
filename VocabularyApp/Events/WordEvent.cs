namespace VocabularyApp
{
    public class WordEvent : EventArgs
    {
        public string[] Translations { get; set; }

        public WordEvent(string[] translations)
        {
            Translations = translations;
        }
    }
}
