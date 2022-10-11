using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private WordList _wordList;
        public ViewForm(WordList wordList)
        {
            _wordList = wordList;
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _wordList.Languages.Length; i++)
                {
                    dgvList.Columns.Add(i.ToString(), _wordList.Languages[i]);
                }                

                cbLanguage.Items.AddRange(_wordList.Languages);
                if (cbLanguage.Items.Count > 0) cbLanguage.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchGrid()
        {
            dgvList.Rows.Clear();

            if (txtWord.Text.Length > 0)
            {
                try
                {
                    string language = cbLanguage.SelectedItem.ToString();

                    int languageId = Array.IndexOf(_wordList.Languages, language);

                    _wordList.List(0, x =>
                    {
                        if (x[languageId].StartsWith(txtWord.Text.ToLower())) dgvList.Rows.Add(x);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                _wordList.List(0, x => dgvList.Rows.Add(x));
            }
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            SearchGrid();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWord.Clear();
            SearchGrid();
        }
    }
}
