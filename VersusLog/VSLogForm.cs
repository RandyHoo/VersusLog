using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace VersusLog
{
    public partial class VSLogForm : Form
    {
        CommonData cd = new CommonData();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VSLogForm()
        {
            InitializeComponent();

            //初期化処理
            VSLogFormInit();        //戦績ログ
            InsertLogFormInit();    //ログ入力
            DeckRecodeFormInit();   //デッキ戦績
            MetaAnalyzeFormInit();  //メタ分析
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



        #region 戦績ログ

        /// <summary>
        /// 戦績ログ初期化処理
        /// </summary>
        private void VSLogFormInit()
        {
            var MyDeckMajorclassDatasource = new List<string>();
            var EnemyDeckMajorclassDatasource = new List<string>();
            var FormatDatasource = new List<string>();
            DataTable dt = new DataTable();

            //自デッキ、相手デッキ 大分類コンボボックスの要素をセット
            string SQLtext = "select distinct MAJORCLASS from DECK";
            dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                MyDeckMajorclassDatasource.Add(Convert.ToString(row[0]));
                EnemyDeckMajorclassDatasource.Add(Convert.ToString(row[0]));
            }
            VLMydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
            VLEnemydeckMajorclassComboBox.DataSource = EnemyDeckMajorclassDatasource;

            //フォーマットコンボボックスの要素をセット
            SQLtext = "select FORMATNAME from FORMAT";
            dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                FormatDatasource.Add(Convert.ToString(row[0]));
            }
            VLFormatComboBox.DataSource = FormatDatasource;

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

            //ログ表示
            VSLogUpdateView();
        }

        /// <summary>
        /// 戦績ログ:データ取得ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGetButton_Click(object sender, EventArgs e)
        {
            VSLogUpdateView();
        }

        /// <summary>
        /// 戦績ログ:表示更新処理
        /// </summary>
        private void VSLogUpdateView()
        {
            var displaylist = new List<LogData>();
            DataTable dt = new DataTable();

            //戦績ログ(絞込無し)取得
            string SQLtext = "select VSLOG.ID, VSLOG.VSDATE, MYDECK.MAJORCLASS, MYDECK.SMALLCLASS, ENEMYDECK.MAJORCLASS, ENEMYDECK.SMALLCLASS, VSLOG.WIN, FORMAT.FORMATNAME, VSLOG.PRACEDENCE " +
                "from VSLOG " +
                "left outer join DECK as MYDECK on VSLOG.MYDECKID = MYDECK.ID " +
                "left outer join DECK as ENEMYDECK on VSLOG.ENEMYDECKID = ENEMYDECK.ID " +
                "left outer join FORMAT on VSLOG.FORMATID = FORMAT.ID";
            dt = cd.getDataTable(SQLtext);
            dt.DefaultView.AllowNew = false;
            VLLogGridView.DataSource = dt;

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

        /// <summary>
        /// 戦績ログ:自デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VLMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            cd.GetDeckSmallclass(VLMydeckMajorclassComboBox, VLMydeckSmallclassComboBox);
        }

        /// <summary>
        /// 戦績ログ:相手デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VLEnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            cd.GetDeckSmallclass(VLEnemydeckMajorclassComboBox, VLEnemydeckSmallclassComboBox);
        }

        /// <summary>
        /// 戦績ログ:実行ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string SQLtext = "";

            if (VSLogFormInputCheck())
            {
                //変更種別ごとにコマンド生成
                switch (VLChangeGenreComboBox.Text)
                {
                    case "変更":
                        int mydeckid = 0, enemydeckid = 0, formatid = 0;
                        string Qmydeckid, Qenemydeckid, Qwin, Qformatid, Qpracedence;

                        //自デッキID
                        SQLtext = "select ID from DECK " +
                            "where MAJORCLASS = '" + VLMydeckMajorclassComboBox.Text + "' " +
                            "and SMALLCLASS = '" + VLMydeckSmallclassComboBox.Text + "'";
                        dt = cd.getDataTable(SQLtext);
                        foreach (DataRow row in dt.Rows)
                        {
                            mydeckid = System.Convert.ToInt32(row[0]);
                        }
                        Qmydeckid = mydeckid.ToString();

                        //相手デッキID
                        SQLtext = "select ID from DECK " +
                            "where MAJORCLASS = '" + VLEnemydeckMajorclassComboBox.Text + "' " +
                            "and SMALLCLASS = '" + VLEnemydeckSmallclassComboBox.Text + "'";
                        dt = cd.getDataTable(SQLtext);
                        foreach (DataRow row in dt.Rows)
                        {
                            enemydeckid = System.Convert.ToInt32(row[0]);
                        }
                        Qenemydeckid = enemydeckid.ToString();

                        //結果
                        Qwin = (VLWinComboBox.Text == "勝ち") ? "1" : "0";

                        //フォーマットID
                        SQLtext = "select ID from FORMAT " +
                            "where FORMATNAME = '" + VLFormatComboBox.Text + "'";
                        dt = cd.getDataTable(SQLtext);
                        foreach (DataRow row in dt.Rows)
                        {
                            formatid = System.Convert.ToInt32(row[0]);
                        }
                        Qformatid = formatid.ToString();

                        //先攻後攻
                        Qpracedence = (VLPracedenceComboBox.Text == "先行") ? "1" : "0";

                        //変更用クエリ作成
                        SQLtext = "update VSLOG " +
                            "set VSDATE = '" + VLDateTextBox.Text + "', " +
                            "MYDECKID = " + Qmydeckid + ", " +
                            "ENEMYDECKID = " + Qenemydeckid + ", " +
                            "WIN = " + Qwin + ", " +
                            "FORMATID = " + Qformatid + ", " +
                            "PRACEDENCE = " + Qpracedence + " " +
                            "where ID = " + VLIDTextBox.Text;

                        if (cd.executeSQL(SQLtext) > 0)
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
                        SQLtext = "delete from VSLOG " + "where ID = " + VLIDTextBox.Text;

                        if (cd.executeSQL(SQLtext) > 0)
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
                VSLogUpdateView();
            }
            else
            {
                MessageBox.Show("入力項目不足です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 戦績ログ:入力チェック
        /// </summary>
        /// <remarks>変更種別に応じてチェック</remarks>
        /// <returns>チェック結果</returns>
        private bool VSLogFormInputCheck()
        {
            //変更種別
            if (VLChangeGenreComboBox.Text != null)
            {
                switch (VLChangeGenreComboBox.Text)
                {
                    case "変更":
                        if (string.IsNullOrEmpty(VLIDTextBox.Text)) { return false; } //ID
                        if (string.IsNullOrEmpty(VLDateTextBox.Text)) { return false; } //日付
                        if (string.IsNullOrEmpty(VLMydeckMajorclassComboBox.Text)) { return false; } //自デッキ・大分類
                        if (string.IsNullOrEmpty(VLMydeckSmallclassComboBox.Text)) { return false; } //自デッキ・小分類
                        if (string.IsNullOrEmpty(VLEnemydeckMajorclassComboBox.Text)) { return false; } //相手デッキ・大分類
                        if (string.IsNullOrEmpty(VLEnemydeckSmallclassComboBox.Text)) { return false; } //相手デッキ・小分類
                        if (string.IsNullOrEmpty(VLWinComboBox.Text)) { return false; } //結果
                        if (string.IsNullOrEmpty(VLFormatComboBox.Text)) { return false; } //フォーマット
                        if (string.IsNullOrEmpty(VLPracedenceComboBox.Text)) { return false; } //先攻後攻
                        break;
                    case "削除":
                        if (string.IsNullOrEmpty(VLIDTextBox.Text)) { return false; } //ID
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        #region ログ入力

        /// <summary>
        /// ログ入力初期化処理
        /// </summary>
        private void InsertLogFormInit()
        {
            var MyDeckMajorclassDatasource = new List<string>();
            var EnemyDeckMajorclassDatasource = new List<string>();
            var FormatDatasource = new List<string>();
            DataTable dt = new DataTable();

            //デッキ名取得用クエリ作成
            string SQLtext = "select distinct MAJORCLASS from DECK";
            dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                MyDeckMajorclassDatasource.Add(Convert.ToString(row[0]));
                EnemyDeckMajorclassDatasource.Add(Convert.ToString(row[0]));
            }
            ILMydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
            ILEnemydeckMajorclassComboBox.DataSource = EnemyDeckMajorclassDatasource;

            //フォーマット名取得用クエリ作成
            SQLtext = "select FORMATNAME from FORMAT";
            dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                FormatDatasource.Add(Convert.ToString(row[0]));
            }
            ILFormatComboBox.DataSource = FormatDatasource;

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

        /// <summary>
        /// ログ入力:自デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            cd.GetDeckSmallclass(ILMydeckMajorclassComboBox, ILMydeckSmallclassComboBox);
        }

        /// <summary>
        /// ログ入力:相手デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILEnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            cd.GetDeckSmallclass(ILEnemydeckMajorclassComboBox, ILEnemydeckSmallclassComboBox);
        }

        /// <summary>
        /// ログ入力:ログ入力ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInsertButton_Click(object sender, EventArgs e)
        {
            if (InsertLogFormInputCheck())
            {
                int id = 0,
                    mydeckid = 0,
                    enemydeckid = 0,
                    formatid = 0;
                DataTable dt = new DataTable();

                //ID
                string SQLtext = "select ID from VSLOG";
                dt = cd.getDataTable(SQLtext);
                //最後のレコードのIDを取得する
                id = System.Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
                string Qid = id.ToString();

                //日付
                string Qvsdate = ILDateTextBox.Text;

                //自デッキID
                SQLtext = "select ID from DECK " +
                    "where MAJORCLASS = '" + ILMydeckMajorclassComboBox.Text + "' " +
                    "and SMALLCLASS = '" + ILMydeckSmallclassComboBox.Text + "'";
                dt = cd.getDataTable(SQLtext);
                mydeckid = System.Convert.ToInt32(dt.Rows[0][0]);
                string Qmydeckid = mydeckid.ToString();

                //相手デッキID
                SQLtext = "select ID from DECK " +
                    "where MAJORCLASS = '" + ILEnemydeckMajorclassComboBox.Text + "' " +
                    "and SMALLCLASS = '" + ILEnemydeckSmallclassComboBox.Text + "'";
                dt = cd.getDataTable(SQLtext);
                enemydeckid = System.Convert.ToInt32(dt.Rows[0][0]);
                string Qenemydeckid = enemydeckid.ToString();

                //結果
                string Qwin = (ILWinComboBox.Text == "勝ち") ? "1" : "0";

                //フォーマットID
                SQLtext = "select ID from FORMAT " +
                    "where FORMATNAME = '" + ILFormatComboBox.Text + "'";
                dt = cd.getDataTable(SQLtext);
                formatid = System.Convert.ToInt32(dt.Rows[0][0]);
                string Qformatid = formatid.ToString();

                //先行後攻
                string Qpracedence = (ILPracedenceComboBox.Text == "先行") ? "1" : "0";

                //DBにログ入力用クエリ作成
                SQLtext = "insert into VSLOG " +
                    "values( " +
                    " " + Qid + "," + //ID
                    " '" + Qvsdate + "'," + //日付
                    " " + Qmydeckid + "," + //自デッキID
                    " " + Qenemydeckid + "," + //相手デッキID
                    " " + Qwin + "," + //結果
                    " " + Qformatid + "," + //フォーマットID
                    " " + Qpracedence + //先行後攻
                    " )";

                if (cd.executeSQL(SQLtext) > 0)
                {
                    MessageBox.Show("ログに登録されました。", "ログ入力結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("ログに登録できませんでした。", "ログ入力結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("入力項目不足です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// ログ入力:入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        private bool InsertLogFormInputCheck()
        {
            if (string.IsNullOrEmpty(ILDateTextBox.Text)) { return false; } //日付
            if (string.IsNullOrEmpty(ILMydeckMajorclassComboBox.Text)) { return false; } //自デッキ・大分類
            if (string.IsNullOrEmpty(ILMydeckSmallclassComboBox.Text)) { return false; } //自デッキ・小分類
            if (string.IsNullOrEmpty(ILEnemydeckMajorclassComboBox.Text)) { return false; } //相手デッキ・大分類
            if (string.IsNullOrEmpty(ILEnemydeckSmallclassComboBox.Text)) { return false; } //相手デッキ・小分類
            if (string.IsNullOrEmpty(ILWinComboBox.Text)) { return false; } //結果
            if (string.IsNullOrEmpty(ILFormatComboBox.Text)) { return false; } //フォーマット
            if (string.IsNullOrEmpty(ILPracedenceComboBox.Text)) { return false; } //先攻後攻
            return true;
        }
        #endregion



        #region デッキ戦績

        /// <summary>
        /// デッキ戦績初期化処理
        /// </summary>
        private void DeckRecodeFormInit()
        {
            var DRMyDeckMajorclassDatasource = new List<string>();

            //デッキ名取得用クエリ作成
            string SQLtext = "select distinct MAJORCLASS from DECK";
            DataTable dt = cd.getDataTable(SQLtext);

            foreach (DataRow row in dt.Rows)
            {
                DRMyDeckMajorclassDatasource.Add(Convert.ToString(row[0]));
            }

            DRMydeckMajorclassComboBox.DataSource = DRMyDeckMajorclassDatasource;
        }

        /// <summary>
        /// デッキ戦績:戦績表示ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DRGetDeckRecordButton_Click(object sender, EventArgs e)
        {
            var decklist = new List<DeckList>(); //デッキリスト
            var viewlist = new List<DeckRecodeViewList>(); //表示用リスト
            DataTable dt = new DataTable();

            if (DeckRecodeFormInputCheck())
            {
                //デッキ一覧取得(デッキ大分類は昇順)用クエリ作成
                string SQLtext = "select ID, MAJORCLASS, SMALLCLASS from DECK order by MAJORCLASS";

                dt = cd.getDataTable(SQLtext);

                foreach (DataRow row in dt.Rows)
                {
                    decklist.Add(new DeckList(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2])));
                }

                //自デッキID取得
                SQLtext = "select ID from DECK " +
                    "where MAJORCLASS = '" + DRMydeckMajorclassComboBox.Text + "'" +
                    "and SMALLCLASS = '" + DRMydeckSmallclassComboBox.Text + "'";
                dt = cd.getDataTable(SQLtext);
                int mydeckid = System.Convert.ToInt32(dt.Rows[0][0]);

                //全体の勝率を取得
                SQLtext = "select count(*) from VSLOG " +
                        "where " +
                        "MYDECKID = " + mydeckid;
                dt = cd.getDataTable(SQLtext);
                int tortal_col = System.Convert.ToInt32(dt.Rows[0][0]);

                SQLtext = "select count(*) from VSLOG " +
                            "where " +
                            "MYDECKID = " + mydeckid + " " +
                            "and WIN = 1";
                dt = cd.getDataTable(SQLtext);
                float win = System.Convert.ToInt32(dt.Rows[0][0]);

                float total;
                //対戦したことがないなら「-」を入力する
                total = (tortal_col > 0) ? (win / tortal_col) * 100 : 999;

                string deckname = "全体";
                viewlist.Add(new DeckRecodeViewList(deckname, (int)total));

                //デッキ毎の勝率を取得
                foreach (var n in decklist)
                {
                    SQLtext = "select count(*) from VSLOG " +
                        "where " +
                        "MYDECKID = " + mydeckid + " " +
                        "and ENEMYDECKID = " + n.ID;
                    dt = cd.getDataTable(SQLtext);
                    tortal_col = System.Convert.ToInt32(dt.Rows[0][0]);

                    SQLtext = "select count(*) from VSLOG " +
                        "where " +
                        "MYDECKID = " + mydeckid + " " +
                        "and ENEMYDECKID = " + n.ID + " " +
                        "and WIN = 1";
                    dt = cd.getDataTable(SQLtext);
                    win = System.Convert.ToInt32(dt.Rows[0][0]);

                    //対戦したことがないなら「-」を入力する
                    total = (tortal_col > 0) ? (win / tortal_col) * 100 : 999;

                    deckname = n.Deck_majorclass + " " + n.Deck_smallclass;

                    viewlist.Add(new DeckRecodeViewList(deckname, (int)total));
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
            else
            {
                MessageBox.Show("入力項目不足です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// デッキ戦績:デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DRMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得
            cd.GetDeckSmallclass(DRMydeckMajorclassComboBox, DRMydeckSmallclassComboBox);
        }

        /// <summary>
        /// デッキ戦績:入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        private bool DeckRecodeFormInputCheck()
        {
            if (string.IsNullOrEmpty(DRMydeckMajorclassComboBox.Text)) { return false; } //自デッキ・大分類
            if (string.IsNullOrEmpty(DRMydeckSmallclassComboBox.Text)) { return false; } //自デッキ・小分類
            return true;
        }
        #endregion



        #region メタ分析

        /// <summary>
        /// メタ分析初期化処理
        /// </summary>
        private void MetaAnalyzeFormInit()
        {
            //期間コンボボックスの要素をセット
            var PeriodDatasource = new List<string> { "指定なし", "この1週間", "今月" };
            MAPeriodComboBox.DataSource = PeriodDatasource;
        }

        /// <summary>
        /// メタ分析:変更種別変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAPeriodComboBox_TextChanged(object sender, EventArgs e)
        {
            MoreDeckAnalyze();
            MetaDeckAnalyze();
        }

        /// <summary>
        /// メタ分析:最多デッキ分析処理
        /// </summary>
        private void MoreDeckAnalyze()
        {
            string SQLtext = "";
            DataTable dt = new DataTable();

            //変更種別に応じてクエリの条件を生成
            string wheretext = cd.createPeriodQuery(MAPeriodComboBox.Text);

            //最頻相手デッキID取得
            SQLtext = "select ENEMYDECKID from VSLOG " + wheretext +
                "group by ENEMYDECKID having count(*) >= (select max(cnt) from ( select count(*) as cnt from VSLOG" + wheretext +
                                                                                "group by ENEMYDECKID))";
            dt = cd.getDataTable(SQLtext);
            int moredeckid = System.Convert.ToInt32(dt.Rows[0][0]);

            //最頻相手デッキ名取得
            SQLtext = "select MAJORCLASS, SMALLCLASS from DECK " + "where ID = " + moredeckid;
            dt = cd.getDataTable(SQLtext);
            string moredeck = (dt.Rows[0][0] + " " + dt.Rows[0][1]);
            MAMetaAnalyzeDeckText.Text = moredeck;
        }

        /// <summary>
        /// メタ分析:環境メタデッキ分析処理
        /// </summary>
        private void MetaDeckAnalyze()
        {
            List<int> moredeckidList = new List<int>();

            string SQLtext = "";

            //ログから多い順にデッキ5つを抜き出し、リストに格納
            //対戦回数が多い順に相手デッキIDを取得
            SQLtext = "select ENEMYDECKID, count(*) AS CNT FROM VSLOG " + cd.createPeriodQuery(MAPeriodComboBox.Text) +
                "group by ENEMYDECKID order by CNT desc";

            DataTable dt = new DataTable();
            dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                moredeckidList.Add(System.Convert.ToInt32(row[0]));
            }

            //デッキ一覧を取得し、リスト化してスコア領域を追加し、0に設定(初期化)する
            DataTable DeckList = new DataTable();

            SQLtext = "select ID, MAJORCLASS, SMALLCLASS from DECK";
            DeckList = cd.getDataTable(SQLtext);

            DeckList.Columns.Add("score", typeof(int));
            for (int i = 0; i < DeckList.Rows.Count; i++)
            {
                DeckList.Rows[i]["score"] = 0;
            }

            //MATCHUPテーブルから相手デッキIDをキーにしてレコードを抜き出し、自デッキIDが合致するリストの要素にスコアを加算する
            foreach (int deckid in moredeckidList)
            {
                //相手デッキを指定してレコード取得
                SQLtext = "select MYDECK_ID, SCORE from MATCHUP where ENEMYDECK_ID = " + Convert.ToString(deckid);
                DataTable workdt = cd.getDataTable(SQLtext);

                foreach (DataRow row in workdt.Rows)
                {
                    int work;
                    //デッキリストを舐める
                    for (int i = 0; i < DeckList.Rows.Count; i++)
                    {
                        //自デッキIDが一致したら
                        if (Convert.ToInt32(DeckList.Rows[i]["ID"]) == Convert.ToInt32(row["MYDECK_ID"]))
                        {
                            //一旦保持して加算、その後格納
                            work = Convert.ToInt32(DeckList.Rows[i]["SCORE"]);
                            work += Convert.ToInt32(row["SCORE"]);
                            DeckList.Rows[i]["SCORE"] = work;
                            break;
                        }
                    }
                }
            }

            //リストをスコア順に並び替え、上位5つを表示する
            DataView dv = new DataView(DeckList);
            dv.Sort = "SCORE DESC";
            DeckList = dv.ToTable();

            string str = "";
            int displayMax = (DeckList.Rows.Count < 5) ? DeckList.Rows.Count : 5;
            for (int i = 0; i < displayMax; i++)
            {
                str += Convert.ToString(i + 1) + "." + DeckList.Rows[i]["MAJORCLASS"] + " " + DeckList.Rows[i]["SMALLCLASS"] + "\n";
            }
            MetaDeckAnalyzeLabel.Text = str;
        }
    }
    #endregion



    #region データセットクラス
    /// <summary>
    /// 戦績ログクラス
    /// </summary>
    class LogData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        public string Vsdate { get; set; }

        /// <summary>
        /// 自デッキ・大分類
        /// </summary>
        public string Mydeck_majorclass { get; set; }

        /// <summary>
        /// 自デッキ・小分類
        /// </summary>
        public string Mydeck_smallclass { get; set; }

        /// <summary>
        /// 相手デッキ・大分類
        /// </summary>
        public string Enemydeck_majorclass { get; set; }

        /// <summary>
        /// 相手デッキ・小分類
        /// </summary>
        public string Enemydeck_smallclass { get; set; }

        /// <summary>
        /// 結果
        /// </summary>
        /// <remarks>
        /// "勝ち" or "負け"
        /// </remarks>
        public string Win { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 先行後攻
        /// </summary>
        /// <remarks>
        /// "先行" or "後攻"
        /// </remarks>
        public string Pracedence { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="vsdate">日付</param>
        /// <param name="mydeck_majorclass">自デッキ・大分類</param>
        /// <param name="mydeck_smallclass">自デッキ・小分類</param>
        /// <param name="enemydeck_majorclass">相手デッキ・大分類</param>
        /// <param name="enemydeck_smallclass">相手デッキ・小分類</param>
        /// <param name="win">結果</param>
        /// <param name="format">フォーマット</param>
        /// <param name="pracedence">先行後攻</param>
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

    /// <summary>
    /// 戦績ログクラス
    /// </summary>
    class DeckList
    {
        /// <summary>
        /// デッキID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// デッキ・大分類
        /// </summary>
        public string Deck_majorclass { get; set; }

        /// <summary>
        /// デッキ・小分類
        /// </summary>
        public string Deck_smallclass { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">デッキID</param>
        /// <param name="deck_majorclass">デッキ・大分類</param>
        /// <param name="deck_smallclass">デッキ・小分類</param>
        public DeckList(object id, string deck_majorclass, string deck_smallclass)
        {
            this.ID = System.Convert.ToInt32(id);
            this.Deck_majorclass = deck_majorclass;
            this.Deck_smallclass = deck_smallclass;
        }
    }

    /// <summary>
    /// デッキ戦績表示用クラス
    /// </summary>
    class DeckRecodeViewList
    {
        /// <summary>
        /// デッキ名
        /// </summary>
        public string Deckname { get; set; }

        /// <summary>
        /// 対戦戦績(%)
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="deckname">デッキ名</param>
        /// <param name="total">戦績(%)</param>
        public DeckRecodeViewList(string deckname, int total)
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
    #endregion
}
