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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL文";
            // 
            // SQLTextBox
            // 
            this.SQLTextBox.Location = new System.Drawing.Point(12, 24);
            this.SQLTextBox.Multiline = true;
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.Size = new System.Drawing.Size(704, 469);
            this.SQLTextBox.TabIndex = 1;
            // 
            // BackMainMenuButton
            // 
            this.BackMainMenuButton.Location = new System.Drawing.Point(722, 466);
            this.BackMainMenuButton.Name = "BackMainMenuButton";
            this.BackMainMenuButton.Size = new System.Drawing.Size(122, 27);
            this.BackMainMenuButton.TabIndex = 4;
            this.BackMainMenuButton.Text = "メインメニューに戻る";
            this.BackMainMenuButton.UseVisualStyleBackColor = true;
            this.BackMainMenuButton.Click += new System.EventHandler(this.BackMainMenuButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(722, 24);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(122, 27);
            this.DoneButton.TabIndex = 67;
            this.DoneButton.Text = "SQL文実行";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // SQLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 501);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.BackMainMenuButton);
            this.Controls.Add(this.SQLTextBox);
            this.Controls.Add(this.label1);
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