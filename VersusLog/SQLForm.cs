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
                    /*try
                    {*/
                    //クエリ作成
                    cmd.CommandText = SQLTextBox.Text;

                    using (var reader = cmd.ExecuteReader())
                    {
                        int readcount = 0;
                        string text = "";
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(readcount));
                            ResultTextBox.Text = text;
                            readcount += 1;
                        }
                    }
                    /*}
                    catch
                    {
                        MessageBox.Show("SQLエラーです", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }*/
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }
    }
}
