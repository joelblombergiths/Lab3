using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
{
    public partial class AddForm : Form
    {
        private readonly Dictionary<string, string> _wordTranslations = new();
        private readonly WordList _wordlist;

        public event EventHandler<WordEvent>? NewWordAdded;

        public AddForm(WordList wordList)
        {
            InitializeComponent();

            _wordlist = wordList;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            foreach (string language in _wordlist.Languages)
            {
                _wordTranslations.Add(language, string.Empty);
                lbLanguages.Items.Add(language);
            }

            if (lbLanguages.Items.Count > 0) lbLanguages.SelectedIndex = 0;

            ActiveControl = txtTranslation;
        }

        private void LbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? language = lbLanguages.SelectedItem?.ToString();
            if (language == null) return;
            
            btnNext.Enabled = lbLanguages.SelectedIndex < lbLanguages.Items.Count - 1;
            
            gbLang.Text = $"Add translation in {language}";
            txtTranslation.Text = _wordTranslations[language];
            txtTranslation.Focus();
        }

        private void TxtTranslation_Leave(object sender, EventArgs e)
        {
            SaveWord();
        }

        private void TxtTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveWord();

                if (lbLanguages.SelectedIndex == lbLanguages.Items.Count - 1) Done();
                else GotoNextLanguage();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            SaveWord();
            GotoNextLanguage();
        }

        private void SaveWord()
        {
            string? language = lbLanguages.SelectedItem?.ToString();
            if (language != null) _wordTranslations[language] = txtTranslation.Text;
        }
        private void GotoNextLanguage()
        {
            int currentLanguage = lbLanguages.SelectedIndex;
            if (currentLanguage >= 0 && currentLanguage < lbLanguages.Items.Count - 1) lbLanguages.SelectedIndex++;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            Done();
        }

        private void Done()
        {
            if (_wordTranslations.All(translation => !string.IsNullOrEmpty(translation.Value)))
            {
                string[] translations = _wordlist.Languages.Select(language => _wordTranslations[language]).ToArray();

                NewWordAdded?.Invoke(null, new(translations));
                Close();
            }
            else
            {
                MessageBox.Show("All languages needs translations");
                string language = _wordTranslations.First(x => string.IsNullOrEmpty(x.Value)).Key;
                lbLanguages.SelectedItem = language;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
