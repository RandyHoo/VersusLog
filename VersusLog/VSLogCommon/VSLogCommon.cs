using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace VersusLog
{
    /// <summary>
    /// 共通メソッドクラス
    /// </summary>
    class VSLogCommon
    {
        CommonData cd = new CommonData();

        /// <summary>
        /// デッキ 大分類のリスト取得
        /// </summary>
        /// <returns>デッキ 大分類のリスト</returns>
        public List<string> getDeckMajorClassList()
        {
            string SQLtext = "select distinct MAJORCLASS from DECK";
            DataTable dt = cd.getDataTable(SQLtext);
            var DeckMajorclassDatasource = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                DeckMajorclassDatasource.Add(row[0].ToString());
            }

            return DeckMajorclassDatasource;
        }

        /// <summary>
        /// フォーマットのリスト取得
        /// </summary>
        /// <returns>フォーマットのリスト</returns>
        public List<string> getFormatList()
        {
            string SQLtext = "select FORMATNAME from FORMAT";
            DataTable dt = cd.getDataTable(SQLtext);
            var FormatDatasource = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                FormatDatasource.Add(row[0].ToString());
            }

            return FormatDatasource;
        }

        /// <summary>
        /// デッキID取得
        /// </summary>
        /// <param name="DeckMajorClass">デッキ 大分類</param>
        /// <param name="DeckSmallClass">デッキ 小分類</param>
        /// <returns>該当するデッキID</returns>
        public int getDeckID(string DeckMajorClass, string DeckSmallClass)
        {
            string SQLtext = "select ID from DECK " +
                            "where MAJORCLASS = " + cd.surroundApos(DeckMajorClass) +
                            "and SMALLCLASS = " + cd.surroundApos(DeckSmallClass);
            DataTable dt = cd.getDataTable(SQLtext);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        /// <summary>
        /// フォーマットID取得
        /// </summary>
        /// <param name="FormatName">フォーマット名</param>
        /// <returns>該当するフォーマットID</returns>
        public int getFormatID(string FormatName)
        {
            string SQLtext = "select ID from FORMAT " +
                            "where FORMATNAME = " + cd.surroundApos(FormatName);
            DataTable dt = cd.getDataTable(SQLtext);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        /// <summary>
        /// 新データ用ID取得
        /// </summary>
        /// <param name="TableName">追加するテーブル名</param>
        /// <returns>新データ用ID</returns>
        public int getNewID(string TableName)
        {
            string SQLtext = "select ID from " + TableName;
            DataTable dt = cd.getDataTable(SQLtext);
            return  (dt.Rows.Count == 0) ? 0 : Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
        }

        /// <summary>
        /// デッキ小分類取得処理
        /// </summary>
        /// <param name="MajorclassComboBox">デッキ大分類コンボボックス</param>
        /// <param name="SmallclassComboBox">デッキ小分類コンボボックス</param>
        public void GetDeckSmallclass(ComboBox MajorclassComboBox, ComboBox SmallclassComboBox)
        {

            //デッキ名取得用クエリ作成
            string SQLtext = "select SMALLCLASS from DECK " +
                        "where MAJORCLASS = " + cd.surroundApos(MajorclassComboBox.SelectedValue);
            DataTable dt = cd.getDataTable(SQLtext);
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
            string today = cd.getToday();

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
                    str = " where VSDATE between " + cd.surroundApos(workdate) + " and " + cd.surroundApos(today);
                    break;
                case "今月":
                    worktext = today.Substring(0, 7);
                    str = " where VSDATE like " + cd.surroundApos(worktext + "%");
                    break;
                default:
                    str = " ";
                    break;
            }
            return str;
        }
    }
}
