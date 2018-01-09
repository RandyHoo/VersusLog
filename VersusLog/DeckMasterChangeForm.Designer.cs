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
            ((System.ComponentModel.ISupportInitialize)(this.DeckMasterGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DeckMasterGridView
            // 
            this.DeckMasterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeckMasterGridView.Location = new System.Drawing.Point(12, 12);
            this.DeckMasterGridView.Name = "DeckMasterGridView";
            this.DeckMasterGridView.RowTemplate.Height = 21;
            this.DeckMasterGridView.Size = new System.Drawing.Size(778, 281);
            this.DeckMasterGridView.TabIndex = 2;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(668, 483);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 3;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // DeckType2Label
            // 
            this.DeckType2Label.AutoSize = true;
            this.DeckType2Label.Location = new System.Drawing.Point(186, 472);
            this.DeckType2Label.Name = "DeckType2Label";
            this.DeckType2Label.Size = new System.Drawing.Size(64, 12);
            this.DeckType2Label.TabIndex = 20;
            this.DeckType2Label.Text = "デッキタイプ2";
            // 
            // DeckType1Label
            // 
            this.DeckType1Label.AutoSize = true;
            this.DeckType1Label.Location = new System.Drawing.Point(12, 472);
            this.DeckType1Label.Name = "DeckType1Label";
            this.DeckType1Label.Size = new System.Drawing.Size(64, 12);
            this.DeckType1Label.TabIndex = 18;
            this.DeckType1Label.Text = "デッキタイプ1";
            // 
            // DeckSmallclassLabel
            // 
            this.DeckSmallclassLabel.AutoSize = true;
            this.DeckSmallclassLabel.Location = new System.Drawing.Point(184, 416);
            this.DeckSmallclassLabel.Name = "DeckSmallclassLabel";
            this.DeckSmallclassLabel.Size = new System.Drawing.Size(74, 12);
            this.DeckSmallclassLabel.TabIndex = 15;
            this.DeckSmallclassLabel.Text = "デッキ・小分類";
            // 
            // DeckMajorclassLabel
            // 
            this.DeckMajorclassLabel.AutoSize = true;
            this.DeckMajorclassLabel.Location = new System.Drawing.Point(12, 416);
            this.DeckMajorclassLabel.Name = "DeckMajorclassLabel";
            this.DeckMajorclassLabel.Size = new System.Drawing.Size(74, 12);
            this.DeckMajorclassLabel.TabIndex = 14;
            this.DeckMajorclassLabel.Text = "デッキ・大分類";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(14, 378);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(126, 19);
            this.IDTextBox.TabIndex = 12;
            this.IDTextBox.TextChanged += new System.EventHandler(this.IDTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(12, 363);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(16, 12);
            this.IDLabel.TabIndex = 11;
            this.IDLabel.Text = "ID";
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(360, 487);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(86, 27);
            this.DoneButton.TabIndex = 23;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // MajorclassTextBox
            // 
            this.MajorclassTextBox.Location = new System.Drawing.Point(14, 432);
            this.MajorclassTextBox.Name = "MajorclassTextBox";
            this.MajorclassTextBox.Size = new System.Drawing.Size(126, 19);
            this.MajorclassTextBox.TabIndex = 24;
            // 
            // SmallclassTextBox
            // 
            this.SmallclassTextBox.Location = new System.Drawing.Point(186, 432);
            this.SmallclassTextBox.Name = "SmallclassTextBox";
            this.SmallclassTextBox.Size = new System.Drawing.Size(126, 19);
            this.SmallclassTextBox.TabIndex = 25;
            // 
            // Decktype1TextBox
            // 
            this.Decktype1TextBox.Location = new System.Drawing.Point(14, 491);
            this.Decktype1TextBox.Name = "Decktype1TextBox";
            this.Decktype1TextBox.Size = new System.Drawing.Size(126, 19);
            this.Decktype1TextBox.TabIndex = 26;
            // 
            // Decktype2TextBox
            // 
            this.Decktype2TextBox.Location = new System.Drawing.Point(186, 491);
            this.Decktype2TextBox.Name = "Decktype2TextBox";
            this.Decktype2TextBox.Size = new System.Drawing.Size(126, 19);
            this.Decktype2TextBox.TabIndex = 27;
            // 
            // ChangeGenreComboBox
            // 
            this.ChangeGenreComboBox.FormattingEnabled = true;
            this.ChangeGenreComboBox.Location = new System.Drawing.Point(12, 321);
            this.ChangeGenreComboBox.Name = "ChangeGenreComboBox";
            this.ChangeGenreComboBox.Size = new System.Drawing.Size(121, 20);
            this.ChangeGenreComboBox.TabIndex = 28;
            this.ChangeGenreComboBox.TextChanged += new System.EventHandler(this.ChangeGenreComboBox_TextChanged);
            // 
            // ChangeGenreLabel
            // 
            this.ChangeGenreLabel.AutoSize = true;
            this.ChangeGenreLabel.Location = new System.Drawing.Point(13, 306);
            this.ChangeGenreLabel.Name = "ChangeGenreLabel";
            this.ChangeGenreLabel.Size = new System.Drawing.Size(53, 12);
            this.ChangeGenreLabel.TabIndex = 29;
            this.ChangeGenreLabel.Text = "変更種別";
            // 
            // UpdateViewButton
            // 
            this.UpdateViewButton.Location = new System.Drawing.Point(668, 301);
            this.UpdateViewButton.Name = "UpdateViewButton";
            this.UpdateViewButton.Size = new System.Drawing.Size(122, 28);
            this.UpdateViewButton.TabIndex = 30;
            this.UpdateViewButton.Text = "表示更新";
            this.UpdateViewButton.UseVisualStyleBackColor = true;
            this.UpdateViewButton.Click += new System.EventHandler(this.UpdateViewButton_Click);
            // 
            // DeckMasterChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 524);
            this.Controls.Add(this.UpdateViewButton);
            this.Controls.Add(this.ChangeGenreLabel);
            this.Controls.Add(this.ChangeGenreComboBox);
            this.Controls.Add(this.Decktype2TextBox);
            this.Controls.Add(this.Decktype1TextBox);
            this.Controls.Add(this.SmallclassTextBox);
            this.Controls.Add(this.MajorclassTextBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DeckType2Label);
            this.Controls.Add(this.DeckType1Label);
            this.Controls.Add(this.DeckSmallclassLabel);
            this.Controls.Add(this.DeckMajorclassLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.DeckMasterGridView);
            this.Name = "DeckMasterChangeForm";
            this.Text = "VersusLog -デッキマスタ変更-";
            ((System.ComponentModel.ISupportInitialize)(this.DeckMasterGridView)).EndInit();
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
    }
}