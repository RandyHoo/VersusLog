using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace VersusLog
{
    public partial class SQLForm : Form
    {
        public SQLForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実行ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (SQLFormInputCheck())
            {
                using (var con = new SQLiteConnection(CommonData.ConnectionString))
                {
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {
                        try
                        {
                            //クエリ作成、実行
                            cmd.CommandText = SQLTextBox.Text;
                            int count = cmd.ExecuteNonQuery();
                            MessageBox.Show(count + "件の変更を行いました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        catch
                        {
                            MessageBox.Show("SQLエラーです", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }

                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("SQL文が記載されていません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// メインメニューに戻るボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackMainMenuButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new MainMenuForm();
            ViewForm.Show();
            Hide();
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        private bool SQLFormInputCheck()
        {
            if (string.IsNullOrEmpty(SQLTextBox.Text)) { return false; } //SQL文
            return true;
        }
    }
}
