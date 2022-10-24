﻿using Vocabulary;
using VocabularyApp.Events;

namespace VocabularyApp.Forms
{
    public partial class NewForm : Form
    {
        public event EventHandler<ListEvent>? ListCreated;
        public NewForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void TxtLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Add();
            }
        }
        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(txtLanguage.Text))
            {
                lbLanguages.Items.Add(txtLanguage.Text);
                txtLanguage.Text = string.Empty;
            }
            
            txtLanguage.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedIndex >= 0)
            {
                lbLanguages.Items.RemoveAt(lbLanguages.SelectedIndex);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string? name = txtName.Text;
                if (string.IsNullOrWhiteSpace(name))
                    throw new("Name can't be empty");

                if (lbLanguages.Items.Count < 2)
                    throw new("Add at least 2 languages");

                if (WordList.GetLists().Contains(name))
                {
                    DialogResult result = MessageBox.Show($"\"{name}\" already exists, overwrite?",
                        "List Exists",
                        MessageBoxButtons.YesNo);

                    if(result == DialogResult.No) return;
                }

                WordList wordList = new(txtName.Text, lbLanguages.Items.Cast<string>().ToArray());
                wordList.Save();

                ListCreated?.Invoke(null, new(wordList.Name));

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
