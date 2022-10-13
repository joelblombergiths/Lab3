using System.Data;
using Vocabulary;

namespace VocabularyApp
{
    internal static class WordLoader
    {
        public static event EventHandler? AllWordsLoaded;
        public static event EventHandler<WordLoadedEvent>? WordLoaded;
        
        public static void Load(WordList wordList, int sort)
        {
            try
            {
                wordList.List(sort, x =>
                {
                    WordLoaded?.Invoke(null, new(x));
                });

                AllWordsLoaded?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
