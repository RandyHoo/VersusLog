namespace VersusLog
{
    partial class MainMenuForm
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
            this.MCDeckRecordButton = new System.Windows.Forms.Button();
            this.MCInsertLogButton = new System.Windows.Forms.Button();
            this.MCVSLogButton = new System.Windows.Forms.Button();
            this.MCDeckAnalyzeButton = new System.Windows.Forms.Button();
            this.MCDeckMasterChangeButton = new System.Windows.Forms.Button();
            this.MCFormatMasterChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MCDeckRecordButton
            // 
            this.MCDeckRecordButton.Location = new System.Drawing.Point(169, 48);
            this.MCDeckRecordButton.Name = "MCDeckRecordButton";
            this.MCDeckRecordButton.Size = new System.Drawing.Size(125, 30);
            this.MCDeckRecordButton.TabIndex = 5;
            this.MCDeckRecordButton.Text = "デッキ戦績";
            this.MCDeckRecordButton.UseVisualStyleBackColor = true;
            this.MCDeckRecordButton.Click += new System.EventHandler(this.MCDeckRecordButton_Click);
            // 
            // MCInsertLogButton
            // 
            this.MCInsertLogButton.Location = new System.Drawing.Point(12, 12);
            this.MCInsertLogButton.Name = "MCInsertLogButton";
            this.MCInsertLogButton.Size = new System.Drawing.Size(125, 30);
            this.MCInsertLogButton.TabIndex = 4;
            this.MCInsertLogButton.Text = "ログ入力";
            this.MCInsertLogButton.UseVisualStyleBackColor = true;
            this.MCInsertLogButton.Click += new System.EventHandler(this.MCInsertLogButton_Click);
            // 
            // MCVSLogButton
            // 
            this.MCVSLogButton.Location = new System.Drawing.Point(169, 12);
            this.MCVSLogButton.Name = "MCVSLogButton";
            this.MCVSLogButton.Size = new System.Drawing.Size(125, 31);
            this.MCVSLogButton.TabIndex = 6;
            this.MCVSLogButton.Text = "戦績ログ";
            this.MCVSLogButton.UseVisualStyleBackColor = true;
            this.MCVSLogButton.Click += new System.EventHandler(this.MCVSLogButton_Click);
            // 
            // MCDeckAnalyzeButton
            // 
            this.MCDeckAnalyzeButton.Location = new System.Drawing.Point(169, 84);
            this.MCDeckAnalyzeButton.Name = "MCDeckAnalyzeButton";
            this.MCDeckAnalyzeButton.Size = new System.Drawing.Size(125, 30);
            this.MCDeckAnalyzeButton.TabIndex = 7;
            this.MCDeckAnalyzeButton.Text = "メタ分析";
            this.MCDeckAnalyzeButton.UseVisualStyleBackColor = true;
            this.MCDeckAnalyzeButton.Click += new System.EventHandler(this.MCDeckAnalyzeButton_Click);
            // 
            // MCDeckMasterChangeButton
            // 
            this.MCDeckMasterChangeButton.Location = new System.Drawing.Point(12, 119);
            this.MCDeckMasterChangeButton.Name = "MCDeckMasterChangeButton";
            this.MCDeckMasterChangeButton.Size = new System.Drawing.Size(125, 30);
            this.MCDeckMasterChangeButton.TabIndex = 8;
            this.MCDeckMasterChangeButton.Text = "デッキマスタ変更";
            this.MCDeckMasterChangeButton.UseVisualStyleBackColor = true;
            this.MCDeckMasterChangeButton.Click += new System.EventHandler(this.MCDeckMasterChangeButton_Click);
            // 
            // MCFormatMasterChangeButton
            // 
            this.MCFormatMasterChangeButton.Location = new System.Drawing.Point(12, 162);
            this.MCFormatMasterChangeButton.Name = "MCFormatMasterChangeButton";
            this.MCFormatMasterChangeButton.Size = new System.Drawing.Size(125, 30);
            this.MCFormatMasterChangeButton.TabIndex = 9;
            this.MCFormatMasterChangeButton.Text = "フォーマットマスタ変更";
            this.MCFormatMasterChangeButton.UseVisualStyleBackColor = true;
            this.MCFormatMasterChangeButton.Click += new System.EventHandler(this.MCFormatMasterChangeButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 204);
            this.Controls.Add(this.MCFormatMasterChangeButton);
            this.Controls.Add(this.MCDeckMasterChangeButton);
            this.Controls.Add(this.MCDeckAnalyzeButton);
            this.Controls.Add(this.MCVSLogButton);
            this.Controls.Add(this.MCDeckRecordButton);
            this.Controls.Add(this.MCInsertLogButton);
            this.Name = "MainMenuForm";
            this.Text = "VersusLog -メインメニュー-";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MCDeckRecordButton;
        private System.Windows.Forms.Button MCInsertLogButton;
        private System.Windows.Forms.Button MCVSLogButton;
        private System.Windows.Forms.Button MCDeckAnalyzeButton;
        private System.Windows.Forms.Button MCDeckMasterChangeButton;
        private System.Windows.Forms.Button MCFormatMasterChangeButton;
    }
}