using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersusLog
{
    /// <summary>
    /// 戦績ログクラス
    /// </summary>
    public class LogData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        public string Vsdate { get; set; }

        /// <summary>
        /// 自デッキ・大分類
        /// </summary>
        public string Mydeck_majorclass { get; set; }

        /// <summary>
        /// 自デッキ・小分類
        /// </summary>
        public string Mydeck_smallclass { get; set; }

        /// <summary>
        /// 相手デッキ・大分類
        /// </summary>
        public string Enemydeck_majorclass { get; set; }

        /// <summary>
        /// 相手デッキ・小分類
        /// </summary>
        public string Enemydeck_smallclass { get; set; }

        /// <summary>
        /// 結果
        /// </summary>
        /// <remarks>
        /// "勝ち" or "負け"
        /// </remarks>
        public string Win { get; set; }

        /// <summary>
        /// フォーマット
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 先攻後攻
        /// </summary>
        /// <remarks>
        /// "先攻" or "後攻"
        /// </remarks>
        public string Pracedence { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="vsdate">日付</param>
        /// <param name="mydeck_majorclass">自デッキ・大分類</param>
        /// <param name="mydeck_smallclass">自デッキ・小分類</param>
        /// <param name="enemydeck_majorclass">相手デッキ・大分類</param>
        /// <param name="enemydeck_smallclass">相手デッキ・小分類</param>
        /// <param name="win">結果</param>
        /// <param name="format">フォーマット</param>
        /// <param name="pracedence">先攻後攻</param>
        public LogData(object id, string vsdate, string mydeck_majorclass, string mydeck_smallclass, string enemydeck_majorclass, string enemydeck_smallclass, object win, string format, object pracedence)
        {
            this.ID = System.Convert.ToInt32(id);
            this.Vsdate = vsdate;
            this.Mydeck_majorclass = mydeck_majorclass;
            this.Mydeck_smallclass = mydeck_smallclass;
            this.Enemydeck_majorclass = enemydeck_majorclass;
            this.Enemydeck_smallclass = enemydeck_smallclass;
            //int(1(true) or 0(false))を変換
            this.Win = (System.Convert.ToInt32(win) == 1) ? "勝ち" : "負け";
            this.Format = format;
            //int(1(true) or 0(false))を変換
            this.Pracedence = (System.Convert.ToInt32(pracedence) == 1) ? "先攻" : "後攻";
        }
    }
}
