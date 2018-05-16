using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace VersusLog
{
    public partial class DeckMasterChangeForm : Form
    {
        CommonData cd = new CommonData();
        VSLogCommon VSLogCommon = new VSLogCommon();

        public DeckMasterChangeForm()
        {
            InitializeComponent();

            //初期化処理
            DeckChangeMasterInit();
        }

        /// <summary>
        /// デッキマスタ初期化処理
        /// </summary>
        private void DeckChangeMasterInit()
        {
            //変更種別コンボボックスの要素入力
            var ChangeGenreDatasource = new List<string> { "変更", "追加", "削除" };
            ChangeGenreComboBox.DataSource = ChangeGenreDatasource;

            //デッキマスタ表示
            UpdateView();
        }

        /// <summary>
        /// 実行ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (DeckMasterChangeFormInputCheck())
            {
                string SQLtext = "";

                //変更種別ごとにクエリ作成
                switch (ChangeGenreComboBox.Text)
                {
                    case "変更":
                        SQLtext = "update DECK " +
                            "set MAJORCLASS = " + cd.surroundApos(MajorclassTextBox.Text) + "," +
                            "SMALLCLASS = " + cd.surroundApos(SmallclassTextBox.Text) + "," +
                            "DECKTYPE1 = " + cd.surroundApos(Decktype1TextBox.Text) + "," +
                            "DECKTYPE2 = " + cd.surroundApos(Decktype2TextBox.Text) + " " +
                            "where ID = " + IDTextBox.Text;

                        if (cd.executeSQL(SQLtext) > 0)
                        {
                            MessageBox.Show("DBが変更されました。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("DBを変更できませんでした。", "変更結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;

                    case "追加":

                        //追加データ用のID生成
                        int id = VSLogCommon.getNewID("DECK");

                        SQLtext = "insert into DECK " +
                            "values( " +
                            id.ToString() + "," +                             //ID
                            cd.surroundApos(MajorclassTextBox.Text) + "," +   //デッキ大分類
                            cd.surroundApos(SmallclassTextBox.Text) + "," +   //デッキ小分類
                            cd.surroundApos(Decktype1TextBox.Text) + "," +    //デッキタイプ1
                            cd.surroundApos(Decktype2TextBox.Text) + ")";     //デッキタイプ2

                        if (cd.executeSQL(SQLtext) > 0)
                        {
                            MessageBox.Show("DBに追加されました。", "追加結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("DBに追加できませんでした。", "追加結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;

                    case "削除":
                        //削除用クエリ作成
                        SQLtext = "delete from DECK " +
                            "where ID = " + IDTextBox.Text;

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
            }
            else
            {
                MessageBox.Show("入力項目不足です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 変更種別変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeGenreComboBox_TextChanged(object sender, EventArgs e)
        {
            //変更種別ごとに入力規制
            switch (ChangeGenreComboBox.Text)
            {
                case "変更":
                    IDTextBox.Text = "";
                    IDTextBox.ReadOnly = false;
                    MajorclassTextBox.Text = "";
                    MajorclassTextBox.ReadOnly = false;
                    SmallclassTextBox.Text = "";
                    SmallclassTextBox.ReadOnly = false;
                    Decktype1TextBox.Text = "";
                    Decktype1TextBox.ReadOnly = false;
                    Decktype2TextBox.Text = "";
                    Decktype2TextBox.ReadOnly = false;
                    break;
                case "追加":
                    IDTextBox.Text = "自動入力";
                    IDTextBox.ReadOnly = true;
                    MajorclassTextBox.Text = "";
                    MajorclassTextBox.ReadOnly = false;
                    SmallclassTextBox.Text = "";
                    SmallclassTextBox.ReadOnly = false;
                    Decktype1TextBox.Text = "";
                    Decktype1TextBox.ReadOnly = false;
                    Decktype2TextBox.Text = "";
                    Decktype2TextBox.ReadOnly = false;
                    break;
                case "削除":
                    IDTextBox.Text = "";
                    IDTextBox.ReadOnly = false;
                    MajorclassTextBox.Text = "入力不要";
                    MajorclassTextBox.ReadOnly = true;
                    SmallclassTextBox.Text = "入力不要";
                    SmallclassTextBox.ReadOnly = true;
                    Decktype1TextBox.Text = "入力不要";
                    Decktype1TextBox.ReadOnly = true;
                    Decktype2TextBox.Text = "入力不要";
                    Decktype2TextBox.ReadOnly = true;
                    break;
                default:
                    break;
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
            this.Hide();
        }


        /// <summary>
        /// ID変更時デフォルト値入力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            //変更の場合既存の値をデフォ値にする
            if (ChangeGenreComboBox.Text == "変更" && IDTextBox.Text != "")
            {
                //デフォルト値として既存の値を設定
                string SQLtext = "select MAJORCLASS, SMALLCLASS, DECKTYPE1, DECKTYPE2 " +
                    "from DECK " +
                    "where ID = " + IDTextBox.Text;
                DataTable dt = cd.getDataTable(SQLtext);

                MajorclassTextBox.Text = dt.Rows[0][0].ToString(); //デッキ大分類
                SmallclassTextBox.Text = (dt.Rows[0][1] == null) ? null : dt.Rows[0][1].ToString(); //デッキ小分類
                Decktype1TextBox.Text = (dt.Rows[0][2] == null) ? null : dt.Rows[0][2].ToString(); //デッキタイプ1
                Decktype2TextBox.Text = (dt.Rows[0][3] == null) ? null : dt.Rows[0][3].ToString(); //デッキタイプ2

            }
        }

        /// <summary>
        /// 表示更新ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateViewButton_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        /// <summary>
        /// 表示更新処理
        /// </summary>
        private void UpdateView()
        {
            var displaylist = new List<DeckData>();

            //デッキ一覧取得
            string SQLtext = "select * from DECK";
            DataTable dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                displaylist.Add(new DeckData(
                        row[0], //ID
                        row[1].ToString(), //デッキ大分類
                        row[2].ToString(), //デッキ小分類
                        row[3].ToString(), //デッキタイプ1
                        row[4].ToString() //デッキタイプ2
                        ));
            }
            DeckMasterGridView.DataSource = displaylist;


            //DeckMasterGridViewの列ヘッダーの表示を日本語にする
            var cheaderlist = new List<string> { "ID", "デッキ大分類", "デッキ小分類", "デッキタイプ1", "デッキタイプ2" };
            cd.setDataGridViewHeader(cheaderlist, DeckMasterGridView);

            //表示幅の自動修正をON
            DeckMasterGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DeckMasterGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DeckMasterGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <remarks>変更種別に応じてチェック</remarks>
        /// <returns>チェック結果</returns>
        private bool DeckMasterChangeFormInputCheck()
        {
            //変更種別
            if (ChangeGenreComboBox.Text != null)
            {
                switch (ChangeGenreComboBox.Text)
                {
                    case "変更":
                        if (string.IsNullOrEmpty(IDTextBox.Text)) { return false; } //ID
                        if (string.IsNullOrEmpty(MajorclassTextBox.Text)) { return false; } //デッキ・大分類
                        if (string.IsNullOrEmpty(SmallclassTextBox.Text)) { return false; } //デッキ・小分類
                        if (string.IsNullOrEmpty(Decktype1TextBox.Text)) { return false; } //デッキタイプ1
                        if (string.IsNullOrEmpty(Decktype2TextBox.Text)) { return false; } //デッキタイプ2
                        break;
                    case "追加":
                        if (string.IsNullOrEmpty(MajorclassTextBox.Text)) { return false; } //デッキ・大分類
                        if (string.IsNullOrEmpty(SmallclassTextBox.Text)) { return false; } //デッキ・小分類
                        if (string.IsNullOrEmpty(Decktype1TextBox.Text)) { return false; } //デッキタイプ1
                        if (string.IsNullOrEmpty(Decktype2TextBox.Text)) { return false; } //デッキタイプ2
                        break;
                    case "削除":
                        if (string.IsNullOrEmpty(IDTextBox.Text)) { return false; } //ID
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
