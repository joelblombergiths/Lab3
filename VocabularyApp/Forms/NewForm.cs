using Vocabulary;

namespace VocabularyApp
{
    public partial class NewForm : Form
    {
        public event EventHandler<ListCreatedEvent>? ListCreated;
        public NewForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtLanguage.Text))
            {
                lbLanguages.Items.Add(txtLanguage.Text);
                txtLanguage.Text = string.Empty;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedIndex >= 0)
            {
                lbLanguages.Items.RemoveAt(lbLanguages.SelectedIndex);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    if (lbLanguages.Items.Count >= 2)
                    {
                        List<string> l = new();
                        foreach (string language in lbLanguages.Items)
                        {
                            l.Add(language);
                        }

                        WordList wordList = new(txtName.Text, l.ToArray());
                        wordList.Save();

                        ListCreated?.Invoke(null, new(wordList));
                        
                        Close();
                    }
                    else MessageBox.Show("Add at least 2 languages");
                }
                else MessageBox.Show("Name can't be empty");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
