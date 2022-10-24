namespace VocabularyApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.lblAverageWordLength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumTranslations = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumLanguages = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumWords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.btnPractice = new System.Windows.Forms.Button();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.lblPractice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSuccessPercentage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumCorrectGuesses = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNumWordInSession = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.gbStats.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1150, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWordsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // showWordsToolStripMenuItem
            // 
            this.showWordsToolStripMenuItem.Enabled = false;
            this.showWordsToolStripMenuItem.Name = "showWordsToolStripMenuItem";
            this.showWordsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.showWordsToolStripMenuItem.Text = "Show Words";
            this.showWordsToolStripMenuItem.Click += new System.EventHandler(this.ShowWordsToolStripMenuItem_Click);
            // 
            // gbStats
            // 
            this.gbStats.Controls.Add(this.lblAverageWordLength);
            this.gbStats.Controls.Add(this.label4);
            this.gbStats.Controls.Add(this.lblNumTranslations);
            this.gbStats.Controls.Add(this.label5);
            this.gbStats.Controls.Add(this.lblNumLanguages);
            this.gbStats.Controls.Add(this.label2);
            this.gbStats.Controls.Add(this.lblNumWords);
            this.gbStats.Controls.Add(this.label1);
            this.gbStats.Location = new System.Drawing.Point(8, 29);
            this.gbStats.Margin = new System.Windows.Forms.Padding(2);
            this.gbStats.Name = "gbStats";
            this.gbStats.Padding = new System.Windows.Forms.Padding(2);
            this.gbStats.Size = new System.Drawing.Size(179, 165);
            this.gbStats.TabIndex = 5;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "No list loaded";
            // 
            // lblAverageWordLength
            // 
            this.lblAverageWordLength.AutoSize = true;
            this.lblAverageWordLength.Location = new System.Drawing.Point(139, 93);
            this.lblAverageWordLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAverageWordLength.Name = "lblAverageWordLength";
            this.lblAverageWordLength.Size = new System.Drawing.Size(13, 15);
            this.lblAverageWordLength.TabIndex = 7;
            this.lblAverageWordLength.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Average word length: ";
            // 
            // lblNumTranslations
            // 
            this.lblNumTranslations.AutoSize = true;
            this.lblNumTranslations.Location = new System.Drawing.Point(139, 70);
            this.lblNumTranslations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumTranslations.Name = "lblNumTranslations";
            this.lblNumTranslations.Size = new System.Drawing.Size(13, 15);
            this.lblNumTranslations.TabIndex = 5;
            this.lblNumTranslations.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "# of translations: ";
            // 
            // lblNumLanguages
            // 
            this.lblNumLanguages.AutoSize = true;
            this.lblNumLanguages.Location = new System.Drawing.Point(139, 49);
            this.lblNumLanguages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumLanguages.Name = "lblNumLanguages";
            this.lblNumLanguages.Size = new System.Drawing.Size(13, 15);
            this.lblNumLanguages.TabIndex = 3;
            this.lblNumLanguages.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "# of languages: ";
            // 
            // lblNumWords
            // 
            this.lblNumWords.AutoSize = true;
            this.lblNumWords.Location = new System.Drawing.Point(139, 26);
            this.lblNumWords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumWords.Name = "lblNumWords";
            this.lblNumWords.Size = new System.Drawing.Size(13, 15);
            this.lblNumWords.TabIndex = 1;
            this.lblNumWords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "# of words: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuess);
            this.groupBox1.Controls.Add(this.btnPractice);
            this.groupBox1.Controls.Add(this.txtGuess);
            this.groupBox1.Controls.Add(this.lblPractice);
            this.groupBox1.Location = new System.Drawing.Point(192, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(769, 165);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Practice";
            // 
            // btnGuess
            // 
            this.btnGuess.Enabled = false;
            this.btnGuess.Location = new System.Drawing.Point(520, 62);
            this.btnGuess.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(78, 25);
            this.btnGuess.TabIndex = 3;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.BtnGuess_Click);
            // 
            // btnPractice
            // 
            this.btnPractice.Enabled = false;
            this.btnPractice.Location = new System.Drawing.Point(99, 115);
            this.btnPractice.Margin = new System.Windows.Forms.Padding(2);
            this.btnPractice.Name = "btnPractice";
            this.btnPractice.Size = new System.Drawing.Size(595, 27);
            this.btnPractice.TabIndex = 2;
            this.btnPractice.Text = "Start";
            this.btnPractice.UseVisualStyleBackColor = true;
            this.btnPractice.Click += new System.EventHandler(this.BtnPractice_Click);
            // 
            // txtGuess
            // 
            this.txtGuess.Enabled = false;
            this.txtGuess.Location = new System.Drawing.Point(190, 64);
            this.txtGuess.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(318, 23);
            this.txtGuess.TabIndex = 1;
            this.txtGuess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGuess_KeyDown);
            // 
            // lblPractice
            // 
            this.lblPractice.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPractice.Location = new System.Drawing.Point(17, 19);
            this.lblPractice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPractice.Name = "lblPractice";
            this.lblPractice.Size = new System.Drawing.Size(735, 33);
            this.lblPractice.TabIndex = 0;
            this.lblPractice.Text = "Load/Create a word list";
            this.lblPractice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSuccessPercentage);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblNumCorrectGuesses);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblNumWordInSession);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(965, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(179, 165);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Practice stats";
            // 
            // lblSuccessPercentage
            // 
            this.lblSuccessPercentage.Location = new System.Drawing.Point(136, 70);
            this.lblSuccessPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSuccessPercentage.Name = "lblSuccessPercentage";
            this.lblSuccessPercentage.Size = new System.Drawing.Size(43, 15);
            this.lblSuccessPercentage.TabIndex = 5;
            this.lblSuccessPercentage.Text = "0";
            this.lblSuccessPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Success rate";
            // 
            // lblNumCorrectGuesses
            // 
            this.lblNumCorrectGuesses.AutoSize = true;
            this.lblNumCorrectGuesses.Location = new System.Drawing.Point(151, 49);
            this.lblNumCorrectGuesses.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumCorrectGuesses.Name = "lblNumCorrectGuesses";
            this.lblNumCorrectGuesses.Size = new System.Drawing.Size(13, 15);
            this.lblNumCorrectGuesses.TabIndex = 3;
            this.lblNumCorrectGuesses.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 49);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "# of correct guesses: ";
            // 
            // lblNumWordInSession
            // 
            this.lblNumWordInSession.AutoSize = true;
            this.lblNumWordInSession.Location = new System.Drawing.Point(151, 26);
            this.lblNumWordInSession.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumWordInSession.Name = "lblNumWordInSession";
            this.lblNumWordInSession.Size = new System.Drawing.Size(13, 15);
            this.lblNumWordInSession.TabIndex = 1;
            this.lblNumWordInSession.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "# of words this session: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 204);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbStats);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulary";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem showWordsToolStripMenuItem;
        private GroupBox gbStats;
        private Label lblAverageWordLength;
        private Label label4;
        private Label lblNumTranslations;
        private Label label5;
        private Label lblNumLanguages;
        private Label label2;
        private Label lblNumWords;
        private Label label1;
        private GroupBox groupBox1;
        private Label lblPractice;
        private Button btnGuess;
        private Button btnPractice;
        private TextBox txtGuess;
        private GroupBox groupBox2;
        private Label lblSuccessPercentage;
        private Label label8;
        private Label lblNumCorrectGuesses;
        private Label label10;
        private Label lblNumWordInSession;
        private Label label12;
    }
}