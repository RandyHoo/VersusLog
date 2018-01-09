namespace VersusLog
{
    partial class MetaAnalyzeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MetaAnalyzeDeckText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PeriodComboBox = new System.Windows.Forms.ComboBox();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MetaAnalyzeDeckText);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最多デッキ";
            // 
            // MetaAnalyzeDeckText
            // 
            this.MetaAnalyzeDeckText.AutoSize = true;
            this.MetaAnalyzeDeckText.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MetaAnalyzeDeckText.Location = new System.Drawing.Point(6, 26);
            this.MetaAnalyzeDeckText.Name = "MetaAnalyzeDeckText";
            this.MetaAnalyzeDeckText.Size = new System.Drawing.Size(73, 20);
            this.MetaAnalyzeDeckText.TabIndex = 2;
            this.MetaAnalyzeDeckText.Text = "default";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "期間指定";
            // 
            // PeriodComboBox
            // 
            this.PeriodComboBox.FormattingEnabled = true;
            this.PeriodComboBox.Location = new System.Drawing.Point(12, 24);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(121, 20);
            this.PeriodComboBox.TabIndex = 4;
            this.PeriodComboBox.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(148, 222);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 5;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // MetaAnalyzeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.PeriodComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MetaAnalyzeForm";
            this.Text = "VersusLog -メタ分析-";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label MetaAnalyzeDeckText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PeriodComboBox;
        private System.Windows.Forms.Button BackMainMenuButton;
    }
}