namespace VersusLog
{
    partial class DeckMasterChangeForm
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
            this.DeckMasterGridView = new System.Windows.Forms.DataGridView();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            this.DeckType2Label = new System.Windows.Forms.Label();
            this.DeckType1Label = new System.Windows.Forms.Label();
            this.DeckSmallclassLabel = new System.Windows.Forms.Label();
            this.DeckMajorclassLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.MajorclassTextBox = new System.Windows.Forms.TextBox();
            this.SmallclassTextBox = new System.Windows.Forms.TextBox();
            this.Decktype1TextBox = new System.Windows.Forms.TextBox();
            this.Decktype2TextBox = new System.Windows.Forms.TextBox();
            this.ChangeGenreComboBox = new System.Windows.Forms.ComboBox();
            this.ChangeGenreLabel = new System.Windows.Forms.Label();
            this.UpdateViewButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeckMasterGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeckMasterGridView
            // 
            this.DeckMasterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeckMasterGridView.Location = new System.Drawing.Point(14, 15);
            this.DeckMasterGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeckMasterGridView.Name = "DeckMasterGridView";
            this.DeckMasterGridView.RowTemplate.Height = 21;
            this.DeckMasterGridView.Size = new System.Drawing.Size(586, 351);
            this.DeckMasterGridView.TabIndex = 2;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(457, 719);
            this.BackMainMenuButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(142, 34);
            this.BackMainMenuButton.TabIndex = 3;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // DeckType2Label
            // 
            this.DeckType2Label.AutoSize = true;
            this.DeckType2Label.Location = new System.Drawing.Point(208, 160);
            this.DeckType2Label.Name = "DeckType2Label";
            this.DeckType2Label.Size = new System.Drawing.Size(67, 15);
            this.DeckType2Label.TabIndex = 20;
            this.DeckType2Label.Text = "デッキタイプ2";
            // 
            // DeckType1Label
            // 
            this.DeckType1Label.AutoSize = true;
            this.DeckType1Label.Location = new System.Drawing.Point(5, 160);
            this.DeckType1Label.Name = "DeckType1Label";
            this.DeckType1Label.Size = new System.Drawing.Size(67, 15);
            this.DeckType1Label.TabIndex = 18;
            this.DeckType1Label.Text = "デッキタイプ1";
            // 
            // DeckSmallclassLabel
            // 
            this.DeckSmallclassLabel.AutoSize = true;
            this.DeckSmallclassLabel.Location = new System.Drawing.Point(205, 90);
            this.DeckSmallclassLabel.Name = "DeckSmallclassLabel";
            this.DeckSmallclassLabel.Size = new System.Drawing.Size(76, 15);
            this.DeckSmallclassLabel.TabIndex = 15;
            this.DeckSmallclassLabel.Text = "デッキ・小分類";
            // 
            // DeckMajorclassLabel
            // 
            this.DeckMajorclassLabel.AutoSize = true;
            this.DeckMajorclassLabel.Location = new System.Drawing.Point(5, 90);
            this.DeckMajorclassLabel.Name = "DeckMajorclassLabel";
            this.DeckMajorclassLabel.Size = new System.Drawing.Size(76, 15);
            this.DeckMajorclassLabel.TabIndex = 14;
            this.DeckMajorclassLabel.Text = "デッキ・大分類";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(7, 42);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(146, 23);
            this.IDTextBox.TabIndex = 12;
            this.IDTextBox.TextChanged += new System.EventHandler(this.IDTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(5, 24);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 15);
            this.IDLabel.TabIndex = 11;
            this.IDLabel.Text = "ID";
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(285, 684);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(100, 34);
            this.DoneButton.TabIndex = 23;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // MajorclassTextBox
            // 
            this.MajorclassTextBox.Location = new System.Drawing.Point(7, 110);
            this.MajorclassTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MajorclassTextBox.Name = "MajorclassTextBox";
            this.MajorclassTextBox.Size = new System.Drawing.Size(146, 23);
            this.MajorclassTextBox.TabIndex = 24;
            // 
            // SmallclassTextBox
            // 
            this.SmallclassTextBox.Location = new System.Drawing.Point(208, 110);
            this.SmallclassTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SmallclassTextBox.Name = "SmallclassTextBox";
            this.SmallclassTextBox.Size = new System.Drawing.Size(146, 23);
            this.SmallclassTextBox.TabIndex = 25;
            // 
            // Decktype1TextBox
            // 
            this.Decktype1TextBox.Location = new System.Drawing.Point(7, 184);
            this.Decktype1TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Decktype1TextBox.Name = "Decktype1TextBox";
            this.Decktype1TextBox.Size = new System.Drawing.Size(146, 23);
            this.Decktype1TextBox.TabIndex = 26;
            // 
            // Decktype2TextBox
            // 
            this.Decktype2TextBox.Location = new System.Drawing.Point(208, 184);
            this.Decktype2TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Decktype2TextBox.Name = "Decktype2TextBox";
            this.Decktype2TextBox.Size = new System.Drawing.Size(146, 23);
            this.Decktype2TextBox.TabIndex = 27;
            // 
            // ChangeGenreComboBox
            // 
            this.ChangeGenreComboBox.FormattingEnabled = true;
            this.ChangeGenreComboBox.Location = new System.Drawing.Point(14, 401);
            this.ChangeGenreComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChangeGenreComboBox.Name = "ChangeGenreComboBox";
            this.ChangeGenreComboBox.Size = new System.Drawing.Size(140, 23);
            this.ChangeGenreComboBox.TabIndex = 28;
            this.ChangeGenreComboBox.TextChanged += new System.EventHandler(this.ChangeGenreComboBox_TextChanged);
            // 
            // ChangeGenreLabel
            // 
            this.ChangeGenreLabel.AutoSize = true;
            this.ChangeGenreLabel.Location = new System.Drawing.Point(15, 382);
            this.ChangeGenreLabel.Name = "ChangeGenreLabel";
            this.ChangeGenreLabel.Size = new System.Drawing.Size(55, 15);
            this.ChangeGenreLabel.TabIndex = 29;
            this.ChangeGenreLabel.Text = "変更種別";
            // 
            // UpdateViewButton
            // 
            this.UpdateViewButton.Location = new System.Drawing.Point(457, 374);
            this.UpdateViewButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateViewButton.Name = "UpdateViewButton";
            this.UpdateViewButton.Size = new System.Drawing.Size(142, 35);
            this.UpdateViewButton.TabIndex = 30;
            this.UpdateViewButton.Text = "表示更新";
            this.UpdateViewButton.UseVisualStyleBackColor = true;
            this.UpdateViewButton.Click += new System.EventHandler(this.UpdateViewButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IDTextBox);
            this.groupBox1.Controls.Add(this.IDLabel);
            this.groupBox1.Controls.Add(this.DeckMajorclassLabel);
            this.groupBox1.Controls.Add(this.DeckSmallclassLabel);
            this.groupBox1.Controls.Add(this.Decktype2TextBox);
            this.groupBox1.Controls.Add(this.DeckType1Label);
            this.groupBox1.Controls.Add(this.Decktype1TextBox);
            this.groupBox1.Controls.Add(this.DeckType2Label);
            this.groupBox1.Controls.Add(this.SmallclassTextBox);
            this.groupBox1.Controls.Add(this.MajorclassTextBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 448);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(371, 229);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入力";
            // 
            // DeckMasterChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 768);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UpdateViewButton);
            this.Controls.Add(this.ChangeGenreLabel);
            this.Controls.Add(this.ChangeGenreComboBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.DeckMasterGridView);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeckMasterChangeForm";
            this.Text = "VersusLog -デッキマスタ変更-";
            ((System.ComponentModel.ISupportInitialize)(this.DeckMasterGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DeckMasterGridView;
        private System.Windows.Forms.Button BackMainMenuButton;
        private System.Windows.Forms.Label DeckType2Label;
        private System.Windows.Forms.Label DeckType1Label;
        private System.Windows.Forms.Label DeckSmallclassLabel;
        private System.Windows.Forms.Label DeckMajorclassLabel;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.TextBox MajorclassTextBox;
        private System.Windows.Forms.TextBox SmallclassTextBox;
        private System.Windows.Forms.TextBox Decktype1TextBox;
        private System.Windows.Forms.TextBox Decktype2TextBox;
        private System.Windows.Forms.ComboBox ChangeGenreComboBox;
        private System.Windows.Forms.Label ChangeGenreLabel;
        private System.Windows.Forms.Button UpdateViewButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}