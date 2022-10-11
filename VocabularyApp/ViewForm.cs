using System.ComponentModel;
using Vocabulary;

namespace VocabularyApp
{
    public partial class ViewForm : Form
    {
        private WordList _wordList;
        private int selectedRow;

        public ViewForm(WordList wordList)
        {
            _wordList = wordList;
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _wordList.Languages.Length; i++)
                {
                    dgvList.Columns.Add(i.ToString(), _wordList.Languages[i]);
                }                

                cbLanguage.Items.AddRange(_wordList.Languages);
                if (cbLanguage.Items.Count > 0) cbLanguage.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchGrid()
        {
            dgvList.Rows.Clear();

            if (txtWord.Text.Length > 0)
            {
                try
                {
                    string language = cbLanguage.SelectedItem.ToString();

                    int languageId = Array.IndexOf(_wordList.Languages, language);

                    _wordList.List(0, x =>
                    {
                        if (x[languageId].StartsWith(txtWord.Text.ToLower())) dgvList.Rows.Add(x);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                _wordList.List(0, x => dgvList.Rows.Add(x));
            }
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            SearchGrid();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWord.Clear();
            SearchGrid();
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0 && !dgvList.Rows[e.RowIndex].IsNewRow && e.Button == MouseButtons.Right)
            {
                dgvList.ClearSelection();

                selectedRow = e.RowIndex;
                dgvList.Rows[e.RowIndex].Selected = true;
                
                rowMenu.Show(Cursor.Position);
            }
        }

        private void deleteWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult remove = MessageBox.Show("Are you sure you want to delete this word?", "Delete Word", MessageBoxButtons.YesNo);
            if(remove == DialogResult.Yes)
            {
                dgvList.Rows.RemoveAt(selectedRow);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow currentRow = dgvList.Rows[e.RowIndex];

            if (!currentRow.IsNewRow)
            {
                bool valid = true;
                foreach (DataGridViewCell cell in currentRow.Cells)
                {
                    if (cell.Value is null) valid = false;
                }

                if (!valid) currentRow.ErrorText = "All languages need translations";
                else currentRow.ErrorText = string.Empty;

                e.Cancel = !valid;
            }
        }
    }
}
