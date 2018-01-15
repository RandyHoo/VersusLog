using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void DoneButton_Click(object sender, EventArgs e)
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

        private void BackMainMenuButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new MainMenuForm();
            ViewForm.Show();
            this.Hide();
        }
    }
}
