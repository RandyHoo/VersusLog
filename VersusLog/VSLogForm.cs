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
        public VSLogForm()
        {
            InitializeComponent();

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

                    //自デッキ、相手デッキ 大分類コンボボックスの要素としてセット
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyDeckMajorclassDatasource.Add(reader.GetString(0));
                            EnemyDeckMajorclassDatasource.Add(reader.GetString(0));
                        }
                        VLMydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
                        VLEnemydeckMajorclassComboBox.DataSource = EnemyDeckMajorclassDatasource;
                    }

                    //フォーマット名取得用クエリ作成
                    cmd.CommandText = "select FORMATNAME from FORMAT";

                    //フォーマットコンボボックスの要素としてセット
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormatDatasource.Add(reader.GetString(0));
                        }
                        VLFormatComboBox.DataSource = FormatDatasource;
                    }
                }

                con.Close();
            }

            //結果コンボボックスの要素入力
            var WinDatasource = new List<string>();
            WinDatasource.Add("勝ち");
            WinDatasource.Add("負け");
            VLWinComboBox.DataSource = WinDatasource;

            //先行後攻コンボボックスの要素入力
            var PracedenceDatasource = new List<string>();
            PracedenceDatasource.Add("先行");
            PracedenceDatasource.Add("後攻");
            VLPracedenceComboBox.DataSource = PracedenceDatasource;

            //変更種別コンボボックスの要素入力
            var ChangeGenreDatasource = new List<string> { "変更", "削除" };
            VLChangeGenreComboBox.DataSource = ChangeGenreDatasource;



            //ログ入力
            InsertLogFormInit();



            //デッキ戦績
            var DRMyDeckMajorclassDatasource = new List<string>();

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
                            DRMyDeckMajorclassDatasource.Add(reader.GetString(0));
                        }
                        DRMydeckMajorclassComboBox.DataSource = DRMyDeckMajorclassDatasource;
                    }
                }

                con.Close();
            }



            //メタ分析
            //期間コンボボックスの要素をセット
            var PeriodDatasource = new List<string> { "指定なし", "この1週間", "今月" };
            MAPeriodComboBox.DataSource = PeriodDatasource;
        }

        private void DataGetButton_Click(object sender, EventArgs e)
        {
            var displaylist = new List<LogData>();

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
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
                        VLLogGridView.DataSource = displaylist;

                        //LogGridViewの列ヘッダーの表示を日本語にする
                        var cheaderlist = new List<string> { "ID", "日付", "自デッキ・大分類", "自デッキ・小分類", "相手デッキ・大分類", "相手デッキ・小分類", "結果", "フォーマット", "先行後攻" };
                        for (int i = 0; i < VLLogGridView.Columns.Count; i++)
                        {
                            VLLogGridView.Columns[i].HeaderText = cheaderlist[i];
                        }

                        //表示幅の自動修正をON
                        VLLogGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        VLLogGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        VLLogGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        VLLogGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

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

        private void MydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(VLMydeckMajorclassComboBox, VLMydeckSmallclassComboBox);
        }

        private void EnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(VLEnemydeckMajorclassComboBox, VLEnemydeckSmallclassComboBox);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //変更種別ごとにコマンド生成
                    switch (VLChangeGenreComboBox.Text)
                    {
                        case "変更":
                            int mydeckid = 0, enemydeckid = 0, formatid = 0;
                            string Qmydeckid, Qenemydeckid, Qwin, Qformatid, Qpracedence;

                            //自デッキID
                            cmd.CommandText = "select ID from DECK " +
                                "where MAJORCLASS = '" + VLMydeckMajorclassComboBox.Text + "' " +
                                "and SMALLCLASS = '" + VLMydeckSmallclassComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    mydeckid = System.Convert.ToInt32(reader.GetValue(0));
                                }
                            }
                            Qmydeckid = mydeckid.ToString();

                            //相手デッキID
                            cmd.CommandText = "select ID from DECK " +
                                "where MAJORCLASS = '" + VLEnemydeckMajorclassComboBox.Text + "' " +
                                "and SMALLCLASS = '" + VLEnemydeckSmallclassComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    enemydeckid = System.Convert.ToInt32(reader.GetValue(0));
                                }
                            }
                            Qenemydeckid = enemydeckid.ToString();

                            //結果
                            Qwin = (VLWinComboBox.Text == "勝ち") ? "1" : "0";

                            //フォーマットID
                            cmd.CommandText = "select ID from FORMAT " +
                                "where FORMATNAME = '" + VLFormatComboBox.Text + "'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    formatid = System.Convert.ToInt32(reader.GetValue(0));
                                }
                            }
                            Qformatid = formatid.ToString();

                            //先攻後攻
                            Qpracedence = (VLPracedenceComboBox.Text == "先行") ? "1" : "0";

                            //変更用クエリ作成
                            cmd.CommandText = "update VSLOG " +
                                "set VSDATE = '" + VLDateTextBox.Text + "', " +
                                "MYDECKID = " + Qmydeckid + ", " +
                                "ENEMYDECKID = " + Qenemydeckid + ", " +
                                "WIN = " + Qwin + ", " +
                                "FORMATID = " + Qformatid + ", " +
                                "PRACEDENCE = " + Qpracedence + " " +
                                "where ID = " + VLIDTextBox.Text;

                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("DBが変更されました。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show("DBを変更できませんでした。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            break;
                        case "削除":
                            //削除用クエリ作成
                            cmd.CommandText = "delete from VSLOG " +
                                "where ID = " + VLIDTextBox.Text;

                            count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("DBから削除されました。", "削除結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show("DBから削除できませんでした。", "削除結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            break;

                        default:
                            break;
                    }

                    con.Close();
                }
            }
        }



        //ログ入力
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
                        ILMydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
                        ILEnemydeckMajorclassComboBox.DataSource = EnemyDeckMajorclassDatasource;
                    }

                    //フォーマット名取得用クエリ作成
                    cmd.CommandText = "select FORMATNAME from FORMAT";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormatDatasource.Add(reader.GetString(0));
                        }
                        ILFormatComboBox.DataSource = FormatDatasource;
                    }
                }

                con.Close();
            }

            //結果コンボボックスの要素入力
            var WinDatasource = new List<string>();
            WinDatasource.Add("勝ち");
            WinDatasource.Add("負け");
            ILWinComboBox.DataSource = WinDatasource;

            //先行後攻コンボボックスの要素入力
            var PracedenceDatasource = new List<string>();
            PracedenceDatasource.Add("先行");
            PracedenceDatasource.Add("後攻");
            ILPracedenceComboBox.DataSource = PracedenceDatasource;

            //日付のデフォ値(今日の日付)を入力
            DateTime dtNow = DateTime.Now;
            DateTime dtToday = dtNow.Date;
            ILDateTextBox.Text = dtToday.ToShortDateString();
        }

        private void ILMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(ILMydeckMajorclassComboBox, ILMydeckSmallclassComboBox);
        }

        private void ILEnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            CommonData.GetDeckSmallclass(ILEnemydeckMajorclassComboBox, ILEnemydeckSmallclassComboBox);
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
                    string Qvsdate = ILDateTextBox.Text;

                    //自デッキID
                    cmd.CommandText = "select ID from DECK " +
                        "where MAJORCLASS = '" + ILMydeckMajorclassComboBox.Text + "' " +
                        "and SMALLCLASS = '" + ILMydeckSmallclassComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        mydeckid = System.Convert.ToInt32(reader.GetValue(0));
                    }
                    string Qmydeckid = mydeckid.ToString();

                    //相手デッキID
                    cmd.CommandText = "select ID from DECK " +
                        "where MAJORCLASS = '" + ILEnemydeckMajorclassComboBox.Text + "' " +
                        "and SMALLCLASS = '" + ILEnemydeckSmallclassComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enemydeckid = System.Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                    string Qenemydeckid = enemydeckid.ToString();

                    //結果
                    string Qwin = (ILWinComboBox.Text == "勝ち") ? "1" : "0";

                    //フォーマットID
                    cmd.CommandText = "select ID from FORMAT " +
                        "where FORMATNAME = '" + ILFormatComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            formatid = System.Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                    string Qformatid = formatid.ToString();

                    //先行後攻
                    string Qpracedence = (ILPracedenceComboBox.Text == "先行") ? "1" : "0";

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



        //デッキ戦績
        private void DRGetDeckRecordButton_Click(object sender, EventArgs e)
        {
            var decklist = new List<DeckList>(); //デッキリスト
            var viewlist = new List<ViewList>(); //表示用リスト

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ一覧取得(デッキ大分類は昇順)用クエリ作成
                    cmd.CommandText = "select ID, MAJORCLASS, SMALLCLASS from DECK order by MAJORCLASS";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decklist.Add(new DeckList(reader.GetValue(0), reader.GetString(1), reader.GetString(2)));
                        }

                    }

                    int mydeckid, tortal_col;
                    float win, total;

                    //自デッキID取得
                    cmd.CommandText = "select ID from DECK " +
                        "where MAJORCLASS = '" + DRMydeckMajorclassComboBox.Text + "'" +
                        "and SMALLCLASS = '" + DRMydeckSmallclassComboBox.Text + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        mydeckid = System.Convert.ToInt32(reader.GetValue(0));
                    }

                    //全体の勝率を取得
                    cmd.CommandText = "select count(*) from VSLOG " +
                            "where " +
                            "MYDECKID = " + mydeckid;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        tortal_col = System.Convert.ToInt32(reader.GetValue(0));
                    }

                    cmd.CommandText = "select count(*) from VSLOG " +
                                "where " +
                                "MYDECKID = " + mydeckid + " " +
                                "and WIN = 1";
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        win = System.Convert.ToInt32(reader.GetValue(0));
                    }

                    if (tortal_col > 0)
                    {
                        total = (win / tortal_col) * 100;
                    }
                    else
                    {
                        //対戦したことがないことを示すため「-」を入力する
                        total = 999;
                    }

                    string deckname = "全体";
                    viewlist.Add(new ViewList(deckname, (int)total));

                    //デッキ毎の勝率を取得
                    foreach (var n in decklist)
                    {
                        cmd.CommandText = "select count(*) from VSLOG " +
                            "where " +
                            "MYDECKID = " + mydeckid + " " +
                            "and ENEMYDECKID = " + n.ID;
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            tortal_col = System.Convert.ToInt32(reader.GetValue(0));
                        }

                        cmd.CommandText = "select count(*) from VSLOG " +
                            "where " +
                            "MYDECKID = " + mydeckid + " " +
                            "and ENEMYDECKID = " + n.ID + " " +
                            "and WIN = 1";
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            win = System.Convert.ToInt32(reader.GetValue(0));
                        }

                        if (tortal_col > 0)
                        {
                            total = (win / tortal_col) * 100;
                        }
                        else
                        {
                            //対戦したことがないことを示すため「-」を入力する
                            total = 999;
                        }

                        deckname = n.Deck_majorclass + " " + n.Deck_smallclass;

                        viewlist.Add(new ViewList(deckname, (int)total));
                    }
                    //ビューのソースにする
                    DRDeckRecodeView.DataSource = viewlist;

                    //DeckRecodeViewの列ヘッダーの表示を日本語にする
                    var cheaderlist = new List<string> { "デッキ", "勝率(%)" };
                    for (int i = 0; i < DRDeckRecodeView.Columns.Count; i++)
                    {
                        DRDeckRecodeView.Columns[i].HeaderText = cheaderlist[i];
                    }

                    //表示幅の自動修正をON
                    DRDeckRecodeView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DRDeckRecodeView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }

                con.Close();
            }
        }

        private void DRMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得
            CommonData.GetDeckSmallclass(DRMydeckMajorclassComboBox, DRMydeckSmallclassComboBox);
        }



        //メタ分析
        private void MAPeriodComboBox_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    string wheretext, worktext;

                    //今日の日付取得
                    DateTime dtNow = DateTime.Now;
                    DateTime dtToday = dtNow.Date;
                    string today = dtToday.ToShortDateString();

                    //変更種別に応じてクエリの条件を生成
                    switch (MAPeriodComboBox.Text)
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
                        moredeckid = System.Convert.ToInt32(reader.GetValue(0));
                    }

                    //最頻相手デッキ名取得
                    cmd.CommandText = "select MAJORCLASS, SMALLCLASS from DECK " +
                        "where ID = " + moredeckid;

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        moredeck = (reader.GetString(0)) + " " + (reader.GetString(1));
                    }
                    MAMetaAnalyzeDeckText.Text = moredeck;
                }

                con.Close();
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
            //int(1(true) or 0(false))を変換
            this.Win = (System.Convert.ToInt32(win) == 1) ? "勝ち" : "負け";
            this.Format = format;
            //int(1(true) or 0(false))を変換
            this.Pracedence = (System.Convert.ToInt32(pracedence) == 1) ? "先行" : "後攻";
        }
    }

    //戦績ログクラス
    class DeckList
    {
        //デッキID
        public int ID { get; set; }

        //デッキ・大分類
        public string Deck_majorclass { get; set; }

        //デッキ・小分類
        public string Deck_smallclass { get; set; }

        public DeckList(object id, string deck_majorclass, string deck_smallclass)
        {
            this.ID = System.Convert.ToInt32(id);
            this.Deck_majorclass = deck_majorclass;
            this.Deck_smallclass = deck_smallclass;
        }
    }

    //表示用クラス
    class ViewList
    {
        //デッキ・大分類
        public string Deckname { get; set; }

        //デッキ・小分類
        public string Total { get; set; }

        public ViewList(string deckname, int total)
        {
            this.Deckname = deckname;

            this.Total = total.ToString();
            //999(対戦したことがないことを表す)の場会、「-」を表示させる
            if (this.Total == "999")
            {
                this.Total = "-";
            }
        }
    }
}
