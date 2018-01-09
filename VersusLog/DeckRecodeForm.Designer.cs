namespace VersusLog
{
    partial class DeckRecordForm
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
            this.MydeckSmallclassComboBox = new System.Windows.Forms.ComboBox();
            this.MydeckSmallclassLabel = new System.Windows.Forms.Label();
            this.MydeckMajorclassLabel = new System.Windows.Forms.Label();
            this.MydeckMajorclassComboBox = new System.Windows.Forms.ComboBox();
            this.GetDeckRecordButton = new System.Windows.Forms.Button();
            this.DeckRecodeView = new System.Windows.Forms.DataGridView();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DeckRecodeView)).BeginInit();
            this.SuspendLayout();
            // 
            // MydeckSmallclassComboBox
            // 
            this.MydeckSmallclassComboBox.FormattingEnabled = true;
            this.MydeckSmallclassComboBox.Location = new System.Drawing.Point(186, 33);
            this.MydeckSmallclassComboBox.Name = "MydeckSmallclassComboBox";
            this.MydeckSmallclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckSmallclassComboBox.TabIndex = 10;
            // 
            // MydeckSmallclassLabel
            // 
            this.MydeckSmallclassLabel.AutoSize = true;
            this.MydeckSmallclassLabel.Location = new System.Drawing.Point(184, 18);
            this.MydeckSmallclassLabel.Name = "MydeckSmallclassLabel";
            this.MydeckSmallclassLabel.Size = new System.Drawing.Size(86, 12);
            this.MydeckSmallclassLabel.TabIndex = 9;
            this.MydeckSmallclassLabel.Text = "自デッキ・小分類";
            // 
            // MydeckMajorclassLabel
            // 
            this.MydeckMajorclassLabel.AutoSize = true;
            this.MydeckMajorclassLabel.Location = new System.Drawing.Point(12, 18);
            this.MydeckMajorclassLabel.Name = "MydeckMajorclassLabel";
            this.MydeckMajorclassLabel.Size = new System.Drawing.Size(86, 12);
            this.MydeckMajorclassLabel.TabIndex = 8;
            this.MydeckMajorclassLabel.Text = "自デッキ・大分類";
            // 
            // MydeckMajorclassComboBox
            // 
            this.MydeckMajorclassComboBox.FormattingEnabled = true;
            this.MydeckMajorclassComboBox.Location = new System.Drawing.Point(12, 33);
            this.MydeckMajorclassComboBox.Name = "MydeckMajorclassComboBox";
            this.MydeckMajorclassComboBox.Size = new System.Drawing.Size(121, 20);
            this.MydeckMajorclassComboBox.TabIndex = 7;
            this.MydeckMajorclassComboBox.TextChanged += new System.EventHandler(this.MydeckMajorclassComboBox_TextChanged);
            // 
            // GetDeckRecordButton
            // 
            this.GetDeckRecordButton.Location = new System.Drawing.Point(351, 46);
            this.GetDeckRecordButton.Name = "GetDeckRecordButton";
            this.GetDeckRecordButton.Size = new System.Drawing.Size(82, 36);
            this.GetDeckRecordButton.TabIndex = 15;
            this.GetDeckRecordButton.Text = "戦績表示";
            this.GetDeckRecordButton.UseVisualStyleBackColor = true;
            this.GetDeckRecordButton.Click += new System.EventHandler(this.GetDeckRecordButton_Click);
            // 
            // DeckRecodeView
            // 
            this.DeckRecodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeckRecodeView.Location = new System.Drawing.Point(12, 88);
            this.DeckRecodeView.Name = "DeckRecodeView";
            this.DeckRecodeView.RowTemplate.Height = 21;
            this.DeckRecodeView.Size = new System.Drawing.Size(562, 425);
            this.DeckRecodeView.TabIndex = 16;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(452, 11);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 17;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // DeckRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 525);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.DeckRecodeView);
            this.Controls.Add(this.GetDeckRecordButton);
            this.Controls.Add(this.MydeckSmallclassComboBox);
            this.Controls.Add(this.MydeckSmallclassLabel);
            this.Controls.Add(this.MydeckMajorclassLabel);
            this.Controls.Add(this.MydeckMajorclassComboBox);
            this.Name = "DeckRecordForm";
            this.Text = "VersusLog -デッキ戦績-";
            ((System.ComponentModel.ISupportInitialize)(this.DeckRecodeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox MydeckSmallclassComboBox;
        private System.Windows.Forms.Label MydeckSmallclassLabel;
        private System.Windows.Forms.Label MydeckMajorclassLabel;
        private System.Windows.Forms.ComboBox MydeckMajorclassComboBox;
        private System.Windows.Forms.Button GetDeckRecordButton;
        private System.Windows.Forms.DataGridView DeckRecodeView;
        private System.Windows.Forms.Button BackMainMenuButton;
    }
}