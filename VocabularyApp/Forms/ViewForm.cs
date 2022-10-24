using System.Text;
using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
{
    public partial class ViewForm : Form
    {
        private readonly WordList _wordList;

        private readonly List<string[]> _addedWords = new();
        private readonly List<string[]> _removedWords = new();

        private bool _wordsLoading;

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

            cbLanguage.Items.AddRange(_wordList.Languages);
            if (cbLanguage.Items.Count > 0) cbLanguage.SelectedIndex = 0;
        }

        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int languageId = Array.IndexOf(_wordList.Languages, cbLanguage.SelectedItem?.ToString());

            ReloadList(languageId);
        }

        private void ReloadList(int sort = 0)
        {
            if (_wordsLoading) return;

            if (sort < 0 || sort >= _wordList.Languages.Length) sort = 0;
            
            _wordsLoading = true;

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

        private void LoadWords(int sort, WordList wordList)
        {
            try
            {
                wordList.List(sort, LoadWord);

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

                _wordsLoading = false;
            });
        }

        private void DgvList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var mouseHit = dgvList.HitTest(e.X, e.Y);

                rowMenu.Items["removeWordToolStripMenuItem"].Enabled = false;

                if (mouseHit.RowIndex >= 0)
                {
                    dgvList.Rows[mouseHit.RowIndex].Selected = true;
                    rowMenu.Items["removeWordToolStripMenuItem"].Enabled = true;
                }

                rowMenu.Show(dgvList, e.Location);
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
            if (ModifiedThisSession(e.Translations, _removedWords, out int index)) _removedWords.RemoveAt(index);
            else _addedWords.Add(e.Translations);

            dgvList.Rows.Add(e.Translations);
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
                if (dgvList.SelectedRows.Count <= 0) return;

                DialogResult remove = MessageBox
                    .Show("Are you sure you want to delete this word?",
                        "Delete Word",
                        MessageBoxButtons.YesNo);

                if (remove == DialogResult.No) return;

                DataGridViewRow selectedRow = dgvList.SelectedRows[0];

                List<string> cellValues = new();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    cellValues.Add(cell.Value.ToString().ToLower());
                }

                string[] translations = cellValues.ToArray();

                if (ModifiedThisSession(translations, _addedWords, out int index)) _addedWords.RemoveAt(index);
                else _removedWords.Add(translations);

                dgvList.Rows.Remove(selectedRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static bool ModifiedThisSession(string[] translations, List<string[]> list, out int index)
        {
            index = list.FindIndex(t => t.SequenceEqual(translations));
            return index >= 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (_addedWords.Count > 0 || _removedWords.Count > 0)
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
            try
            {
                StringBuilder sb = new();

                sb.Append(_addedWords.Count > 0
                    ? $"adding {_addedWords.Count} word{(_addedWords.Count > 1 ? "s" : string.Empty)}"
                    : string.Empty);

                sb.Append(_addedWords.Count > 0 && _removedWords.Count > 0
                    ? " and "
                    : string.Empty);

                sb.Append(_removedWords.Count > 0
                    ? $"removing {_removedWords.Count} word{(_removedWords.Count > 1 ? "s" : string.Empty)}"
                    : string.Empty);

                if (sb.Length > 0) MessageBox.Show(sb.ToString());

                _removedWords.ForEach(translation => _wordList.Remove(0, translation[0]));
                _addedWords.ForEach(translation => _wordList.Add(translation));

                if (_removedWords.Count > 0 || _addedWords.Count > 0) _wordList.Save();

                _removedWords.Clear();
                _addedWords.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
