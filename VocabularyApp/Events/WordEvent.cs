namespace VocabularyApp.Events
{
    public class WordEvent : EventArgs
    {
        public string[] Translations { get; }

        public WordEvent(string[] translations)
        {
            Translations = translations;
        }
    }
}
