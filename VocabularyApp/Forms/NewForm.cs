using System.Linq;
using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
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
                string? name = txtName.Text;
                if (string.IsNullOrWhiteSpace(name))
                    throw new("Name can't be empty");

                string[] languages = lbLanguages.Items.Cast<string>().ToArray();

                if (languages.Length < 2)
                    throw new("Add at least 2 languages");

                if (languages.GroupBy(language => language).Any(group => group.Count() > 1))
                    throw new("Can't add duplicate languages");

                if (WordList.GetLists().Contains(name))
                {
                    DialogResult result = MessageBox.Show($"\"{name}\" already exists, overwrite?",
                        "List Exists",
                        MessageBoxButtons.YesNo);

                    if(result == DialogResult.No) return;
                }

                WordList wordList = new(txtName.Text, languages);
                wordList.Save();

                ListCreated?.Invoke(null, new(wordList.Name));

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
