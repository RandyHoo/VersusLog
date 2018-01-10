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
    public partial class VSLogForm : Form
    {
        private const string ConnectionString = @"Data Source=vslog.db";

        public VSLogForm()
        {
            InitializeComponent();

            var MyDeckMajorclassDatasource = new List<string>();
            var EnemyDeckMajorclassDatasource = new List<string>();
            var FormatDatasource = new List<string>();

            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ名取得用クエリ作成
                    cmd.CommandText = "select distinct MAJORCLASS from DECK";

                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
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
                        //読み出し
                        while (reader.Read())
                        {
                            FormatDatasource.Add(reader.GetString(0));
                        }
                        FormatComboBox.DataSource = FormatDatasource;
                    }
                }

                //DB切断
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

            var ChangeGenreDatasource = new List<string> { "変更", "削除" };
            ChangeGenreComboBox.DataSource = ChangeGenreDatasource;
        }

        private void DataGetButton_Click(object sender, EventArgs e)
        {
            var displaylist = new List<LogData>(); //表示用リスト

            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //戦績ログ(絞込無し)取得用クエリ作成
                    cmd.CommandText = "select VSLOG.ID, VSLOG.VSDATE, MYDECK.MAJORCLASS, MYDECK.SMALLCLASS, ENEMYDECK.MAJORCLASS, ENEMYDECK.SMALLCLASS, VSLOG.WIN, FORMAT.FORMATNAME, VSLOG.PRACEDENCE " +
                        "from VSLOG " +
                        "left outer join DECK as MYDECK on VSLOG.MYDECKID = MYDECK.ID " +
                        "left outer join DECK as ENEMYDECK on VSLOG.ENEMYDECKID = ENEMYDECK.ID " +
                        "left outer join FORMAT on VSLOG.FORMATID = FORMAT.ID";

                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
                        while (reader.Read())
                        {
                            displaylist.Add(new LogData(
                                reader.GetValue(0), //ID
                                reader.GetString(1), //日付
                                reader.IsDBNull(2) ? null : reader.GetString(2), //自デッキ・大分類
                                reader.IsDBNull(3) ? null : reader.GetString(3), //自デッキ・小分類
                                reader.IsDBNull(4) ? null : reader.GetString(4), //相手デッキ・大分類
                                reader.IsDBNull(5) ? null : reader.GetString(5), //相手デッキ・小分類
                                reader.GetValue(6), //結果
                                reader.IsDBNull(7) ? null : reader.GetString(7), //フォーマット
                                reader.GetValue(8) //先攻後攻
                                ));
                        }
                        LogGridView.DataSource = displaylist;

                        //LogGridViewの列ヘッダーの表示を日本語にする
                        var cheaderlist = new List<string> { "ID", "日付", "自デッキ・大分類", "自デッキ・小分類", "相手デッキ・大分類", "相手デッキ・小分類", "結果", "フォーマット", "先行後攻" };
                        for (int i = 0; i < LogGridView.Columns.Count; i++)
                        {
                            LogGridView.Columns[i].HeaderText = cheaderlist[i];
                        }

                        //表示幅の自動修正をON
                        LogGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        LogGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        LogGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        LogGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

                    }
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

        private void MydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            var DeckSmallclassDatasource = new List<string>();

            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ名取得用クエリ作成
                    cmd.CommandText = "select SMALLCLASS from DECK " +
                        "where MAJORCLASS = '" + MydeckMajorclassComboBox.Text + "'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
                        while (reader.Read())
                        {
                            DeckSmallclassDatasource.Add(reader.GetString(0));
                        }
                        MydeckSmallclassComboBox.DataSource = DeckSmallclassDatasource;
                    }
                }
            }
        }

        private void EnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            var DeckSmallclassDatasource = new List<string>();

            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ名取得用クエリ作成
                    cmd.CommandText = "select SMALLCLASS from DECK " +
                        "where MAJORCLASS = '" + EnemydeckMajorclassComboBox.Text + "'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
                        while (reader.Read())
                        {
                            DeckSmallclassDatasource.Add(reader.GetString(0));
                        }
                        EnemydeckSmallclassComboBox.DataSource = DeckSmallclassDatasource;
                    }
                }
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //変更種別ごとにコマンド生成
            switch (ChangeGenreComboBox.Text)
            {
                case "変更":
                    using (var con = new SQLiteConnection(ConnectionString))
                    {
                        //DB接続
                        con.Open();

                        using (var cmd = con.CreateCommand())
                        {
                            int mydeckid = 0, enemydeckid = 0, formatid = 0;
                            string Qmydeckid, Qenemydeckid, Qwin, Qformatid, Qpracedence;

                            //自デッキID
                            cmd.CommandText = "select ID from DECK " +
                                "where MAJORCLASS = '" + MydeckMajorclassComboBox.Text + "' " +
                                "and SMALLCLASS = '" + MydeckSmallclassComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    mydeckid = (int)(long)reader.GetValue(0);
                                }
                            }
                            Qmydeckid = mydeckid.ToString();

                            //相手デッキID
                            cmd.CommandText = "select ID from DECK " +
                                "where MAJORCLASS = '" + EnemydeckMajorclassComboBox.Text + "' " +
                                "and SMALLCLASS = '" + EnemydeckSmallclassComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    enemydeckid = (int)(long)reader.GetValue(0);
                                }
                            }
                            Qenemydeckid = enemydeckid.ToString();

                            Qwin = (WinComboBox.Text == "勝ち") ? "1" : "0";

                            cmd.CommandText = "select ID from FORMAT " +
                                "where FORMATNAME = '" + FormatComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    formatid = (int)(long)reader.GetValue(0);
                                }
                            }
                            Qformatid = formatid.ToString();

                            Qpracedence = (PracedenceComboBox.Text == "先行") ? "1" : "0";

                            //変更用クエリ作成
                            cmd.CommandText = "update VSLOG " +
                                "set VSDATE = '" + DateTextBox.Text + "', " +
                                "MYDECKID = " + Qmydeckid + ", " +
                                "ENEMYDECKID = " + Qenemydeckid + ", " +
                                "WIN = " + Qwin + ", " +
                                "FORMATID = " + Qformatid + ", " +
                                "PRACEDENCE = " + Qpracedence + " " +
                                "where ID = " + IDTextBox.Text;

                            //コマンド実行
                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("DBが変更されました。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show("DBを変更できませんでした。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }

                        //DB切断
                        con.Close();
                    }
                    break;
                case "削除":
                    using (var con = new SQLiteConnection(ConnectionString))
                    {
                        //DB接続
                        con.Open();

                        using (var cmd = con.CreateCommand())
                        {

                            //追加用クエリ作成
                            cmd.CommandText = "delete from VSLOG " +
                                "where ID = " + IDTextBox.Text;

                            //コマンド実行
                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("DBから削除されました。", "削除結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show("DBから削除できませんでした。", "削除結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }

                        //DB切断
                        con.Close();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    //戦績ログクラス
    class LogData
    {
        //ID
        public int ID { get; set; }

        //日付
        public string Vsdate { get; set; }

        //自デッキ・大分類
        public string Mydeck_majorclass { get; set; }

        //自デッキ・小分類
        public string Mydeck_smallclass { get; set; }

        //相手デッキ・大分類
        public string Enemydeck_majorclass { get; set; }

        //相手デッキ・小分類
        public string Enemydeck_smallclass { get; set; }

        //結果("勝ち" or "負け")
        public string Win { get; set; }

        //フォーマット
        public string Format { get; set; }

        //先行後攻("先行" or "後攻")
        public string Pracedence { get; set; }

        public LogData(object id, string vsdate, string mydeck_majorclass, string mydeck_smallclass, string enemydeck_majorclass, string enemydeck_smallclass, object win, string format, object pracedence)
        {
            this.ID = System.Convert.ToInt32(id);
            this.Vsdate = vsdate;
            this.Mydeck_majorclass = mydeck_majorclass;
            this.Mydeck_smallclass = mydeck_smallclass;
            this.Enemydeck_majorclass = enemydeck_majorclass;
            this.Enemydeck_smallclass = enemydeck_smallclass;
            //int(1(true) or 0(false))をstringに変換
            this.Win = (System.Convert.ToInt32(win) == 1) ? "勝ち" : "負け";
            this.Format = format;
            //int(1(true) or 0(false))をstringに変換
            this.Pracedence = (System.Convert.ToInt32(pracedence) == 1) ? "先行" : "後攻";
        }
    }
}
