using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace VersusLog
{
    /// <summary>
    /// 共通データ・メソッドクラス
    /// </summary>
    public class CommonData
    {
        /// <summary>
        /// DB接続先情報
        /// </summary>
        public const string ConnectionString = @"Data Source=vslog.db";

        /// <summary>
        /// デッキ小分類取得処理
        /// </summary>
        /// <param name="MajorclassComboBox">デッキ大分類コンボボックス</param>
        /// <param name="SmallclassComboBox">デッキ小分類コンボボックス</param>
        public void GetDeckSmallclass(ComboBox MajorclassComboBox, ComboBox SmallclassComboBox)
        {

            //デッキ名取得用クエリ作成
            string SQLtext = "select SMALLCLASS from DECK " +
                        "where MAJORCLASS = " + surroundApos(MajorclassComboBox.SelectedValue);
            DataTable dt = getDataTable(SQLtext);
            SmallclassComboBox.DataSource = dt;
            SmallclassComboBox.DisplayMember = "SMALLCLASS";
            SmallclassComboBox.ValueMember = "SMALLCLASS";
        }

        /// <summary>
        /// SQL 期間指定文生成
        /// </summary>
        /// <param name="word">変更種別</param>
        /// <returns>SQL where文</returns>
        public string createPeriodQuery(string word)
        {
            string str = "";
            string worktext;

            //今日の日付取得
            DateTime dtNow = DateTime.Now;
            DateTime dtToday = dtNow.Date;
            string today = dtToday.ToShortDateString();

            //変更種別に応じてwhere文を生成
            switch (word)
            {
                case "指定なし":
                    str = " ";
                    break;
                case "この1週間":
                    string workdate = today.ToString();
                    DateTime datatime = DateTime.Parse(workdate);
                    DateTime dtcal = datatime.AddDays(-7);
                    workdate = dtcal.ToShortDateString();
                    str = " where VSDATE between " + surroundApos(workdate) + " and " + surroundApos(today);
                    break;
                case "今月":
                    worktext = today.Substring(0, 7);
                    str = " where VSDATE like " + surroundApos(worktext + "%");
                    break;
                default:
                    str = " ";
                    break;
            }
            return str;
        }

        /// <summary>
        /// DataTable生成処理
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>SQL問い合わせ結果</returns>
        public DataTable getDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    MessageBox.Show("DBへの問い合わせ時にエラーが発生しました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    writeErrorLog(ex);
                }
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// DB書き込み処理
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>実行件数(0なら失敗)</returns>
        public int executeSQL(string sql)
        {
            int ret = 0;

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        ret = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    MessageBox.Show("DBへの問い合わせ時にエラーが発生しました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    writeErrorLog(ex);
                }
                con.Close();
            }
            return ret;
        }
        /// <param name="SQLList">実行SQLリスト</param>
        /// <returns>実行件数(0なら失敗)</returns>
        public int executeSQL(List<string> SQLList)
        {
            int ret = 0;

            using (var con = new SQLiteConnection(CommonData.ConnectionString))
            {
                try
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = con.BeginTransaction();
                            foreach (string SQLText in SQLList)
                            {
                                cmd.CommandText = SQLText;
                                cmd.ExecuteNonQuery();
                                ret += 1;
                            }

                            //全件実行出来たらコミット
                            cmd.Transaction.Commit();
                        }
                        catch (System.Data.SQLite.SQLiteException ex)
                        {
                            //途中で失敗したらロールバック
                            cmd.Transaction.Rollback();
                            MessageBox.Show("DBへの問い合わせ時にエラーが発生しました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            writeErrorLog(ex);
                            ret = 0;
                        }
                    }
                    con.Close();
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    MessageBox.Show("DBへの接続時にエラーが発生しました。", "結果", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    writeErrorLog(ex);
                    ret = 0;
                }
            }

            return ret;
        }

        /// <summary>
        /// エラーログ書き出し
        /// </summary>
        /// <param name="ex"></param>
        public void writeErrorLog(Exception ex)
        {
            StreamWriter stream = new StreamWriter("error.txt", true);
            stream.WriteLine("[date]\n" + System.DateTime.Now);
            stream.WriteLine("[message]\n" + ex.Message);
            stream.WriteLine("[source]\n" + ex.Source);
            stream.WriteLine();
            stream.Close();
        }

        /// <summary>
        /// 文字列を'(apostrophe)で囲う
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>'で囲った文字列</returns>
        public string surroundApos(string str)
        {
            return "'" + str + "'";
        }
        public string surroundApos(object str)
        {
            return "'" + ((str == null) ? "" : str.ToString()) + "'";
        }
    }
}
