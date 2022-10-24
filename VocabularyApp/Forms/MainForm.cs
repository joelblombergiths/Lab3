using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
{
    public partial class MainForm : Form
    {
        private WordList? _wordList;

        private bool _practiceActive;
        private PracticeResult? _practiceResult;

        public MainForm()
        {
            InitializeComponent();
        }
     
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm newForm = new();
            newForm.ListCreated += OnListChanged;
            newForm.ShowDialog();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm loadForm = new();
            loadForm.ListSelected += OnListChanged;
            loadForm.ShowDialog();
        }

        private void OnListChanged(object? sender, ListEvent e)
        {           
            LoadList(e.List);
        }
          
        private void LoadList(string name)
        {
            try
            {
                _wordList = WordList.LoadList(name);                
                showWordsToolStripMenuItem.Enabled = true;

                UpdateListStats();

                _practiceActive = false;

                lblPractice.Text = "Press start to begin learning session";
                btnPractice.Text = "Start";
                btnPractice.Enabled = true;

                btnGuess.Enabled = false;
                txtGuess.Enabled = false;
                
                UpdatePracticeStats(true);
            }
            catch (Exception ex)
            {
                gbStats.Text = "No list loaded";
                lblPractice.Text = "Load a word list";
                showWordsToolStripMenuItem.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_wordList == null) return;

            ViewForm viewForm = new(_wordList);
            viewForm.ShowDialog(this);

            LoadList(_wordList.Name);
        }

        private void UpdateListStats()
        {
            try
            {
                gbStats.Text = _wordList?.Name;
                lblNumWords.Text = _wordList?.Count.ToString();
                lblNumLanguages.Text = _wordList?.Languages.Length.ToString();

                List<string[]> translations = new();
                _wordList?.List(0, t => translations.Add(t));

                lblNumTranslations.Text = translations
                    .Select(t => t.Length)
                    .Sum()
                    .ToString();

                lblAverageWordLength.Text = translations
                    .SelectMany(t => t.Select(x => x.Length))
                    .Average()
                    .ToString("f0");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void BtnPractice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_practiceActive)
                {
                    if (_wordList == null) 
                        throw new("Load a word list first!");

                    if (_wordList.Count <= 0)
                        throw new("No words in list!");

                    _practiceActive = true;
                    _practiceResult = new();

                    btnPractice.Text = "Next Word";
                }

                ShowNextPracticeWord();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowNextPracticeWord()
        {
            Word practiceWord = _wordList.GetWordToPractice();

            string? fromLang = _wordList.Languages[practiceWord.FromLanguage];
            string fromWord = practiceWord.Translations[practiceWord.FromLanguage];

            string toLang = _wordList.Languages[practiceWord.ToLanguage];
            string toWord = practiceWord.Translations[practiceWord.ToLanguage];

            string msg = $"Translate the {fromLang.ToUpper()} word {fromWord.ToUpper()} into {toLang.ToUpper()}";
            lblPractice.Text = msg;

            _practiceResult.CurrentWord = toWord;

            btnPractice.Enabled = false;
            btnGuess.Enabled = true;
            txtGuess.Enabled = true;
            txtGuess.Focus();
        }

        private void BtnGuess_Click(object sender, EventArgs e)
        {
            GuessWord();
        }

        private void TxtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GuessWord();
            }
        }

        private void GuessWord()
        {
            lblPractice.Text = _practiceResult.GuessWord(txtGuess.Text) 
                ? $"{txtGuess.Text.ToUpper()} is the correct translation" 
                : $"Incorrect, the translation is {_practiceResult.CurrentWord.ToUpper()}";

            UpdatePracticeStats();

            txtGuess.ResetText();
            txtGuess.Enabled = false;
            btnGuess.Enabled = false;
            btnPractice.Enabled = true;
        }

        private void UpdatePracticeStats(bool reset = false)
        {
            if(reset)
            {
                lblNumWordInSession.Text = "0";
                lblNumCorrectGuesses.Text = "0";
                lblSuccessPercentage.Text = "0";
                return;
            }

            lblNumWordInSession.Text = _practiceResult.Total.ToString();
            lblNumCorrectGuesses.Text = _practiceResult.Correct.ToString();
            lblSuccessPercentage.Text = $"{_practiceResult.SuccessRateProcentage:f0}%";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
