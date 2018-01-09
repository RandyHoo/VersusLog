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
    public partial class MetaAnalyzeForm : Form
    {
        private const string ConnectionString = @"Data Source=vslog.db";

        public MetaAnalyzeForm()
        {
            InitializeComponent();
            var PeriodDatasource = new List<string> { "指定なし", "この1週間", "今月" };
            PeriodComboBox.DataSource = PeriodDatasource;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    string wheretext, worktext;

                    //今日の日付取得
                    DateTime dtNow = DateTime.Now;
                    DateTime dtToday = dtNow.Date;
                    string today = dtToday.ToShortDateString();

                    switch (PeriodComboBox.Text)
                    {
                        case "指定なし":
                            wheretext = " ";
                            break;
                        case "この1週間":
                            string workdate = today.ToString();
                            DateTime dt = DateTime.Parse(workdate);
                            DateTime dtcal = dt.AddDays(-7);
                            workdate = dtcal.ToShortDateString();

                            wheretext = " where VSDATE between '" + workdate + "' and '" + today + "' ";
                            break;
                        case "今月":
                            worktext = today.Substring(0, 7);
                            wheretext = "where VSDATE like '" + worktext + "%' ";
                            break;
                        default:
                            wheretext = " ";
                            break;

                    }

                    //最頻相手デッキID取得
                    cmd.CommandText = "select ENEMYDECKID from VSLOG " + wheretext +
                        "group by ENEMYDECKID " +
                        "having count(*) >= (select count(*) from VSLOG group by ENEMYDECKID)";

                    int moredeckid;
                    string moredeck;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        moredeckid = (int)(long)reader.GetValue(0);
                    }

                    //最頻相手デッキ名取得
                    cmd.CommandText = "select MAJORCLASS, SMALLCLASS from DECK " +
                        "where ID = " + moredeckid;

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        moredeck = (reader.GetString(0)) + " " + (reader.GetString(1));
                    }
                    MetaAnalyzeDeckText.Text = moredeck;
                }

                //DB切断
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
