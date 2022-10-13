using Vocabulary;


namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private readonly WordList _wordList;

        private readonly List<string[]> addedWords = new();
        private readonly List<string[]> removedWords = new();

        private int selectedRow;
        private bool wordsLoading;

        private event EventHandler<WordLoadedEvent>? WordLoaded;
        private event EventHandler? AllWordsLoaded;

        public ViewForm(WordList wordList)
        {
            InitializeComponent();

            _wordList = wordList;

            WordLoaded += OnWordLoaded;
            AllWordsLoaded += OnAllWordsLoaded;
        }
        private void ViewForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _wordList.Languages.Length; i++)
            {
                dgvList.Columns.Add(i.ToString(), _wordList.Languages[i]);
            }

            cbLanguage.Items.AddRange(_wordList?.Languages);
            if (cbLanguage.Items.Count > 0) cbLanguage.SelectedIndex = 0;
        }

        public void OnWordLoaded(object? sender, WordLoadedEvent e)
        {
            Invoke(() =>
            {
                pbLoadingBar.PerformStep();
                dgvList.Rows.Add(e.Translations);
            });
        }

        public void OnAllWordsLoaded(object? sender, EventArgs e)
        {
            Invoke(() =>
            {
                gbLoading.Visible = false;
                dgvList.Visible = true;

                btnAdd.Enabled = true;
                btnRemove.Enabled = true;
                btnSave.Enabled = true;
                cbLanguage.Enabled = true;

                wordsLoading = false;
            });
        }

        private void ReloadList(int sort = 0)
        {
            if (!wordsLoading)
            {
                wordsLoading = true;

                pbLoadingBar.Value = 0;
                pbLoadingBar.Maximum = _wordList.Count;
                
                gbLoading.Visible = true;

                dgvList.Visible = false;
                dgvList.Rows.Clear();

                Task.Run(() => LoadWords(_wordList, sort));
            }
        }

        private void LoadWords(WordList wordList, int sort)
        {
            try
            {
                wordList.List(sort, x =>
                {
                    WordLoaded?.Invoke(null, new(x));
                });

                AllWordsLoaded?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int languageId = Array.IndexOf(_wordList.Languages, cbLanguage.SelectedItem.ToString());

            ReloadList(languageId);
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                !dgvList.Rows[e.RowIndex].IsNewRow &&
                e.Button == MouseButtons.Right)
            {
                dgvList.ClearSelection();

                selectedRow = e.RowIndex;
                dgvList.Rows[e.RowIndex].Selected = true;

                rowMenu.Show(Cursor.Position);
            }
        }

        private void deleteWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult remove = MessageBox
                .Show("Are you sure you want to delete this word?",
                "Delete Word",
                MessageBoxButtons.YesNo);

            if (remove == DialogResult.Yes) dgvList.Rows.RemoveAt(selectedRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"adding {addedWords.Count} word(s) and removing {removedWords.Count} word(s)");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
