using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace VersusLog
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form ViewForm = new MainMenuForm();
            Application.Run(ViewForm);
        }
    }

    public class CommonData
    {
        public const string ConnectionString = @"Data Source=vslog.db";

        public static void GetDeckSmallclass(ComboBox MajorclassComboBox, ComboBox SmallclassComboBox)
        {
            var DeckSmallclassDatasource = new List<string>();

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //デッキ名取得用クエリ作成
                    cmd.CommandText = "select SMALLCLASS from DECK " +
                        "where MAJORCLASS = '" + MajorclassComboBox.Text + "'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DeckSmallclassDatasource.Add(reader.GetString(0));
                        }
                        SmallclassComboBox.DataSource = DeckSmallclassDatasource;
                    }
                }

                con.Close();
            }
        }
    }
}
