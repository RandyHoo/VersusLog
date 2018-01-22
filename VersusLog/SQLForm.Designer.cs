namespace VersusLog
{
    partial class SQLForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SQLTextBox = new System.Windows.Forms.TextBox();
            this.BackMainMenuButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL文";
            // 
            // SQLTextBox
            // 
            this.SQLTextBox.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.SQLTextBox.Location = new System.Drawing.Point(12, 28);
            this.SQLTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SQLTextBox.Multiline = true;
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.Size = new System.Drawing.Size(821, 585);
            this.SQLTextBox.TabIndex = 1;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.BackMainMenuButton.Location = new System.Drawing.Point(840, 580);
            this.BackMainMenuButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(142, 34);
            this.BackMainMenuButton.TabIndex = 4;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.DoneButton.Location = new System.Drawing.Point(840, 28);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(142, 34);
            this.DoneButton.TabIndex = 67;
            this.DoneButton.Text = "SQL文実行";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // SQLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 626);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.SQLTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SQLForm";
            this.Text = "VersusLog -上級機能:マスタインポート-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SQLTextBox;
        private System.Windows.Forms.Button BackMainMenuButton;
        private System.Windows.Forms.Button DoneButton;
    }
}