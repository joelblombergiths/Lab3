using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private readonly WordList _wordList;

        private bool wordsLoading;

        private int numAddedWords = 0;
        private int numRemovedWords = 0;

        private DataGridViewRow? currentRow;

        private event EventHandler<WordEvent>? WordLoaded;
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
            foreach (string language in _wordList.Languages)
            {
                dgvList.Columns.Add(language, language);
            }

            cbLanguage.Items.AddRange(_wordList?.Languages);
            if (cbLanguage.Items.Count > 0) cbLanguage.SelectedIndex = 0;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int languageId = Array.IndexOf(_wordList.Languages, cbLanguage.SelectedItem.ToString());

            ReloadList(languageId);
        }

        private void ReloadList(int sort = 0)
        {
            if (!wordsLoading)
            {
                wordsLoading = true;

                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                btnSave.Enabled = false;
                btnClose.Enabled = false;
                cbLanguage.Enabled = false;

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
                MessageBox.Show("Load Words\n" + ex.Message);
            }
        }

        public void OnWordLoaded(object? sender, WordEvent e)
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
                btnClose.Enabled = true;
                cbLanguage.Enabled = true;

                wordsLoading = false;
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add()
        {
            AddForm addForm = new(_wordList);
            addForm.NewWordAdded += OnWordAdded;
            addForm.ShowDialog(this);
        }

        private void OnWordAdded(object? sender, WordEvent e)
        {
            _wordList.Add(e.Translations);
            dgvList.Rows.Add(e.Translations);
            numAddedWords++;
        }
      
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void removeWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void RemoveWord()
        {
            try
            {
                if (currentRow != null)
                {
                    DialogResult remove = MessageBox
                       .Show("Are you sure you want to delete this word?",
                       "Delete Word",
                       MessageBoxButtons.YesNo);

                    if (remove == DialogResult.Yes)
                    {
                        _wordList.Remove(0, currentRow.Cells[0].Value.ToString());
                        dgvList.Rows.Remove(currentRow);
                        numRemovedWords++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveChanges()
        {
            MessageBox.Show($"adding {numAddedWords} word(s) and removing {numRemovedWords} word(s)");
            _wordList.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (numAddedWords > 0 || numRemovedWords > 0)
            {
                DialogResult save = MessageBox.Show("Save changes to disk?",
                                "Unsaved Changes",
                                MessageBoxButtons.YesNo);

                if (save == DialogResult.Yes) SaveChanges();
            }

            Close();
        }

        private void dgvList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var mouseHit = dgvList.HitTest(e.X, e.Y);

                if (mouseHit.RowIndex < 0 || mouseHit.ColumnIndex < 0)
                {
                    rowMenu.Items["removeWordToolStripMenuItem"].Enabled = false;
                }
                else
                {
                    currentRow = dgvList.Rows[mouseHit.RowIndex];
                    dgvList.Rows[mouseHit.RowIndex].Selected = true;
                    rowMenu.Items["removeWordToolStripMenuItem"].Enabled = true;
                }

                rowMenu.Show(dgvList, e.X, e.Y);
            }
        }
    }
}
