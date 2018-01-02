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
    public partial class Form1 : Form
    {
        private const string ConnectionString = @"Data Source=vslog.db";

        public Form1()
        {
            InitializeComponent();
        }

        private void DataGetButton_Click(object sender, EventArgs e)
        {
            //表示用リスト生成
            var displaylist = new List<LogData>();

            using(var con = new SQLiteConnection(ConnectionString))
            {
                //DB接続
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //戦績ログ(絞込無し)取得用クエリ作成
                    cmd.CommandText = "select VSLOG.VSDATE, MYDECK.MAJORCLASS, MYDECK.SMALLCLASS, ENEMYDECK.MAJORCLASS, ENEMYDECK.SMALLCLASS, VSLOG.WIN, FORMAT.FORMATNAME, VSLOG.PRACEDENCE " +
                        "from VSLOG " +
                        "inner join DECK as MYDECK on VSLOG.MYDECKID = MYDECK.ID " +
                        "inner join DECK as ENEMYDECK on VSLOG.ENEMYDECKID = ENEMYDECK.ID " +
                        "inner join FORMAT on VSLOG.FORMATID = FORMAT.ID";

                    using (var reader = cmd.ExecuteReader())
                    {
                        //読み出し
                        while (reader.Read())
                        {
                            displaylist.Add(new LogData(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetValue(5), reader.GetString(6), reader.GetValue(7)));
                        }
                        LogGridView.DataSource = displaylist;
                    }
                }
            }
        }
    }

    class LogData
    {
        //日付
        public string Vsdate { get; set; }

        //自デッキ・大分類
        public string Mydeck_mahjorclass { get; set; }

        //自デッキ・小分類
        public string Mydeck_smallclass { get; set; }

        //相手デッキ・大分類
        public string Enemydeck_mahjorclass { get; set; }

        //相手デッキ・小分類
        public string Enemydeck_smallclass { get; set; }

        //1 = 勝ち、0 = 負け
        public int Win { get; set; }

        //フォーマット
        public string Format { get; set; }

        //1 = 先行、0 = 後攻
        public int Pracedence { get; set; }

        public LogData(string vsdate, string mydeck_mahjorclass, string mydeck_smallclass, string enemydeck_mahjorclass, string enemydeck_smallclass, object win, string format, object pracedence)
        {
            this.Vsdate = vsdate;
            this.Mydeck_mahjorclass = mydeck_mahjorclass;
            this.Mydeck_smallclass = mydeck_smallclass;
            this.Enemydeck_mahjorclass = enemydeck_mahjorclass;
            this.Enemydeck_smallclass = enemydeck_smallclass;
            this.Win = (int)(long)win;
            this.Format = format;
            this.Pracedence = (int)(long)pracedence;
        }
    }
}
