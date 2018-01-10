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
    public partial class FormatMasterChangeForm : Form
    {
        private const string ConnectionString = @"Data Source=vslog.db";

        public FormatMasterChangeForm()
        {
            InitializeComponent();

            var ChangeGenreDatasource = new List<string> { "変更", "追加", "削除" };
            ChangeGenreComboBox.DataSource = ChangeGenreDatasource;

            UpdateView();
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
            //変更の場合元々入っている値をデフォ値にする
            if (ChangeGenreComboBox.Text == "変更" && IDTextBox.Text != "")
            {
                using (var con = new SQLiteConnection(ConnectionString))
                {
                    //DB接続
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {

                        //クエリ作成
                        cmd.CommandText = "select FORMATNAME " +
                            "from FORMAT " +
                            "where ID = " + IDTextBox.Text;

                        //コマンド実行
                        using (var reader = cmd.ExecuteReader())
                        {
                            //読み出し
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(0) == false)
                                {
                                    FormatNameTextBox.Text = reader.GetString(0); //デッキ小分類
                                }
                            }
                        }
                    }

                    //DB切断
                    con.Close();
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

                            //変更用クエリ作成
                            cmd.CommandText = "update FORMAT " +
                                "set FORMATNAME = '" + FormatNameTextBox.Text + "' " +
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
                case "追加":
                    using (var con = new SQLiteConnection(ConnectionString))
                    {
                        //DB接続
                        con.Open();

                        int id = 0;
                        string Qid;
                        using (var cmd = con.CreateCommand())
                        {
                            //ID取得用コマンド生成
                            cmd.CommandText = "select ID from FORMAT";
                            using (var reader = cmd.ExecuteReader())
                            {
                                //最後のレコードのIDを取得する
                                while (reader.Read())
                                {
                                    id = (int)(long)reader.GetValue(0);
                                }
                                id += 1;
                            }
                            Qid = id.ToString();

                            //追加用クエリ作成
                            cmd.CommandText = "insert into FORMAT " +
                                "values( " +
                                " " + Qid + "," + //ID
                                " '" + FormatNameTextBox.Text + "' " + //フォーマット名
                                ")";

                            //コマンド実行
                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("DBに追加されました。", "追加結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show("DBに追加できませんでした。", "追加結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                            cmd.CommandText = "delete from FORMAT " +
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

        private void UpdateView()
        {
            var displaylist = new List<FormatData>(); //表示用リスト

            using (var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "select * from FORMAT";

                    //コマンド実行
                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
                        while (reader.Read())
                        {
                            displaylist.Add(new FormatData(reader.GetValue(0), reader.GetString(1)));
                        }
                        FormatMasterGridView.DataSource = displaylist;

                        //LogGridViewの列ヘッダーの表示を日本語にする
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
                }

                //DB切断
                con.Close();
            }
        }

        //表示用デッキデータ
        class FormatData
        {
            public int Id { get; set; }
            public string Formatname { get; set; }

            public FormatData(object id, string formatname)
            {
                this.Id = (int)(long)id;
                this.Formatname = formatname;
            }
        }

        private void UpdateViewButton_Click(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
