using System;
using System.Collections.Generic;
using System.Data;

namespace VersusLog
{
    class MetaAnalyzeMethod
    {
        CommonData cd = new CommonData();
        VSLogCommon VSLogCommon = new VSLogCommon();

        /// <summary>
        /// 最多デッキ分析
        /// </summary>
        /// <param name="PeriodStr">期間</param>
        /// <returns>最多デッキ名</returns>
        public string MoreDeckAnalyze(string PeriodStr)
        {
            //変更種別に応じてクエリの条件を生成
            string wheretext = VSLogCommon.createPeriodQuery(PeriodStr);

            //最頻相手デッキID取得
            string SQLtext = "select ENEMYDECKID from VSLOG " + wheretext +
                "group by ENEMYDECKID having count(*) >= (select max(cnt) from ( select count(*) as cnt from VSLOG" + wheretext +
                                                                                "group by ENEMYDECKID))";
            DataTable dt = cd.getDataTable(SQLtext);

            //戦績ログがなければ終了
            if (dt.Rows.Count == 0) return "default";

            int moredeckid = System.Convert.ToInt32(dt.Rows[0][0]);

            //最頻相手デッキ名取得
            SQLtext = "select MAJORCLASS, SMALLCLASS from DECK " + "where ID = " + moredeckid;
            dt = cd.getDataTable(SQLtext);

            return (dt.Rows[0][0] + " " + dt.Rows[0][1]);
        }

        /// <summary>
        /// 環境メタデッキ分析処理
        /// </summary>
        /// <param name="PeriodStr">期間</param>
        /// <returns>トップ5の環境メタデッキ</returns>
        public string MetaDeckAnalyze(string PeriodStr)
        {
            //対戦率トップ5のデッキIDを取得する
            List<int> moredeckidList = getBattleRateTop5DeckID(PeriodStr);
            //戦績ログがなければ終了
            if (moredeckidList.Count == 0) return "default";

            //デッキ一覧を取得
            DataTable DeckList = getDecklist();

            //スコア領域を追加
            DeckList = addScoreArea(DeckList);

            //スコアを加算
            DeckList = ScoreAddition(DeckList, moredeckidList);

            //トップ5の環境メタデッキを返す
            return createMetaDeckStr(DeckList);
        }

        /// <summary>
        /// 対戦率トップ5のデッキIDを取得する
        /// </summary>
        /// <returns>デッキのIDリスト</returns>
        private List<int> getBattleRateTop5DeckID(string PeriodStr)
        {
            var moredeckidList = new List<int>();

            //対戦回数が多い順に相手デッキIDを取得
            string SQLtext = "select ENEMYDECKID, count(*) AS CNT FROM VSLOG " + VSLogCommon.createPeriodQuery(PeriodStr) +
                "group by ENEMYDECKID order by CNT desc";
            DataTable dt = new DataTable();
            dt = cd.getDataTable(SQLtext);

            //戦績ログがなければ終了
            if (dt.Rows.Count == 0) return moredeckidList;

            foreach (DataRow row in dt.Rows)
            {
                moredeckidList.Add(System.Convert.ToInt32(row[0]));
            }

            return moredeckidList;
        }

        /// <summary>
        /// デッキ一覧を取得
        /// </summary>
        /// <returns>デッキ一覧</returns>
        private DataTable getDecklist()
        {
            string SQLtext = "select ID, MAJORCLASS, SMALLCLASS from DECK";
            return cd.getDataTable(SQLtext);
        }

        /// <summary>
        /// スコア領域を追加する
        /// </summary>
        /// <param name="DeckList">デッキ一覧</param>
        /// <returns>スコア領域を追加したDataTable</returns>
        private DataTable addScoreArea(DataTable DeckList)
        {
            DataTable dt = DeckList;

            dt.Columns.Add("score", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["score"] = 0;
            }

            return dt;
        }

        /// <summary>
        /// スコア加算
        /// </summary>
        /// <param name="DeckList">デッキリスト</param>
        /// <param name="moredeckidList">対戦率トップ5のデッキIDリスト</param>
        /// <returns>スコア処理をしたデッキリスト</returns>
        private DataTable ScoreAddition(DataTable DeckList, List<int> moredeckidList)
        {
            DataTable dt = DeckList;

            foreach (int deckid in moredeckidList)
            {
                //相手デッキを指定してレコード取得
                string SQLtext = "select MYDECK_ID, SCORE from MATCHUP where ENEMYDECK_ID = " + deckid.ToString();
                DataTable workdt = cd.getDataTable(SQLtext);

                int work;
                foreach (DataRow row in workdt.Rows)
                {
                    //デッキリストを舐める
                    for (int i = 0; i < DeckList.Rows.Count; i++)
                    {
                        //自デッキIDが一致したら
                        if (Convert.ToInt32(DeckList.Rows[i]["ID"]) == Convert.ToInt32(row["MYDECK_ID"]))
                        {
                            //一旦保持して加算、その後格納
                            work = Convert.ToInt32(DeckList.Rows[i]["SCORE"]);
                            work += Convert.ToInt32(row["SCORE"]);
                            DeckList.Rows[i]["SCORE"] = work;
                            break;
                        }
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// トップ5の環境メタデッキを出す
        /// </summary>
        /// <param name="DeckList">デッキ一覧</param>
        /// <returns>トップ5の環境メタデッキ</returns>
        private string createMetaDeckStr(DataTable DeckList)
        {
            DataTable dt = DeckList;

            //リストをスコア順に並び替え
            DataView dv = new DataView(dt);
            dv.Sort = "SCORE DESC";
            dt = dv.ToTable();

            //上位5つを文字列として結合
            string str = "";
            int displayMax = (dt.Rows.Count < 5) ? dt.Rows.Count : 5;
            for (int i = 0; i < displayMax; i++)
            {
                str += Convert.ToString(i + 1) + "." + dt.Rows[i]["MAJORCLASS"] + " " + dt.Rows[i]["SMALLCLASS"] + "\n";
            }

            return str;
        }
    }
}
