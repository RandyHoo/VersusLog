using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace VersusLog
{
    /// <summary>
    /// 汎用データ・メソッドクラス
    /// </summary>
    public class CommonData
    {
        /// <summary>
        /// DB接続先情報
        /// </summary>
        public const string ConnectionString = @"Data Source=vslog.db";

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

        /// <summary>
        /// 今日の日付(yyyy/mm/dd)取得
        /// </summary>
        /// <returns>今日の日付(yyyy/mm/dd)</returns>
        public string getToday()
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtToday = dtNow.Date;
            return dtToday.ToShortDateString();
        }

        /// <summary>
        /// DataGridView ヘッダ設定
        /// </summary>
        /// <param name="headerList">ヘッダに設定する文字列のリスト</param>
        /// <param name="view">設定するDataGridView</param>
        public void setDataGridViewHeader(List<string> headerList, DataGridView view)
        {
            for (int i = 0; i < view.Columns.Count; i++)
            {
                view.Columns[i].HeaderText = headerList[i];
            }
        }
    }
}
