using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;

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
            CommonData cd = new CommonData();

            if (SQLFormInputCheck())
            {
                //クエリ作成、実行
                string SQLtext = SQLTextBox.Text;
                int count = cd.executeSQL(SQLtext);
                MessageBox.Show(count + "件の変更を行いました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.None);
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

        /// <summary>
        /// ファイル読み出しボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "SQLファイル(*.sql)|*.sql|すべてのファイル(*.*)|*.*";
            ofd.Title = "開くSQLファイル(Shift_JIS)を選択してください";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string line = "";
                List<string> SqlList = new List<string>();
                bool SqlFailedFlag = false;

                using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.GetEncoding("Shift_JIS")))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        SqlList.Add(line);
                    }

                    CommonData cd = new CommonData();
                    foreach (string SQLtext in SqlList)
                    {
                        //実行できなかった時
                        if (0 == cd.executeSQL(SQLtext))
                        {
                            MessageBox.Show("SQLを実行出来ませんでした。", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            SqlFailedFlag = true;
                        }
                    }

                    //全件実行された時
                    if (!SqlFailedFlag)
                    {
                        MessageBox.Show("全件実行されました。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
            }
        }
    }
}
