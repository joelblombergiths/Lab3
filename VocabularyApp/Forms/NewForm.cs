using Vocabulary;

namespace VocabularyApp
{
    public partial class NewForm : Form
    {
        public event EventHandler<ListEvent>? ListCreated;
        public NewForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void TxtLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Add();
            }
        }
        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(txtLanguage.Text))
            {
                lbLanguages.Items.Add(txtLanguage.Text);
                txtLanguage.Text = string.Empty;
            }
            
            txtLanguage.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedIndex >= 0)
            {
                lbLanguages.Items.RemoveAt(lbLanguages.SelectedIndex);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    if (lbLanguages.Items.Count >= 2)
                    {
                        List<string> languages = new();
                        foreach (string language in lbLanguages.Items)
                        {
                            languages.Add(language);
                        }

                        WordList wordList = new(txtName.Text, languages.ToArray());
                        wordList.Save();

                        ListCreated?.Invoke(null, new(wordList.Name));

                        Close();
                    }
                    else MessageBox.Show("Add at least 2 languages");
                }
                else MessageBox.Show("Name can't be empty");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
