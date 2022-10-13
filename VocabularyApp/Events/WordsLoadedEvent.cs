using System.Data;

namespace VocabularyApp
{
    public class WordLoadedEvent : EventArgs
    {
        public string[] Translations { get; set; }

        public WordLoadedEvent(string[] translations)
        {
            Translations = translations;
        }
    }
}
