namespace VocabularyApp
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
            this.dgvList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowEditingIcon = false;
            this.dgvList.Size = new System.Drawing.Size(1061, 620);
            this.dgvList.TabIndex = 0;
            this.dgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvList_MouseDown);
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.Enabled = false;
            this.cbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(17, 63);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(177, 33);
            this.cbLanguage.TabIndex = 1;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
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
            this.pMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(1061, 142);
            this.pMenu.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Enabled = false;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(937, 40);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 82);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(17, 33);
            this.lblLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(127, 25);
            this.lblLang.TabIndex = 2;
            this.lblLang.Text = "Sort Language";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(679, 40);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(107, 82);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(563, 40);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 82);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(821, 40);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 82);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbLoading
            // 
            this.gbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoading.Controls.Add(this.pbLoadingBar);
            this.gbLoading.Location = new System.Drawing.Point(350, 232);
            this.gbLoading.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLoading.Name = "gbLoading";
            this.gbLoading.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLoading.Size = new System.Drawing.Size(286, 62);
            this.gbLoading.TabIndex = 6;
            this.gbLoading.TabStop = false;
            this.gbLoading.Text = "Loading List...";
            this.gbLoading.Visible = false;
            // 
            // pbLoadingBar
            // 
            this.pbLoadingBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoadingBar.Location = new System.Drawing.Point(4, 29);
            this.pbLoadingBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLoadingBar.Name = "pbLoadingBar";
            this.pbLoadingBar.Size = new System.Drawing.Size(278, 28);
            this.pbLoadingBar.Step = 1;
            this.pbLoadingBar.TabIndex = 0;
            // 
            // pBody
            // 
            this.pBody.Controls.Add(this.gbLoading);
            this.pBody.Controls.Add(this.dgvList);
            this.pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBody.Location = new System.Drawing.Point(0, 142);
            this.pBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1061, 620);
            this.pBody.TabIndex = 4;
            // 
            // rowMenu
            // 
            this.rowMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWordToolStripMenuItem,
            this.removeWordToolStripMenuItem});
            this.rowMenu.Name = "rowMenu";
            this.rowMenu.Size = new System.Drawing.Size(198, 68);
            // 
            // addWordToolStripMenuItem
            // 
            this.addWordToolStripMenuItem.Name = "addWordToolStripMenuItem";
            this.addWordToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.addWordToolStripMenuItem.Text = "Add Word";
            this.addWordToolStripMenuItem.Click += new System.EventHandler(this.addWordToolStripMenuItem_Click);
            // 
            // removeWordToolStripMenuItem
            // 
            this.removeWordToolStripMenuItem.Name = "removeWordToolStripMenuItem";
            this.removeWordToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.removeWordToolStripMenuItem.Text = "Remove Word";
            this.removeWordToolStripMenuItem.Click += new System.EventHandler(this.removeWordToolStripMenuItem_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1061, 762);
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.pMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(719, 296);
            this.Name = "ViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Words";
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