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
    public partial class DeckMasterChangeForm : Form
    {
        public DeckMasterChangeForm()
        {
            InitializeComponent();

            var ChangeGenreDatasource = new List<string> { "変更", "追加", "削除" };
            ChangeGenreComboBox.DataSource = ChangeGenreDatasource;

            UpdateView();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //変更種別ごとにクエリ作成
                    switch (ChangeGenreComboBox.Text)
                    {
                        case "変更":
                            //変更用クエリ作成
                            cmd.CommandText = "update DECK " +
                                "set MAJORCLASS = '" + MajorclassTextBox.Text + "', " +
                                "SMALLCLASS = '" + SmallclassTextBox.Text + "', " +
                                "DECKTYPE1 = '" + Decktype1TextBox.Text + "', " +
                                "DECKTYPE2 = '" + Decktype2TextBox.Text + "' " +
                                "where ID = " + IDTextBox.Text;

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

                        case "追加":
                            int id = 0;

                            //ID取得用クエリ作成
                            cmd.CommandText = "select ID from DECK";
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

                            //追加用クエリ作成
                            cmd.CommandText = "insert into DECK " +
                                "values( " +
                                " " + Qid + "," + //ID
                                " '" + MajorclassTextBox.Text + "'," + //デッキ大分類
                                " '" + SmallclassTextBox.Text + "'," + //デッキ小分類
                                " '" + Decktype1TextBox.Text + "'," + //デッキタイプ1
                                " '" + Decktype2TextBox.Text + "'" + //デッキタイプ2
                                " )";

                            count = cmd.ExecuteNonQuery();

                            if (count > 0)
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
                            cmd.CommandText = "delete from DECK " +
                                "where ID = " + IDTextBox.Text;

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

        private void BackMainMenuButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new MainMenuForm();
            ViewForm.Show();
            this.Hide();
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            //変更の場合、元々入っている値をデフォ値にするための処理
            if (ChangeGenreComboBox.Text == "変更" && IDTextBox.Text != "")
            {
                using (var con = new SQLiteConnection(CommonData.ConnectionString))
                {
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {
                        //元々入っている値取得用クエリ
                        cmd.CommandText = "select MAJORCLASS, SMALLCLASS, DECKTYPE1, DECKTYPE2 " +
                            "from DECK " +
                            "where ID = " + IDTextBox.Text;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MajorclassTextBox.Text = reader.GetString(0); //デッキ大分類
                                SmallclassTextBox.Text = (reader.IsDBNull(1)) ? null : reader.GetString(1); //デッキ小分類
                                Decktype1TextBox.Text = (reader.IsDBNull(2)) ? null : reader.GetString(2); //デッキタイプ1
                                Decktype2TextBox.Text = (reader.IsDBNull(3)) ? null : reader.GetString(3); //デッキタイプ2
                            }
                        }
                    }

                    con.Close();
                }
            }
        }

        private void UpdateViewButton_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            var displaylist = new List<DeckData>();

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    //デッキ一覧取得用クエリ作成
                    cmd.CommandText = "select * from DECK";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            displaylist.Add(new DeckData(
                                reader.GetValue(0), //ID
                                reader.GetString(1), //デッキ大分類
                                reader.GetString(2), //デッキ小分類
                                reader.GetString(3), //デッキタイプ1
                                reader.GetString(4) //デッキタイプ2
                                ));
                        }
                        DeckMasterGridView.DataSource = displaylist;

                        //LogGridViewの列ヘッダーの表示を日本語にする
                        var cheaderlist = new List<string> { "ID", "デッキ大分類", "デッキ小分類", "デッキタイプ1", "デッキタイプ2" };
                        for (int i = 0; i < DeckMasterGridView.Columns.Count; i++)
                        {
                            DeckMasterGridView.Columns[i].HeaderText = cheaderlist[i];
                        }

                        //表示幅の自動修正をON
                        DeckMasterGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        DeckMasterGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        DeckMasterGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                    }
                }

                con.Close();
            }
        }

        //表示用デッキデータ
        class DeckData
        {
            //ID
            public int Id { get; set; }

            //デッキ大分類
            public string Majorclass { get; set; }

            //デッキ小分類
            public string Smallclass { get; set; }

            //デッキタイプ1
            public string Decktype1 { get; set; }

            //デッキタイプ2
            public string DeckType2 { get; set; }

            public DeckData(object id, string majorclass, string smallclass, string decktype1, string decktype2)
            {
                this.Id = System.Convert.ToInt32(id);
                this.Majorclass = majorclass;
                this.Smallclass = smallclass;
                this.Decktype1 = decktype1;
                this.DeckType2 = decktype2;
            }
        }
    }
}
