using Vocabulary;

namespace VocabularyApp
{
    public partial class AddForm : Form
    {
        private readonly WordList _wordlist;
        private readonly Dictionary<string, string> wordTranslations;

        public event EventHandler<WordEvent>? NewWordAdded;

        public AddForm(WordList wordList)
        {
            InitializeComponent();

            _wordlist = wordList;
            wordTranslations = new();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            foreach (string language in _wordlist.Languages)
            {
                wordTranslations.Add(language, string.Empty);
                lbLanguages.Items.Add(language);
            }

            if (lbLanguages.Items.Count > 0) lbLanguages.SelectedIndex = 0;

            ActiveControl = txtTranslation;
        }

        private void lbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentLanguage = lbLanguages.SelectedIndex;
            if (currentLanguage >= 0)
            {
                if (currentLanguage < lbLanguages.Items.Count - 1) btnNext.Enabled = true;
                else btnNext.Enabled = false;
                
                string? language = lbLanguages.SelectedItem?.ToString();
                if (language != null)
                {
                    gbLang.Text = $"Add translation in {language}";
                    txtTranslation.Text = wordTranslations[language];
                    txtTranslation.Focus();
                }
            }
        }

        private void txtTranslation_Leave(object sender, EventArgs e)
        {
            SaveWord();
        }

        private void txtTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveWord();

                if (lbLanguages.SelectedIndex == lbLanguages.Items.Count - 1) Done();
                else GotoNextLanguage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveWord();
            GotoNextLanguage();
        }

        private void SaveWord()
        {
            string? language = lbLanguages.SelectedItem?.ToString();
            if (language != null) wordTranslations[language] = txtTranslation.Text;
        }
        private void GotoNextLanguage()
        {
            int currentLanguage = lbLanguages.SelectedIndex;
            if (currentLanguage >= 0 && currentLanguage < lbLanguages.Items.Count - 1) lbLanguages.SelectedIndex++;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Done();
        }

        private void Done()
        {
            if (wordTranslations.All(x => !string.IsNullOrEmpty(x.Value)))
            {
                List<string> t = new();

                foreach (string language in _wordlist.Languages)
                {
                    t.Add(wordTranslations[language]);
                }

                NewWordAdded?.Invoke(null, new(t.ToArray()));
                Close();
            }
            else
            {
                MessageBox.Show("All languages needs translations");
                string language = wordTranslations.First(x => string.IsNullOrEmpty(x.Value)).Key;
                lbLanguages.SelectedItem = language;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
