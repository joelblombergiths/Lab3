using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
{
    public partial class LoadForm : Form
    {
        public event EventHandler<ListEvent>? ListSelected;
        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            lbLists.Items.AddRange(WordList.GetLists());
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LbLists_DoubleClick(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            string? listName = lbLists.SelectedItem?.ToString();
            if (listName == null) return;

            ListSelected?.Invoke(null, new(listName));
            Close();
        }
    }
}
