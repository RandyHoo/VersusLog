namespace VersusLog
{
    partial class VSLogForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGetButton = new System.Windows.Forms.Button();
            this.LogGridView = new System.Windows.Forms.DataGridView();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            this.ChangeGenreLabel = new System.Windows.Forms.Label();
            this.ChangeGenreComboBox = new System.Windows.Forms.ComboBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.DeckType2Label = new System.Windows.Forms.Label();
            this.DeckType1Label = new System.Windows.Forms.Label();
            this.MydeckSmallclassLabel = new System.Windows.Forms.Label();
            this.mydeckMajorclassLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WinComboBox = new System.Windows.Forms.ComboBox();
            this.PracedenceComboBox = new System.Windows.Forms.ComboBox();
            this.MydeckMajorclassComboBox = new System.Windows.Forms.ComboBox();
            this.MydeckSmallclassComboBox = new System.Windows.Forms.ComboBox();
            this.EnemydeckMajorclassComboBox = new System.Windows.Forms.ComboBox();
            this.EnemydeckSmallclassComboBox = new System.Windows.Forms.ComboBox();
            this.FormatComboBox = new System.Windows.Forms.ComboBox();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGetButton
            // 
            this.DataGetButton.Location = new System.Drawing.Point(185, 504);
            this.DataGetButton.Name = "DataGetButton";
            this.DataGetButton.Size = new System.Drawing.Size(122, 32);
            this.DataGetButton.TabIndex = 0;
            this.DataGetButton.Text = "ログ取得";
            this.DataGetButton.UseVisualStyleBackColor = true;
            this.DataGetButton.Click += new System.EventHandler(this.DataGetButton_Click);
            // 
            // LogGridView
            // 
            this.LogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogGridView.Location = new System.Drawing.Point(318, 12);
            this.LogGridView.Name = "LogGridView";
            this.LogGridView.RowTemplate.Height = 21;
            this.LogGridView.Size = new System.Drawing.Size(780, 622);
            this.LogGridView.TabIndex = 1;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(7, 607);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 2;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // ChangeGenreLabel
            // 
            this.ChangeGenreLabel.AutoSize = true;
            this.ChangeGenreLabel.Location = new System.Drawing.Point(8, 14);
            this.ChangeGenreLabel.Name = "ChangeGenreLabel";
            this.ChangeGenreLabel.Size = new System.Drawing.Size(53, 12);
            this.ChangeGenreLabel.TabIndex = 42;
            this.ChangeGenreLabel.Text = "変更種別";
            // 
            // ChangeGenreComboBox
            // 
            this.ChangeGenreComboBox.FormattingEnabled = true;
            this.ChangeGenreComboBox.Location = new System.Drawing.Point(7, 29);
            this.ChangeGenreComboBox.Name = "ChangeGenreComboBox";
            this.ChangeGenreComboBox.Size = new System.Drawing.Size(121, 20);
            this.ChangeGenreComboBox.TabIndex = 41;
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(214, 447);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(86, 27);
            this.DoneButton.TabIndex = 36;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // DeckType2Label
            // 
            this.DeckType2Label.AutoSize = true;
            this.DeckType2Label.Location = new System.Drawing.Point(179, 212);
            this.DeckType2Label.Name = "DeckType2Label";
            this.DeckType2Label.Size = new System.Drawing.Size(98, 12);
            this.DeckType2Label.TabIndex = 35;
            this.DeckType2Label.Text = "相手デッキ・小分類";
            // 
            // DeckType1Label
            // 
            this.DeckType1Label.AutoSize = true;
            this.DeckType1Label.Location = new System.Drawing.Point(5, 212);
            this.DeckType1Label.Name = "DeckType1Label";
            this.DeckType1Label.Size = new System.Drawing.Size(98, 12);
            this.DeckType1Label.TabIndex = 34;
            this.DeckType1Label.Text = "相手デッキ・大分類";
            // 
            // MydeckSmallclassLabel
            // 
            this.MydeckSmallclassLabel.AutoSize = true;
            this.MydeckSmallclassLabel.Location = new System.Drawing.Point(177, 156);
            this.MydeckSmallclassLabel.Name = "MydeckSmallclassLabel";
            this.MydeckSmallclassLabel.Size = new System.Drawing.Size(86, 12);
            this.MydeckSmallclassLabel.TabIndex = 33;
            this.MydeckSmallclassLabel.Text = "自デッキ・小分類";
            // 
            // mydeckMajorclassLabel
            // 
            this.mydeckMajorclassLabel.AutoSize = true;
            this.mydeckMajorclassLabel.Location = new System.Drawing.Point(5, 156);
            this.mydeckMajorclassLabel.Name = "mydeckMajorclassLabel";
            this.mydeckMajorclassLabel.Size = new System.Drawing.Size(86, 12);
            this.mydeckMajorclassLabel.TabIndex = 32;
            this.mydeckMajorclassLabel.Text = "自デッキ・大分類";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(7, 78);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(126, 19);
            this.IDTextBox.TabIndex = 31;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(5, 63);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(16, 12);
            this.IDLabel.TabIndex = 30;
            this.IDLabel.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "先行後攻";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "フォーマット";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "結果";
            // 
            // WinComboBox
            // 
            this.WinComboBox.FormattingEnabled = true;
            this.WinComboBox.Location = new System.Drawing.Point(7, 280);
            this.WinComboBox.Name = "WinComboBox";
            this.WinComboBox.Size = new System.Drawing.Size(121, 20);
            this.WinComboBox.TabIndex = 49;
            // 
            // PracedenceComboBox
            // 
            this.PracedenceComboBox.FormattingEnabled = true;
            this.PracedenceComboBox.Location = new System.Drawing.Point(6, 389);
            this.PracedenceComboBox.Name = "PracedenceComboBox";
            this.PracedenceComboBox.Size = new System.Drawing.Size(121, 20);
            this.PracedenceComboBox.TabIndex = 50;
            // 
            // MydeckMajorclassComboBox
            // 
            this.MydeckMajorclassComboBox.FormattingEnabled = true;
            this.MydeckMajorclassComboBox.Location = new System.Drawing.Point(7, 171);
            this.MydeckMajorclassComboBox.Name = "MydeckMajorclassComboBox";
            this.MydeckMajorclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckMajorclassComboBox.TabIndex = 51;
            this.MydeckMajorclassComboBox.TextChanged += new System.EventHandler(this.MydeckMajorclassComboBox_TextChanged);
            // 
            // MydeckSmallclassComboBox
            // 
            this.MydeckSmallclassComboBox.FormattingEnabled = true;
            this.MydeckSmallclassComboBox.Location = new System.Drawing.Point(179, 171);
            this.MydeckSmallclassComboBox.Name = "MydeckSmallclassComboBox";
            this.MydeckSmallclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckSmallclassComboBox.TabIndex = 52;
            // 
            // EnemydeckMajorclassComboBox
            // 
            this.EnemydeckMajorclassComboBox.FormattingEnabled = true;
            this.EnemydeckMajorclassComboBox.Location = new System.Drawing.Point(7, 227);
            this.EnemydeckMajorclassComboBox.Name = "EnemydeckMajorclassComboBox";
            this.EnemydeckMajorclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.EnemydeckMajorclassComboBox.TabIndex = 53;
            this.EnemydeckMajorclassComboBox.TextChanged += new System.EventHandler(this.EnemydeckMajorclassComboBox_TextChanged);
            // 
            // EnemydeckSmallclassComboBox
            // 
            this.EnemydeckSmallclassComboBox.FormattingEnabled = true;
            this.EnemydeckSmallclassComboBox.Location = new System.Drawing.Point(179, 227);
            this.EnemydeckSmallclassComboBox.Name = "EnemydeckSmallclassComboBox";
            this.EnemydeckSmallclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.EnemydeckSmallclassComboBox.TabIndex = 54;
            // 
            // FormatComboBox
            // 
            this.FormatComboBox.FormattingEnabled = true;
            this.FormatComboBox.Location = new System.Drawing.Point(7, 333);
            this.FormatComboBox.Name = "FormatComboBox";
            this.FormatComboBox.Size = new System.Drawing.Size(121, 20);
            this.FormatComboBox.TabIndex = 55;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(7, 123);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(126, 19);
            this.DateTextBox.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "日付";
            // 
            // VSLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 658);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FormatComboBox);
            this.Controls.Add(this.EnemydeckSmallclassComboBox);
            this.Controls.Add(this.EnemydeckMajorclassComboBox);
            this.Controls.Add(this.MydeckSmallclassComboBox);
            this.Controls.Add(this.MydeckMajorclassComboBox);
            this.Controls.Add(this.PracedenceComboBox);
            this.Controls.Add(this.WinComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeGenreLabel);
            this.Controls.Add(this.ChangeGenreComboBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DeckType2Label);
            this.Controls.Add(this.DeckType1Label);
            this.Controls.Add(this.MydeckSmallclassLabel);
            this.Controls.Add(this.mydeckMajorclassLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.LogGridView);
            this.Controls.Add(this.DataGetButton);
            this.Name = "VSLogForm";
            this.Text = "VersusLog -戦績ログ-";
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DataGetButton;
        private System.Windows.Forms.DataGridView LogGridView;
        private System.Windows.Forms.Button BackMainMenuButton;
        private System.Windows.Forms.Label ChangeGenreLabel;
        private System.Windows.Forms.ComboBox ChangeGenreComboBox;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label DeckType2Label;
        private System.Windows.Forms.Label DeckType1Label;
        private System.Windows.Forms.Label MydeckSmallclassLabel;
        private System.Windows.Forms.Label mydeckMajorclassLabel;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox WinComboBox;
        private System.Windows.Forms.ComboBox PracedenceComboBox;
        private System.Windows.Forms.ComboBox MydeckMajorclassComboBox;
        private System.Windows.Forms.ComboBox MydeckSmallclassComboBox;
        private System.Windows.Forms.ComboBox EnemydeckMajorclassComboBox;
        private System.Windows.Forms.ComboBox EnemydeckSmallclassComboBox;
        private System.Windows.Forms.ComboBox FormatComboBox;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.Label label4;
    }
}

