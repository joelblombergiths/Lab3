using System.Text;
using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private readonly WordList _wordList;

        private bool wordsLoading;

        private List<string[]> addedWords = new();
        private List<string[]> removedWords = new();

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

        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int languageId = Array.IndexOf(_wordList.Languages, cbLanguage.SelectedItem?.ToString());

            ReloadList(languageId);
        }

        private void ReloadList(int sort = 0)
        {
            if (sort < 0 || sort >= _wordList.Languages.Length) sort = 0;

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

        private void DgvList_MouseDown(object sender, MouseEventArgs e)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        private void AddWordToolStripMenuItem_Click(object sender, EventArgs e)
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
            dgvList.Rows.Add(e.Translations);

            int removedIndex = removedWords.FindIndex(a => a.SequenceEqual(e.Translations));

            if (removedIndex < 0) addedWords.Add(e.Translations);            
            else removedWords.RemoveAt(removedIndex);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void RemoveWordToolStripMenuItem_Click(object sender, EventArgs e)
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
                            dgvList.Rows.Remove(selectedRow);

                            List<string> rowValues = new();

                            foreach(DataGridViewCell cell in selectedRow.Cells)
                            {
                                rowValues.Add(cell.Value.ToString().ToLower());
                            }

                            string[] translations = rowValues.ToArray();

                            int addedIndex = addedWords.FindIndex(a => a.SequenceEqual(translations));

                            if (addedIndex < 0) removedWords.Add(translations);
                            else addedWords.RemoveAt(addedIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (addedWords.Count > 0 || removedWords.Count > 0)
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
            StringBuilder sb = new();

            sb.Append(addedWords.Count > 0 
                ? $"adding {addedWords.Count} word{(addedWords.Count > 1 ? "s" : string.Empty)}" 
                : string.Empty);

            sb.Append(addedWords.Count > 0 && removedWords.Count > 0
                ? " and " 
                : string.Empty);

            sb.Append(removedWords.Count > 0
                ? $"removing {removedWords.Count} word{(removedWords.Count > 1 ? "s" : string.Empty)}" 
                : string.Empty);
            
            if(sb.Length > 0) MessageBox.Show(sb.ToString());

            removedWords.ForEach(translation => _wordList.Remove(0, translation[0]));
            addedWords.ForEach(translation => _wordList.Add(translation));

            if(removedWords.Count > 0 || addedWords.Count > 0) _wordList.Save();
        }
    }
}
