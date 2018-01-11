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
    public partial class DeckRecordForm : Form
    {
        public DeckRecordForm()
        {
            InitializeComponent();

            var MyDeckMajorclassDatasource = new List<string>();

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
                        }
                        MydeckMajorclassComboBox.DataSource = MyDeckMajorclassDatasource;
                    }
                }

                con.Close();
            }
        }

        private void GetDeckRecordButton_Click(object sender, EventArgs e)
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
                        "where MAJORCLASS = '" + MydeckMajorclassComboBox.Text + "'" +
                        "and SMALLCLASS = '" + MydeckSmallclassComboBox.Text + "'";
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
                    DeckRecodeView.DataSource = viewlist;

                    //DeckRecodeViewの列ヘッダーの表示を日本語にする
                    var cheaderlist = new List<string> { "デッキ", "勝率(%)" };
                    for (int i = 0; i < DeckRecodeView.Columns.Count; i++)
                    {
                        DeckRecodeView.Columns[i].HeaderText = cheaderlist[i];
                    }

                    //表示幅の自動修正をON
                    DeckRecodeView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DeckRecodeView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }

                con.Close();
            }
        }

        //自デッキ・大分類変更時に小分類を取得する
        private void MydeckMajorclassComboBox_TextChanged(object sender, EventArgs e)
        {
            //デッキ小分類を取得
            CommonData.GetDeckSmallclass(MydeckMajorclassComboBox, MydeckSmallclassComboBox);
        }

        private void BackMainMenuButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new MainMenuForm();
            ViewForm.Show();
            this.Hide();
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