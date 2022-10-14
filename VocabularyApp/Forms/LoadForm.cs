﻿using Vocabulary;

namespace VocabularyApp
{
    public partial class LoadForm : Form
    {
        public event EventHandler<ListSelectedEvent>? ListSelected;
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
            if (lbLists.SelectedItem is not null)
            {
                ListSelected?.Invoke(this, new(lbLists.SelectedItem.ToString()));
                Close();
            }
        }
    }
}