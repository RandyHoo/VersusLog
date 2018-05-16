using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace VersusLog
{
    public partial class VSLogForm : Form
    {
        CommonData cd = new CommonData();
        VSLogCommon VSLogCommon = new VSLogCommon();
        VSLogMethod VSLog = new VSLogMethod();
        DeckRecodeMethod DeckRecode = new DeckRecodeMethod();
        MetaAnalyzeMethod MetaAnalyze = new MetaAnalyzeMethod();

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
            //自デッキ、相手デッキ 大分類コンボボックスの要素をセット
            List<string> DeckMajorclassDatasource = VSLogCommon.getDeckMajorClassList();
            VLMydeckMajorclassComboBox.DataSource = DeckMajorclassDatasource;
            VLEnemydeckMajorclassComboBox.DataSource = DeckMajorclassDatasource;

            //フォーマットコンボボックスの要素をセット
            List<string> FormatDatasource = VSLogCommon.getFormatList();
            VLFormatComboBox.DataSource = FormatDatasource;

            //結果コンボボックスの要素入力
            var WinDatasource = new List<string> { "勝ち", "負け" };
            VLWinComboBox.DataSource = WinDatasource;

            //先攻後攻コンボボックスの要素入力
            var PracedenceDatasource = new List<string> { "先攻", "後攻" };
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
            //戦績ログ(絞込無し)取得
            List<LogData> displaylist = VSLog.getVSLog();
            VLLogGridView.DataSource = displaylist;

            //LogGridViewの列ヘッダーの表示を日本語にする
            var cheaderlist = new List<string> { "ID", "日付", "自デッキ・大分類", "自デッキ・小分類", "相手デッキ・大分類", "相手デッキ・小分類", "結果", "フォーマット", "先行後攻" };
            cd.setDataGridViewHeader(cheaderlist, VLLogGridView);

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
            VSLogCommon.GetDeckSmallclass(VLMydeckMajorclassComboBox, VLMydeckSmallclassComboBox);
        }

        /// <summary>
        /// 戦績ログ:相手デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VLEnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            VSLogCommon.GetDeckSmallclass(VLEnemydeckMajorclassComboBox, VLEnemydeckSmallclassComboBox);
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
                        //結果
                        string Qwin = (VLWinComboBox.Text == "勝ち") ? "1" : "0";

                        //先攻後攻
                        string Qpracedence = (VLPracedenceComboBox.Text == "先行") ? "1" : "0";

                        //変更用クエリ作成
                        SQLtext = "update VSLOG " +
                            "set VSDATE = " + cd.surroundApos(VLDateTextBox.Text) + ", " +
                            "MYDECKID = " + VSLogCommon.getDeckID(VLMydeckMajorclassComboBox.Text, VLMydeckSmallclassComboBox.Text).ToString() + ", " +
                            "ENEMYDECKID = " + VSLogCommon.getDeckID(VLEnemydeckMajorclassComboBox.Text, VLEnemydeckSmallclassComboBox.Text).ToString() + ", " +
                            "WIN = " + Qwin + ", " +
                            "FORMATID = " + VSLogCommon.getFormatID(VLFormatComboBox.Text).ToString() + ", " +
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

        /// <summary>
        /// 変更種別変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VLChangeGenreComboBox_TextChanged(object sender, EventArgs e)
        {
            //変更種別ごとに入力規制
            switch (VLChangeGenreComboBox.Text)
            {
                case "変更":
                    VLIDTextBox.Text = "";
                    VLIDTextBox.ReadOnly = false;
                    VLDateTextBox.Text = "";
                    VLDateTextBox.ReadOnly = false;
                    VLMydeckMajorclassComboBox.Text = "";
                    VLMydeckMajorclassComboBox.Enabled = true;
                    VLMydeckSmallclassComboBox.Text = "";
                    VLMydeckSmallclassComboBox.Enabled = true;
                    VLEnemydeckMajorclassComboBox.Text = "";
                    VLEnemydeckMajorclassComboBox.Enabled = true;
                    VLEnemydeckSmallclassComboBox.Text = "";
                    VLEnemydeckSmallclassComboBox.Enabled = true;
                    VLWinComboBox.Text = "";
                    VLWinComboBox.Enabled = true;
                    VLFormatComboBox.Text = "";
                    VLFormatComboBox.Enabled = true;
                    VLPracedenceComboBox.Text = "";
                    VLPracedenceComboBox.Enabled = true;
                    break;
                case "削除":
                    VLIDTextBox.Text = "";
                    VLIDTextBox.ReadOnly = false;
                    VLDateTextBox.Text = "入力不要";
                    VLDateTextBox.ReadOnly = true;
                    VLMydeckMajorclassComboBox.Text = "入力不要";
                    VLMydeckMajorclassComboBox.Enabled = false;
                    VLMydeckSmallclassComboBox.Text = "入力不要";
                    VLMydeckSmallclassComboBox.Enabled = false;
                    VLEnemydeckMajorclassComboBox.Text = "入力不要";
                    VLEnemydeckMajorclassComboBox.Enabled = false;
                    VLEnemydeckSmallclassComboBox.Text = "入力不要";
                    VLEnemydeckSmallclassComboBox.Enabled = false;
                    VLWinComboBox.Text = "入力不要";
                    VLWinComboBox.Enabled = false;
                    VLFormatComboBox.Text = "入力不要";
                    VLFormatComboBox.Enabled = false;
                    VLPracedenceComboBox.Text = "入力不要";
                    VLPracedenceComboBox.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        #endregion



        #region ログ入力

        /// <summary>
        /// ログ入力初期化処理
        /// </summary>
        private void InsertLogFormInit()
        {
            //デッキ 大分類取得
            List<string> DeckMajorclassDatasource = VSLogCommon.getDeckMajorClassList();
            ILMydeckMajorclassComboBox.DataSource = DeckMajorclassDatasource;
            ILEnemydeckMajorclassComboBox.DataSource = DeckMajorclassDatasource;

            //フォーマット名取得
            List<string> FormatDatasource = VSLogCommon.getFormatList();
            ILFormatComboBox.DataSource = FormatDatasource;

            //結果コンボボックスの要素入力
            var WinDatasource = new List<string> { "勝ち", "負け" };
            ILWinComboBox.DataSource = WinDatasource;

            //先行後攻コンボボックスの要素入力
            var PracedenceDatasource = new List<string> { "先攻", "後攻" };
            ILPracedenceComboBox.DataSource = PracedenceDatasource;

            //日付のデフォ値(今日の日付)を入力
            ILDateTextBox.Text = cd.getToday();
        }

        /// <summary>
        /// ログ入力:自デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILMydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            VSLogCommon.GetDeckSmallclass(ILMydeckMajorclassComboBox, ILMydeckSmallclassComboBox);
        }

        /// <summary>
        /// ログ入力:相手デッキ大分類入力時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILEnemydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得しセット
            VSLogCommon.GetDeckSmallclass(ILEnemydeckMajorclassComboBox, ILEnemydeckSmallclassComboBox);
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
                //ID
                int id = VSLogCommon.getNewID("VSLOG");

                //結果
                string Qwin = (ILWinComboBox.Text == "勝ち") ? "1" : "0";

                //先行後攻
                string Qpracedence = (ILPracedenceComboBox.Text == "先行") ? "1" : "0";

                //DBにログ入力用クエリ作成
                string SQLtext = "insert into VSLOG " +
                    "values( " +
                    id.ToString() + "," +                                                                                               //ID
                    cd.surroundApos(ILDateTextBox.Text) + "," +                                                                         //日付
                    VSLogCommon.getDeckID(ILMydeckMajorclassComboBox.Text, ILMydeckSmallclassComboBox.Text).ToString() + "," +          //自デッキID
                    VSLogCommon.getDeckID(ILEnemydeckMajorclassComboBox.Text, ILEnemydeckSmallclassComboBox.Text).ToString() + "," +    //相手デッキID
                    Qwin + "," +                                                                                                        //結果
                    VSLogCommon.getFormatID(ILFormatComboBox.Text).ToString() + "," +                                                   //フォーマットID
                    Qpracedence +                                                                                                       //先行後攻
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
            //デッキ名一覧取得
            List<string> DRMyDeckMajorclassDatasource = VSLogCommon.getDeckMajorClassList();
            DRMydeckMajorclassComboBox.DataSource = DRMyDeckMajorclassDatasource;
        }

        /// <summary>
        /// デッキ戦績:戦績表示ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DRGetDeckRecordButton_Click(object sender, EventArgs e)
        {
            if (DeckRecodeFormInputCheck())
            {
                //デッキ一覧取得(デッキ大分類は昇順)
                List<DeckList> decklist = DeckRecode.GetDeckList();

                //自デッキID取得
                int mydeckid = VSLogCommon.getDeckID(DRMydeckMajorclassComboBox.Text, DRMydeckSmallclassComboBox.Text);

                //全体・デッキ毎の勝率を取得し、ソースとしてセット
                DRDeckRecodeView.DataSource = DeckRecode.getDeckRecode(mydeckid, decklist);

                //DRDeckRecodeViewの列ヘッダーの表示を日本語にする
                var cheaderlist = new List<string> { "デッキ", "勝率(%)" };
                cd.setDataGridViewHeader(cheaderlist, DRDeckRecodeView);

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
            VSLogCommon.GetDeckSmallclass(DRMydeckMajorclassComboBox, DRMydeckSmallclassComboBox);
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
            MAMetaAnalyzeDeckText.Text = MetaAnalyze.MoreDeckAnalyze(MAPeriodComboBox.Text);
            MetaDeckAnalyzeLabel.Text = MetaAnalyze.MetaDeckAnalyze(MAPeriodComboBox.Text);
        }
    }
    #endregion
}
