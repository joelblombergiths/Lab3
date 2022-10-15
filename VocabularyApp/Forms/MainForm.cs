using Vocabulary;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        private WordList? _wordList;

        private bool practiceActive = false;
        private PracticeResult? practiceResult;

        public MainForm()
        {
            InitializeComponent();
        }
     
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm newForm = new();
            newForm.ListCreated += OnListChanged;
            newForm.ShowDialog(this);
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm loadForm = new();
            loadForm.ListSelected += OnListChanged;
            loadForm.ShowDialog(this);
        }
        public void OnListChanged(object? sender, ListEvent e)
        {           
            LoadList(e.List);
        }

        private void ShowWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_wordList != null)
            {
                ViewForm viewForm = new(_wordList);
                viewForm.ShowDialog(this);

                LoadList(_wordList.Name);
            }
        }
      
        private void LoadList(string name)
        {
            try
            {
                _wordList = WordList.LoadList(name);                
                showWordsToolStripMenuItem.Enabled = true;

                lblPractice.Text = "Press start to begin learning session";
                btnPractice.Enabled = true;

                UpdateStats();
            }
            catch (Exception ex)
            {
                gbStats.Text = "No list loaded";
                showWordsToolStripMenuItem.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStats()
        {
            gbStats.Text = _wordList?.Name;
            lblNumWords.Text = _wordList?.Count.ToString();
            lblNumLanguages.Text = _wordList?.Languages.Length.ToString();

            List<string[]> translations = new();
            _wordList?.List(0, x => translations.Add(x));

            lblNumTranslations.Text = translations
                .Select(x => x.Length)
                .Sum()
                .ToString();

            lblAverageWordLength.Text = translations
                .SelectMany(t => t.Select(x => x.Length))
                .Average()
                .ToString("f0");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnPractice_Click(object sender, EventArgs e)
        {
            if(practiceActive)
            {
                ShowNextPracticeWord();
            }
            else
            {
                if (_wordList == null) MessageBox.Show("Load a word list first!");
                else
                {
                    practiceActive = true;
                    practiceResult = new();

                    btnPractice.Text = "Next Word";
                    txtGuess.Enabled = true;

                    ShowNextPracticeWord();
                }
            }
        }
        private void ShowNextPracticeWord()
        {
            Word practiceWord = _wordList.GetWordToPractice();

            string fromLang = _wordList.Languages[practiceWord.FromLanguage];
            string fromWord = practiceWord.Translations[practiceWord.FromLanguage];

            string toLang = _wordList.Languages[practiceWord.ToLanguage];
            string toWord = practiceWord.Translations[practiceWord.ToLanguage];

            string msg = $"Translate the {fromLang.ToUpper()} word {fromWord.ToUpper()} into {toLang.ToUpper()}";
            lblPractice.Text = msg;

            practiceResult.CurrentWord = toWord;

            btnPractice.Enabled = false;
            btnGuess.Enabled = true;
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
            if (practiceResult.GuessWord(txtGuess.Text))
            {
                lblPractice.Text = $"{txtGuess.Text.ToUpper()} is the correct translation";
            }
            else
            {
                lblPractice.Text = $"Incorrect, the translation is {practiceResult.CurrentWord.ToUpper()}";
            }

            txtGuess.ResetText();
            btnPractice.Enabled = true;
            btnGuess.Enabled = false;
        }

        private void showWordsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
