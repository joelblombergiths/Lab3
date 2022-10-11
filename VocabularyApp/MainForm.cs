using Vocabulary;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        private WordList? wordList;

        public void OnListLoaded(object? sender, MessageEvent e)
        {
            try
            {
                wordList = WordList.LoadList(e.Message);
                lblLoadedList.Text = $"{wordList.Name} ({wordList.Count})";
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

            LoadForm loadForm = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            loadForm.ListSelected += OnListLoaded;
            loadForm.ShowDialog(this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ViewForm viewForm = new(wordList)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            viewForm.ShowDialog(this);
        }
    }
}
