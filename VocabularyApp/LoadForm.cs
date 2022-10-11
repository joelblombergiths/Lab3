using Vocabulary;

namespace VocabularyApp
{
    public partial class LoadForm : Form
    {
        public event EventHandler<MessageEvent>? ListSelected;
        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            lbLists.Items.AddRange(WordList.GetLists());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if(lbLists.SelectedIndex >= 0)
            {
                ListSelected?.Invoke(this, new(lbLists.SelectedItem.ToString()));
                Close();
            }
        }
    }
}
