namespace VersusLog
{
    partial class InsertLogForm
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
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.MydeckMajorclassComboBox = new System.Windows.Forms.ComboBox();
            this.MydeckMajorclassLabel = new System.Windows.Forms.Label();
            this.MydeckSmallclassLabel = new System.Windows.Forms.Label();
            this.MydeckSmallclassComboBox = new System.Windows.Forms.ComboBox();
            this.EnemydeckMajorclassComboBox = new System.Windows.Forms.ComboBox();
            this.EnemydeckMajorclassLabel = new System.Windows.Forms.Label();
            this.EnemydeckSmallclassLabel = new System.Windows.Forms.Label();
            this.EnemydeckSmallclassComboBox = new System.Windows.Forms.ComboBox();
            this.WinLabel = new System.Windows.Forms.Label();
            this.WinComboBox = new System.Windows.Forms.ComboBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.FormatComboBox = new System.Windows.Forms.ComboBox();
            this.PracedenceLabel = new System.Windows.Forms.Label();
            this.PracedenceComboBox = new System.Windows.Forms.ComboBox();
            this.LogInsertButton = new System.Windows.Forms.Button();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(12, 9);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(29, 12);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "日付";
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(14, 24);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(126, 19);
            this.DateTextBox.TabIndex = 2;
            // 
            // MydeckMajorclassComboBox
            // 
            this.MydeckMajorclassComboBox.FormattingEnabled = true;
            this.MydeckMajorclassComboBox.Location = new System.Drawing.Point(12, 77);
            this.MydeckMajorclassComboBox.Name = "MydeckMajorclassComboBox";
            this.MydeckMajorclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckMajorclassComboBox.TabIndex = 3;
            this.MydeckMajorclassComboBox.TextChanged += new System.EventHandler(this.MydeckMajorclassComboBox_TextChanged);
            // 
            // MydeckMajorclassLabel
            // 
            this.MydeckMajorclassLabel.AutoSize = true;
            this.MydeckMajorclassLabel.Location = new System.Drawing.Point(12, 62);
            this.MydeckMajorclassLabel.Name = "MydeckMajorclassLabel";
            this.MydeckMajorclassLabel.Size = new System.Drawing.Size(86, 12);
            this.MydeckMajorclassLabel.TabIndex = 4;
            this.MydeckMajorclassLabel.Text = "自デッキ・大分類";
            // 
            // MydeckSmallclassLabel
            // 
            this.MydeckSmallclassLabel.AutoSize = true;
            this.MydeckSmallclassLabel.Location = new System.Drawing.Point(184, 62);
            this.MydeckSmallclassLabel.Name = "MydeckSmallclassLabel";
            this.MydeckSmallclassLabel.Size = new System.Drawing.Size(86, 12);
            this.MydeckSmallclassLabel.TabIndex = 5;
            this.MydeckSmallclassLabel.Text = "自デッキ・小分類";
            // 
            // MydeckSmallclassComboBox
            // 
            this.MydeckSmallclassComboBox.FormattingEnabled = true;
            this.MydeckSmallclassComboBox.Location = new System.Drawing.Point(186, 77);
            this.MydeckSmallclassComboBox.Name = "MydeckSmallclassComboBox";
            this.MydeckSmallclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckSmallclassComboBox.TabIndex = 6;
            // 
            // EnemydeckMajorclassComboBox
            // 
            this.EnemydeckMajorclassComboBox.FormattingEnabled = true;
            this.EnemydeckMajorclassComboBox.Location = new System.Drawing.Point(12, 133);
            this.EnemydeckMajorclassComboBox.Name = "EnemydeckMajorclassComboBox";
            this.EnemydeckMajorclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.EnemydeckMajorclassComboBox.TabIndex = 7;
            this.EnemydeckMajorclassComboBox.TextChanged += new System.EventHandler(this.EnemydeckMajorclassComboBox_TextChanged);
            // 
            // EnemydeckMajorclassLabel
            // 
            this.EnemydeckMajorclassLabel.AutoSize = true;
            this.EnemydeckMajorclassLabel.Location = new System.Drawing.Point(12, 118);
            this.EnemydeckMajorclassLabel.Name = "EnemydeckMajorclassLabel";
            this.EnemydeckMajorclassLabel.Size = new System.Drawing.Size(98, 12);
            this.EnemydeckMajorclassLabel.TabIndex = 8;
            this.EnemydeckMajorclassLabel.Text = "相手デッキ・大分類";
            // 
            // EnemydeckSmallclassLabel
            // 
            this.EnemydeckSmallclassLabel.AutoSize = true;
            this.EnemydeckSmallclassLabel.Location = new System.Drawing.Point(186, 118);
            this.EnemydeckSmallclassLabel.Name = "EnemydeckSmallclassLabel";
            this.EnemydeckSmallclassLabel.Size = new System.Drawing.Size(98, 12);
            this.EnemydeckSmallclassLabel.TabIndex = 10;
            this.EnemydeckSmallclassLabel.Text = "相手デッキ・小分類";
            // 
            // EnemydeckSmallclassComboBox
            // 
            this.EnemydeckSmallclassComboBox.FormattingEnabled = true;
            this.EnemydeckSmallclassComboBox.Location = new System.Drawing.Point(186, 133);
            this.EnemydeckSmallclassComboBox.Name = "EnemydeckSmallclassComboBox";
            this.EnemydeckSmallclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.EnemydeckSmallclassComboBox.TabIndex = 9;
            // 
            // WinLabel
            // 
            this.WinLabel.AutoSize = true;
            this.WinLabel.Location = new System.Drawing.Point(10, 167);
            this.WinLabel.Name = "WinLabel";
            this.WinLabel.Size = new System.Drawing.Size(29, 12);
            this.WinLabel.TabIndex = 12;
            this.WinLabel.Text = "結果";
            // 
            // WinComboBox
            // 
            this.WinComboBox.FormattingEnabled = true;
            this.WinComboBox.Location = new System.Drawing.Point(12, 182);
            this.WinComboBox.Name = "WinComboBox";
            this.WinComboBox.Size = new System.Drawing.Size(121, 20);
            this.WinComboBox.TabIndex = 11;
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(10, 218);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(55, 12);
            this.FormatLabel.TabIndex = 14;
            this.FormatLabel.Text = "フォーマット";
            // 
            // FormatComboBox
            // 
            this.FormatComboBox.FormattingEnabled = true;
            this.FormatComboBox.Location = new System.Drawing.Point(12, 233);
            this.FormatComboBox.Name = "FormatComboBox";
            this.FormatComboBox.Size = new System.Drawing.Size(121, 20);
            this.FormatComboBox.TabIndex = 13;
            // 
            // PracedenceLabel
            // 
            this.PracedenceLabel.AutoSize = true;
            this.PracedenceLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PracedenceLabel.Location = new System.Drawing.Point(10, 265);
            this.PracedenceLabel.Name = "PracedenceLabel";
            this.PracedenceLabel.Size = new System.Drawing.Size(53, 12);
            this.PracedenceLabel.TabIndex = 16;
            this.PracedenceLabel.Text = "先行後攻";
            // 
            // PracedenceComboBox
            // 
            this.PracedenceComboBox.FormattingEnabled = true;
            this.PracedenceComboBox.Location = new System.Drawing.Point(12, 280);
            this.PracedenceComboBox.Name = "PracedenceComboBox";
            this.PracedenceComboBox.Size = new System.Drawing.Size(121, 20);
            this.PracedenceComboBox.TabIndex = 15;
            // 
            // LogInsertButton
            // 
            this.LogInsertButton.Location = new System.Drawing.Point(333, 293);
            this.LogInsertButton.Name = "LogInsertButton";
            this.LogInsertButton.Size = new System.Drawing.Size(125, 31);
            this.LogInsertButton.TabIndex = 17;
            this.LogInsertButton.Text = "ログ入力";
            this.LogInsertButton.UseVisualStyleBackColor = true;
            this.LogInsertButton.Click += new System.EventHandler(this.LogInsertButton_Click);
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(336, 12);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 18;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // InsertLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 336);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.LogInsertButton);
            this.Controls.Add(this.PracedenceLabel);
            this.Controls.Add(this.PracedenceComboBox);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.FormatComboBox);
            this.Controls.Add(this.WinLabel);
            this.Controls.Add(this.WinComboBox);
            this.Controls.Add(this.EnemydeckSmallclassLabel);
            this.Controls.Add(this.EnemydeckSmallclassComboBox);
            this.Controls.Add(this.EnemydeckMajorclassLabel);
            this.Controls.Add(this.EnemydeckMajorclassComboBox);
            this.Controls.Add(this.MydeckSmallclassComboBox);
            this.Controls.Add(this.MydeckSmallclassLabel);
            this.Controls.Add(this.MydeckMajorclassLabel);
            this.Controls.Add(this.MydeckMajorclassComboBox);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.DateLabel);
            this.Name = "InsertLogForm";
            this.Text = "VersusLog -ログ入力-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.ComboBox MydeckMajorclassComboBox;
        private System.Windows.Forms.Label MydeckMajorclassLabel;
        private System.Windows.Forms.Label MydeckSmallclassLabel;
        private System.Windows.Forms.ComboBox MydeckSmallclassComboBox;
        private System.Windows.Forms.ComboBox EnemydeckMajorclassComboBox;
        private System.Windows.Forms.Label EnemydeckMajorclassLabel;
        private System.Windows.Forms.Label EnemydeckSmallclassLabel;
        private System.Windows.Forms.ComboBox EnemydeckSmallclassComboBox;
        private System.Windows.Forms.Label WinLabel;
        private System.Windows.Forms.ComboBox WinComboBox;
        private System.Windows.Forms.Label FormatLabel;
        private System.Windows.Forms.ComboBox FormatComboBox;
        private System.Windows.Forms.Label PracedenceLabel;
        private System.Windows.Forms.ComboBox PracedenceComboBox;
        private System.Windows.Forms.Button LogInsertButton;
        private System.Windows.Forms.Button BackMainMenuButton;
    }
}