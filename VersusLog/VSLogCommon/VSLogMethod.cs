using System.Collections.Generic;
using System.Data;

namespace VersusLog
{
    /// <summary>
    /// 戦績ログ機能専用メソッドクラス
    /// </summary>
    class VSLogMethod
    {
        CommonData cd = new CommonData();

        /// <summary>
        /// 戦績ログ(絞込無し)取得
        /// </summary>
        /// <returns>戦績ログList(絞込無し)</returns>
        public List<LogData> getVSLog()
        {
            string SQLtext = "select VSLOG.ID, VSLOG.VSDATE, MYDECK.MAJORCLASS, MYDECK.SMALLCLASS, ENEMYDECK.MAJORCLASS, ENEMYDECK.SMALLCLASS, VSLOG.WIN, FORMAT.FORMATNAME, VSLOG.PRACEDENCE " +
                "from VSLOG " +
                "left outer join DECK as MYDECK on VSLOG.MYDECKID = MYDECK.ID " +
                "left outer join DECK as ENEMYDECK on VSLOG.ENEMYDECKID = ENEMYDECK.ID " +
                "left outer join FORMAT on VSLOG.FORMATID = FORMAT.ID";
            DataTable dt = cd.getDataTable(SQLtext);
            //変換
            var displaylist = new List<LogData>();
            foreach (DataRow row in dt.Rows)
            {
                displaylist.Add(new LogData(
                    row[0], //ID
                    row[1].ToString(), //日付
                    (row[2] == null) ? null : row[2].ToString(), //自デッキ・大分類
                    (row[3] == null) ? null : row[3].ToString(), //自デッキ・小分類
                    (row[4] == null) ? null : row[4].ToString(), //相手デッキ・大分類
                    (row[5] == null) ? null : row[5].ToString(), //相手デッキ・小分類
                    row[6], //結果
                    (row[7] == null) ? null : row[7].ToString(), //フォーマット
                    row[8] //先攻後攻
                ));
            }

            return displaylist;
        }
    }
}
