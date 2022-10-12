using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private WordList? _wordList;
        private int selectedRow;

        private List<string[]> addedWords;
        private List<string[]> removedWords;

        public ViewForm(WordList? wordList)
        {
            InitializeComponent();

            _wordList = wordList;

            Task.Run(LoadWords);            
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            addedWords = new();
            removedWords = new();

            cbLanguage.Items.AddRange(_wordList?.Languages);
        }

        private void LoadWords() => LoadWords(0);
        private void LoadWords(int sort)
        {
            pbLoading.Maximum = _wordList.Count;

            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    gbLoading.Visible = true;
                    dgvList.Columns.Clear();
                    dgvList.Rows.Clear();
                });
            }
            else
            {
                gbLoading.Visible = true;
                dgvList.Columns.Clear();
                dgvList.Rows.Clear();
            }

            try
            {
                for (int i = 0; i < _wordList?.Languages.Length; i++)
                {
                    if (InvokeRequired)
                    {
                        Invoke(() =>
                        {
                            dgvList.Columns.Add(i.ToString(), _wordList.Languages[i]);
                        });
                    }
                    else dgvList.Columns.Add(i.ToString(), _wordList.Languages[i]);
                }

                _wordList?.List(sort, x =>
                {
                    Invoke(() =>
                    {
                        dgvList.Rows.Add(x);
                        pbLoading.PerformStep();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (InvokeRequired)
                {
                    Invoke(() =>
                    {
                        gbLoading.Visible = false;
                        pbLoading.Value = 0;
                        cbLanguage.Enabled = true;
                        btnAdd.Enabled = true;
                        btnRemove.Enabled = true;
                        btnSave.Enabled = true;
                        dgvList.Enabled = true;
                    });
                }
                else
                {
                    gbLoading.Visible = false;
                    pbLoading.Value = 0;
                    cbLanguage.Enabled = true;
                    btnAdd.Enabled = true;
                    btnRemove.Enabled = true;
                    btnSave.Enabled = true;
                    dgvList.Enabled = true;
                }
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int languageId = Array.IndexOf(_wordList.Languages, cbLanguage.SelectedItem.ToString());

            Task.Run(() => LoadWords(languageId));
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

            if (remove == DialogResult.Yes)
            {
                dgvList.Rows.RemoveAt(selectedRow);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"adding {addedWords.Count} word(s) and removing {removedWords.Count} word(s)");
        }
    }
}
