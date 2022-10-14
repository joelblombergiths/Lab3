using Vocabulary;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        private WordList? _wordList;

        public MainForm()
        {
            InitializeComponent();
        }
     
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm newForm = new();
            newForm.ListCreated += OnListCreated;
            newForm.ShowDialog(this);
        }

        public void OnListCreated(object? sender, ListCreatedEvent e)
        {
            _wordList = e.NewWordList;
            LoadList(_wordList.Name);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWordsToolStripMenuItem.Enabled = false;

            LoadForm loadForm = new();

            loadForm.ListSelected += OnListSelected;
            loadForm.ShowDialog(this);
        }

        public void OnListSelected(object? sender, ListSelectedEvent e)
        {
            LoadList(e.List);
        }     

        private void LoadList(string name)
        {
            try
            {
                _wordList = WordList.LoadList(name);
                lblLoadedList.Text = $"{_wordList.Name} ({_wordList.Count})";
                showWordsToolStripMenuItem.Enabled = true;                
            }
            catch (Exception ex)
            {
                lblLoadedList.Text = "No list loaded";
                showWordsToolStripMenuItem.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void showWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_wordList != null)
            {
                ViewForm viewForm = new(_wordList);
                viewForm.ShowDialog(this);

                LoadList(_wordList.Name);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
