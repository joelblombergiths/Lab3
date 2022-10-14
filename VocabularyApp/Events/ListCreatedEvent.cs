using Vocabulary;

namespace VocabularyApp
{
    public class ListCreatedEvent
    {
        public WordList NewWordList { get; }

        public ListCreatedEvent(WordList wordList)
        {
            NewWordList = wordList;
        }
    }
}
