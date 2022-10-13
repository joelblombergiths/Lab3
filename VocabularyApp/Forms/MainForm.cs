using Vocabulary;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        private WordList _wordList;

        public void OnListSelected(object? sender, ListSelectedEvent e)
        {
            try
            {
                _wordList = WordList.LoadList(e.List);
                lblLoadedList.Text = $"{_wordList.Name} ({_wordList.Count})";
                btnShow.Enabled = true;
            }
            catch(Exception ex)
            {
                lblLoadedList.Text = "No list loaded";
                btnShow.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;

            LoadForm loadForm = new();

            loadForm.ListSelected += OnListSelected;
            loadForm.ShowDialog(this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ViewForm viewForm = new(_wordList);

            viewForm.ShowDialog(this);
        }
    }
}
