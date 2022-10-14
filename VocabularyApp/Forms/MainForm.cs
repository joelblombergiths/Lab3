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
                
        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }
        public void OnListSelected(object? sender, ListSelectedEvent e)
        {
            try
            {
                LoadList(e.List);
                showWordsToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                lblLoadedList.Text = "No list loaded";
                showWordsToolStripMenuItem.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadList(string name)
        {
            _wordList = WordList.LoadList(name);
            lblLoadedList.Text = $"{_wordList.Name} ({_wordList.Count})";
            showWordsToolStripMenuItem.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        public void OnListCreated(object? sender, ListCreatedEvent e)
        {
            _wordList = e.NewWordList;
            LoadList(_wordList.Name);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm newForm = new();
            newForm.ListCreated += OnListCreated;
            newForm.ShowDialog(this);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWordsToolStripMenuItem.Enabled = false;

            LoadForm loadForm = new();

            loadForm.ListSelected += OnListSelected;
            loadForm.ShowDialog(this);
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
    }
}
