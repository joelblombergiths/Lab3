namespace VocabularyApp.Forms
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.pMenu = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLang = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbLoading = new System.Windows.Forms.GroupBox();
            this.pbLoadingBar = new System.Windows.Forms.ProgressBar();
            this.pBody = new System.Windows.Forms.Panel();
            this.rowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pMenu.SuspendLayout();
            this.gbLoading.SuspendLayout();
            this.pBody.SuspendLayout();
            this.rowMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowEditingIcon = false;
            this.dgvList.Size = new System.Drawing.Size(1380, 794);
            this.dgvList.TabIndex = 0;
            this.dgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvList_MouseDown);
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.Enabled = false;
            this.cbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(22, 81);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(229, 40);
            this.cbLanguage.TabIndex = 1;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.CbLanguage_SelectedIndexChanged);
            // 
            // pMenu
            // 
            this.pMenu.Controls.Add(this.btnClose);
            this.pMenu.Controls.Add(this.lblLang);
            this.pMenu.Controls.Add(this.btnRemove);
            this.pMenu.Controls.Add(this.cbLanguage);
            this.pMenu.Controls.Add(this.btnAdd);
            this.pMenu.Controls.Add(this.btnSave);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(1380, 181);
            this.pMenu.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Enabled = false;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(1218, 51);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 105);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(22, 43);
            this.lblLang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(168, 32);
            this.lblLang.TabIndex = 2;
            this.lblLang.Text = "Sort Language";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(882, 51);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(139, 105);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(732, 51);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 105);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1068, 51);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 105);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // gbLoading
            // 
            this.gbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoading.Controls.Add(this.pbLoadingBar);
            this.gbLoading.Location = new System.Drawing.Point(455, 297);
            this.gbLoading.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbLoading.Name = "gbLoading";
            this.gbLoading.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbLoading.Size = new System.Drawing.Size(371, 79);
            this.gbLoading.TabIndex = 6;
            this.gbLoading.TabStop = false;
            this.gbLoading.Text = "Loading List...";
            this.gbLoading.Visible = false;
            // 
            // pbLoadingBar
            // 
            this.pbLoadingBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoadingBar.Location = new System.Drawing.Point(6, 38);
            this.pbLoadingBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbLoadingBar.Name = "pbLoadingBar";
            this.pbLoadingBar.Size = new System.Drawing.Size(359, 35);
            this.pbLoadingBar.Step = 1;
            this.pbLoadingBar.TabIndex = 0;
            // 
            // pBody
            // 
            this.pBody.Controls.Add(this.gbLoading);
            this.pBody.Controls.Add(this.dgvList);
            this.pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBody.Location = new System.Drawing.Point(0, 181);
            this.pBody.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1380, 794);
            this.pBody.TabIndex = 4;
            // 
            // rowMenu
            // 
            this.rowMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWordToolStripMenuItem,
            this.removeWordToolStripMenuItem});
            this.rowMenu.Name = "rowMenu";
            this.rowMenu.Size = new System.Drawing.Size(239, 80);
            // 
            // addWordToolStripMenuItem
            // 
            this.addWordToolStripMenuItem.Name = "addWordToolStripMenuItem";
            this.addWordToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
            this.addWordToolStripMenuItem.Text = "Add Word";
            this.addWordToolStripMenuItem.Click += new System.EventHandler(this.AddWordToolStripMenuItem_Click);
            // 
            // removeWordToolStripMenuItem
            // 
            this.removeWordToolStripMenuItem.Enabled = false;
            this.removeWordToolStripMenuItem.Name = "removeWordToolStripMenuItem";
            this.removeWordToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
            this.removeWordToolStripMenuItem.Text = "Remove Word";
            this.removeWordToolStripMenuItem.Click += new System.EventHandler(this.RemoveWordToolStripMenuItem_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1380, 975);
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.pMenu);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(921, 331);
            this.Name = "ViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Words";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewForm_FormClosing);
            this.Load += new System.EventHandler(this.ViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.gbLoading.ResumeLayout(false);
            this.pBody.ResumeLayout(false);
            this.rowMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvList;
        private ComboBox cbLanguage;
        private Panel pMenu;
        private Panel pBody;
        private ContextMenuStrip rowMenu;
        private ToolStripMenuItem removeWordToolStripMenuItem;
        private Button btnSave;
        private Button btnRemove;
        private Button btnAdd;
        private GroupBox gbLoading;
        private ProgressBar pbLoadingBar;
        private Button btnClose;
        private Label lblLang;
        private ToolStripMenuItem addWordToolStripMenuItem;
    }
}