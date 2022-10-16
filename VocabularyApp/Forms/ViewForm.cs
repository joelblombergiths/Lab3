using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private readonly WordList _wordList;

        private bool wordsLoading;

        private int numAddedWords = 0;
        private int numRemovedWords = 0;       

        public ViewForm(WordList wordList)
        {
            InitializeComponent();

            _wordList = wordList;
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

                Task.Run(() => LoadWords(sort, _wordList));
            }
        }

        private void LoadWords(int sort, WordList wordList)
        {
            try
            {
                wordList.List(sort, translations =>
                {
                    LoadWord(translations);
                });

                LoadWordsComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Words failed\n" + ex.Message);
            }
        }

        private void LoadWord(string[] translations)
        {
            Invoke(() =>
            {
                pbLoadingBar.PerformStep();
                dgvList.Rows.Add(translations);
            });
        }

        private void LoadWordsComplete()
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
            AddWord();
        }

        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        private void AddWord()
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
                if (dgvList.SelectedRows.Count > 0)
                {
                    DialogResult remove = MessageBox
                       .Show("Are you sure you want to delete this word?",
                       "Delete Word",
                       MessageBoxButtons.YesNo);

                    if (remove == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dgvList.SelectedRows[0];

                        string? word = selectedRow.Cells[0].Value.ToString();
                        if (word != null)
                        {
                            _wordList.Remove(0, word);
                            dgvList.Rows.Remove(selectedRow);
                            numRemovedWords++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void SaveChanges()
        {
            MessageBox.Show($"adding {numAddedWords} word(s) and removing {numRemovedWords} word(s)");
            _wordList.Save();
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
                    dgvList.Rows[mouseHit.RowIndex].Selected = true;
                    rowMenu.Items["removeWordToolStripMenuItem"].Enabled = true;
                }

                rowMenu.Show(dgvList, e.X, e.Y);
            }
        }   
    }
}
