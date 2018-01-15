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
            this.MCVSLogButton = new System.Windows.Forms.Button();
            this.MCDeckMasterChangeButton = new System.Windows.Forms.Button();
            this.MCFormatMasterChangeButton = new System.Windows.Forms.Button();
            this.MCSQLButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MCVSLogButton
            // 
            this.MCVSLogButton.Location = new System.Drawing.Point(12, 12);
            this.MCVSLogButton.Name = "MCVSLogButton";
            this.MCVSLogButton.Size = new System.Drawing.Size(125, 31);
            this.MCVSLogButton.TabIndex = 6;
            this.MCVSLogButton.Text = "戦績ログ";
            this.MCVSLogButton.UseVisualStyleBackColor = true;
            this.MCVSLogButton.Click += new System.EventHandler(this.MCVSLogButton_Click);
            // 
            // MCDeckMasterChangeButton
            // 
            this.MCDeckMasterChangeButton.Location = new System.Drawing.Point(173, 12);
            this.MCDeckMasterChangeButton.Name = "MCDeckMasterChangeButton";
            this.MCDeckMasterChangeButton.Size = new System.Drawing.Size(125, 30);
            this.MCDeckMasterChangeButton.TabIndex = 8;
            this.MCDeckMasterChangeButton.Text = "デッキマスタ変更";
            this.MCDeckMasterChangeButton.UseVisualStyleBackColor = true;
            this.MCDeckMasterChangeButton.Click += new System.EventHandler(this.MCDeckMasterChangeButton_Click);
            // 
            // MCFormatMasterChangeButton
            // 
            this.MCFormatMasterChangeButton.Location = new System.Drawing.Point(173, 55);
            this.MCFormatMasterChangeButton.Name = "MCFormatMasterChangeButton";
            this.MCFormatMasterChangeButton.Size = new System.Drawing.Size(125, 30);
            this.MCFormatMasterChangeButton.TabIndex = 9;
            this.MCFormatMasterChangeButton.Text = "フォーマットマスタ変更";
            this.MCFormatMasterChangeButton.UseVisualStyleBackColor = true;
            this.MCFormatMasterChangeButton.Click += new System.EventHandler(this.MCFormatMasterChangeButton_Click);
            // 
            // MCSQLButton
            // 
            this.MCSQLButton.Location = new System.Drawing.Point(12, 55);
            this.MCSQLButton.Name = "MCSQLButton";
            this.MCSQLButton.Size = new System.Drawing.Size(125, 31);
            this.MCSQLButton.TabIndex = 10;
            this.MCSQLButton.Text = "SQL実行";
            this.MCSQLButton.UseVisualStyleBackColor = true;
            this.MCSQLButton.Click += new System.EventHandler(this.MCSQLButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 101);
            this.Controls.Add(this.MCSQLButton);
            this.Controls.Add(this.MCFormatMasterChangeButton);
            this.Controls.Add(this.MCDeckMasterChangeButton);
            this.Controls.Add(this.MCVSLogButton);
            this.Name = "MainMenuForm";
            this.Text = "VersusLog -メインメニュー-";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MCVSLogButton;
        private System.Windows.Forms.Button MCDeckMasterChangeButton;
        private System.Windows.Forms.Button MCFormatMasterChangeButton;
        private System.Windows.Forms.Button MCSQLButton;
    }
}