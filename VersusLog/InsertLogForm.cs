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
    public partial class InsertLogForm : Form
    {
        public InsertLogForm()
        {
            InitializeComponent();
            InsertLogFormInit();
        }

        //初期化処理
        private void InsertLogFormInit()
        {
            var MyDeckMajorclassDatasource = new List<string>();
            var EnemyDeckMajorclassDatasource = new List<string>();
            var FormatDatasource = new List<string>();

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ名取得用クエリ作成
                    cmd.CommandText = "select distinct MAJORCLASS from DECK";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyDeckMajorclassDatasource.Add(reader.GetString(0));
                            EnemyDeckMajorclassDatasource.Add(reader.GetString(0));
                        }
                        MydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
                        EnemydeckMajorclassComboBox.DataSource = EnemyDeckMajorclassDatasource;
                    }

                    //フォーマット名取得用クエリ作成
                    cmd.CommandText = "select FORMATNAME from FORMAT";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormatDatasource.Add(reader.GetString(0));
                        }
                        FormatComboBox.DataSource = FormatDatasource;
                    }
                }

                con.Close();
            }

            //結果コンボボックスの要素入力
            var WinDatasource = new List<string>();
            WinDatasource.Add("勝ち");
            WinDatasource.Add("負け");
            WinComboBox.DataSource = WinDatasource;

            //先行後攻コンボボックスの要素入力
            var PracedenceDatasource = new List<string>();
            PracedenceDatasource.Add("先行");
            PracedenceDatasource.Add("後攻");
            PracedenceComboBox.DataSource = PracedenceDatasource;

            //日付のデフォ値(今日の日付)を入力
            DateTime dtNow = DateTime.Now;
            DateTime dtToday = dtNow.Date;
            DateTextBox.Text = dtToday.ToShortDateString();
        }

        //自デッキ・大分類変更時に小分類を取得する
        private void MydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(MydeckMajorclassComboBox, MydeckSmallclassComboBox);
        }

        //相手デッキ・大分類変更時に小分類を取得する
        private void EnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(EnemydeckMajorclassComboBox, EnemydeckSmallclassComboBox);
        }

        private void LogInsertButton_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    int id = 0,
                        mydeckid = 0,
                        enemydeckid = 0,
                        formatid = 0;

                    //ID
                    cmd.CommandText = "select ID from VSLOG";
                    using (var reader = cmd.ExecuteReader())
                    {
                        //最後のレコードのIDを取得する
                        while (reader.Read())
                        {
                            id = System.Convert.ToInt32(reader.GetValue(0));
                        }
                        id += 1;
                    }
                    string Qid = id.ToString();

                    //日付
                    string Qvsdate = DateTextBox.Text;

                    //自デッキID
                    cmd.CommandText = "select ID from DECK " +
                        "where MAJORCLASS = '" + MydeckMajorclassComboBox.Text + "' " +
                        "and SMALLCLASS = '" + MydeckSmallclassComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        mydeckid = System.Convert.ToInt32(reader.GetValue(0));
                    }
                    string Qmydeckid = mydeckid.ToString();

                    //相手デッキID
                    cmd.CommandText = "select ID from DECK " +
                        "where MAJORCLASS = '" + EnemydeckMajorclassComboBox.Text + "' " +
                        "and SMALLCLASS = '" + EnemydeckSmallclassComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enemydeckid = System.Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                    string Qenemydeckid = enemydeckid.ToString();

                    //結果
                    string Qwin = (WinComboBox.Text == "勝ち") ? "1" : "0";

                    //フォーマットID
                    cmd.CommandText = "select ID from FORMAT " +
                        "where FORMATNAME = '" + FormatComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            formatid = System.Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                    string Qformatid = formatid.ToString();

                    //先行後攻
                    string Qpracedence = (PracedenceComboBox.Text == "先行") ? "1" : "0";

                    //DBにログ入力用クエリ作成
                    cmd.CommandText = "insert into VSLOG " +
                        "values( " +
                        " " + Qid + "," + //ID
                        " '" + Qvsdate + "'," + //日付
                        " " + Qmydeckid + "," + //自デッキID
                        " " + Qenemydeckid + "," + //相手デッキID
                        " " + Qwin + "," + //結果
                        " " + Qformatid + "," + //フォーマットID
                        " " + Qpracedence + //先行後攻
                        " )";

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("ログに登録されました。", "ログ入力結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("ログに登録できませんでした。", "ログ入力結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
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
