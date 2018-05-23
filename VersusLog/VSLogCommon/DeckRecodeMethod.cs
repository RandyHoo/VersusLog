using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace VersusLog
{
    class DeckRecodeMethod
    {
        CommonData cd = new CommonData();

        /// <summary>
        /// デッキ一覧取得
        /// </summary>
        /// <remarks>デッキ大分類は昇順</remarks>
        /// <returns>デッキ一覧List</returns>
        public List<DeckList> GetDeckList()
        {
            string SQLtext = "select ID, MAJORCLASS, SMALLCLASS from DECK order by MAJORCLASS";
            DataTable dt = cd.getDataTable(SQLtext);

            var decklist = new List<DeckList>(); //デッキリスト
            foreach (DataRow row in dt.Rows)
            {
                decklist.Add(new DeckList(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString()));
            }

            return decklist;
        }

        /// <summary>
        /// デッキ戦績取得
        /// </summary>
        /// <param name="DeckID"></param>
        /// <param name="decklist"></param>
        /// <returns></returns>
        public List<DeckRecodeViewList> getDeckRecode(int DeckID, List<DeckList> decklist, int FormatID)
        {
            var viewlist = new List<DeckRecodeViewList>(); //表示用リスト
            
            //先頭に全体に対しての戦績を記入
            float total = getOverrallWinPercent(DeckID, FormatID);
            viewlist.Add(new DeckRecodeViewList("全体", (int)total));

            string deckname;
            foreach (var n in decklist)
            {
                deckname = n.Deck_majorclass + " " + n.Deck_smallclass;
                total = getWinPercent(DeckID, n.ID, FormatID);
                viewlist.Add(new DeckRecodeViewList(deckname, (int)total));
            }

            return viewlist;
        }

        /// <summary>
        /// 全体に対しての勝率計算
        /// </summary>
        /// <param name="DeckID">自デッキID</param>
        /// <returns>勝率(%)</returns>
        private float getOverrallWinPercent(int DeckID, int FormatID)
        {
            string SQLtext = "select count(*) from VSLOG " +
                    "where " +
                    "MYDECKID = " + DeckID + " " +
                    "and FORMATID = " + FormatID ;
            DataTable dt = cd.getDataTable(SQLtext);
            int tortal_col = System.Convert.ToInt32(dt.Rows[0][0]);

            SQLtext = "select count(*) from VSLOG " +
                        "where " +
                        "MYDECKID = " + DeckID + " " +
                        "and WIN = 1 " +
                        "and FORMATID = " + FormatID;
            dt = cd.getDataTable(SQLtext);
            float win = System.Convert.ToInt32(dt.Rows[0][0]);
            
            //対戦したことがないなら「-」を入力する
            return (tortal_col > 0) ? (win / tortal_col) * 100 : 999;
        }

        /// <summary>
        /// 特定のデッキに対しての勝率計算
        /// </summary>
        /// <param name="MyDeckID">自デッキID</param>
        /// <param name="EnemyDeckID">相手デッキID</param>
        /// <returns>勝率(%)</returns>
        private float getWinPercent(int MyDeckID, int EnemyDeckID, int FormatID)
        {
            string SQLtext = "select count(*) from VSLOG " +
                    "where " +
                    "MYDECKID = " + MyDeckID + " " +
                    "and ENEMYDECKID = " + EnemyDeckID + " " + 
                    "and FORMATID = " + FormatID;
            DataTable dt = cd.getDataTable(SQLtext);
            int tortal_col = System.Convert.ToInt32(dt.Rows[0][0]);

            SQLtext = "select count(*) from VSLOG " +
                "where " +
                "MYDECKID = " + MyDeckID + " " +
                "and ENEMYDECKID = " + EnemyDeckID + " " +
                "and WIN = 1 " +
                "and FORMATID = " + FormatID;
            dt = cd.getDataTable(SQLtext);
            float win = System.Convert.ToInt32(dt.Rows[0][0]);

            //対戦したことがないなら「-」を入力する
            return (tortal_col > 0) ? (win / tortal_col) * 100 : 999;
        }
    }
}
