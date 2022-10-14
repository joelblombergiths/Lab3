namespace VocabularyApp
{
    partial class AddForm
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
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbLanguages = new System.Windows.Forms.ListBox();
            this.gbLang = new System.Windows.Forms.GroupBox();
            this.txtTranslation = new System.Windows.Forms.TextBox();
            this.gbLang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(252, 82);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 35);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(171, 82);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbLanguages
            // 
            this.lbLanguages.FormattingEnabled = true;
            this.lbLanguages.ItemHeight = 15;
            this.lbLanguages.Location = new System.Drawing.Point(12, 12);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(109, 109);
            this.lbLanguages.TabIndex = 2;
            this.lbLanguages.SelectedIndexChanged += new System.EventHandler(this.lbLanguages_SelectedIndexChanged);
            // 
            // gbLang
            // 
            this.gbLang.Controls.Add(this.txtTranslation);
            this.gbLang.Location = new System.Drawing.Point(127, 12);
            this.gbLang.Name = "gbLang";
            this.gbLang.Size = new System.Drawing.Size(200, 62);
            this.gbLang.TabIndex = 3;
            this.gbLang.TabStop = false;
            // 
            // txtTranslation
            // 
            this.txtTranslation.Location = new System.Drawing.Point(6, 22);
            this.txtTranslation.Name = "txtTranslation";
            this.txtTranslation.Size = new System.Drawing.Size(188, 23);
            this.txtTranslation.TabIndex = 0;
            this.txtTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTranslation_KeyDown);
            this.txtTranslation.Leave += new System.EventHandler(this.txtTranslation_Leave);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(335, 129);
            this.Controls.Add(this.gbLang);
            this.Controls.Add(this.lbLanguages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Word";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.gbLang.ResumeLayout(false);
            this.gbLang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDone;
        private Button btnCancel;
        private ListBox lbLanguages;
        private GroupBox gbLang;
        private TextBox txtTranslation;
    }
}