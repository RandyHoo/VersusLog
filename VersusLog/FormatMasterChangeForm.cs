using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace VersusLog
{
    public partial class FormatMasterChangeForm : Form
    {
        public FormatMasterChangeForm()
        {
            InitializeComponent();

            //初期化処理
            FormatMasterChangeFormInit();
        }

        /// <summary>
        /// フォーマットマスタ初期化処理
        /// </summary>
        private void FormatMasterChangeFormInit()
        {
            //変更種別コンボボックスの要素入力
            var ChangeGenreDatasource = new List<string> { "変更", "追加", "削除" };
            ChangeGenreComboBox.DataSource = ChangeGenreDatasource;

            //フォーマットマスタ表示
            UpdateView();
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
        /// 実行ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (FormatMasterChangeFormCheck())
            {
                string SQLtext = "";
                CommonData cd = new CommonData();

                //変更種別ごとにコマンド生成
                switch (ChangeGenreComboBox.Text)
                {
                    case "変更":
                        SQLtext = "update FORMAT " +
                            "set FORMATNAME = '" + FormatNameTextBox.Text + "' " +
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
                        SQLtext = "select ID from FORMAT";
                        DataTable dt = cd.getDataTable(SQLtext);
                        int id = System.Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
                        
                        SQLtext = "insert into FORMAT " +
                            "values( " +
                            " " + id.ToString() + "," + //ID
                            " '" + FormatNameTextBox.Text + "' " + //フォーマット名
                            ")";

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
                        SQLtext = "delete from FORMAT " +
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
        /// ID変更時デフォルト値入力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            CommonData cd = new CommonData();

            //変更の場合元々入っている値をデフォ値にする
            if (ChangeGenreComboBox.Text == "変更" && IDTextBox.Text != "")
            {
                string SQLtext = "select FORMATNAME " +
                    "from FORMAT " +
                    "where ID = " + IDTextBox.Text;
                DataTable dt = cd.getDataTable(SQLtext);

                if (dt.Rows.Count != 0)
                {
                    FormatNameTextBox.Text = Convert.ToString(dt.Rows[0][0]); //フォーマット名
                }
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
                    FormatNameTextBox.Text = "";
                    FormatNameTextBox.ReadOnly = false;
                    break;
                case "追加":
                    IDTextBox.Text = "自動入力";
                    IDTextBox.ReadOnly = true;
                    FormatNameTextBox.Text = "";
                    FormatNameTextBox.ReadOnly = false;
                    break;
                case "削除":
                    IDTextBox.Text = "";
                    IDTextBox.ReadOnly = false;
                    FormatNameTextBox.Text = "入力不要";
                    FormatNameTextBox.ReadOnly = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 表示更新処理
        /// </summary>
        private void UpdateView()
        {
            var displaylist = new List<FormatData>();
            string SQLtext = "";
            CommonData cd = new CommonData();

            //フォーマット一覧取得
            SQLtext = "select * from FORMAT";
            DataTable dt = cd.getDataTable(SQLtext);
            foreach (DataRow row in dt.Rows)
            {
                displaylist.Add(new FormatData(
                    row[0], //ID
                    Convert.ToString(row[1]) //フォーマット名
                    ));
            }

            FormatMasterGridView.DataSource = displaylist;

            //FormatMasterGridViewの列ヘッダーの表示を日本語にする
            var cheaderlist = new List<string> { "ID", "フォーマット名" };
            for (int i = 0; i < FormatMasterGridView.Columns.Count; i++)
            {
                FormatMasterGridView.Columns[i].HeaderText = cheaderlist[i];
            }

            //表示幅の自動修正をON
            FormatMasterGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FormatMasterGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            FormatMasterGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        /// <summary>
        /// 表示更新ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateViewButton_Click(object sender, EventArgs e)
        {
            //フォーマットマスタ更新
            UpdateView();
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <remarks>変更種別に応じてチェック</remarks>
        /// <returns>チェック結果</returns>
        private bool FormatMasterChangeFormCheck()
        {
            //変更種別
            if (ChangeGenreComboBox.Text != null)
            {
                switch (ChangeGenreComboBox.Text)
                {
                    case "変更":
                        if (string.IsNullOrEmpty(IDTextBox.Text)) { return false; } //ID
                        if (string.IsNullOrEmpty(FormatNameTextBox.Text)) { return false; } //フォーマット名
                        break;
                    case "追加":
                        if (string.IsNullOrEmpty(FormatNameTextBox.Text)) { return false; } //フォーマット名
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

    /// <summary>
    /// フォーマットデータクラス
    /// </summary>
    class FormatData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// フォーマット名
        /// </summary>
        public string Formatname { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="formatname">フォーマット名</param>
        public FormatData(object id, string formatname)
        {
            this.Id = System.Convert.ToInt32(id);
            this.Formatname = formatname;
        }
    }
}
