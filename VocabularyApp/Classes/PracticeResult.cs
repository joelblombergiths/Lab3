namespace VocabularyApp
{
    internal class PracticeResult
    {
		public int Correct { get; private set; }
		public int Total { get; private set; }        
		public float SuccessRateProcentage => (float)Correct / Total * 100;

		private string _currentWord = string.Empty;
		public string CurrentWord
		{
			get { return _currentWord; }
			set { _currentWord = value.ToLower(); }
		}

		public bool GuessWord(string word)
		{
			Total++;

			if(word.ToLower() == CurrentWord)
			{
				Correct++;
				return true;
			}
			return false;
		}

		public PracticeResult()
		{
			Correct = 0;
			Total = 0;
		}
    }
}
