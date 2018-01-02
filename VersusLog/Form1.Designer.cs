namespace VersusLog
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGetButton
            // 
            this.DataGetButton.Location = new System.Drawing.Point(12, 602);
            this.DataGetButton.Name = "DataGetButton";
            this.DataGetButton.Size = new System.Drawing.Size(122, 32);
            this.DataGetButton.TabIndex = 0;
            this.DataGetButton.Text = "DataGet";
            this.DataGetButton.UseVisualStyleBackColor = true;
            this.DataGetButton.Click += new System.EventHandler(this.DataGetButton_Click);
            // 
            // LogGridView
            // 
            this.LogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogGridView.Location = new System.Drawing.Point(140, 12);
            this.LogGridView.Name = "LogGridView";
            this.LogGridView.RowTemplate.Height = 21;
            this.LogGridView.Size = new System.Drawing.Size(858, 622);
            this.LogGridView.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 646);
            this.Controls.Add(this.LogGridView);
            this.Controls.Add(this.DataGetButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DataGetButton;
        private System.Windows.Forms.DataGridView LogGridView;
    }
}

