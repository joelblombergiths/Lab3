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
        }

        private void lbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedIndex >= 0)
            {
                string lang = lbLanguages.SelectedItem.ToString();

                gbLang.Text = $"Translation in {lang}";
                txtTranslation.Text = wordTranslations[lang];
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTranslation_Leave(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedIndex >= 0)
            {
                string lang = lbLanguages.SelectedItem.ToString();

                wordTranslations[lang] = txtTranslation.Text;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
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
            else MessageBox.Show("All languages needs translations");
        }
    }
}
