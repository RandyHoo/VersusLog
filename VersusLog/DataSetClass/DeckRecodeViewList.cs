namespace VersusLog
{
    /// <summary>
    /// デッキ戦績表示用クラス
    /// </summary>
    class DeckRecodeViewList
    {
        /// <summary>
        /// デッキ名
        /// </summary>
        public string Deckname { get; set; }

        /// <summary>
        /// 対戦戦績(%)
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="deckname">デッキ名</param>
        /// <param name="total">戦績(%)</param>
        public DeckRecodeViewList(string deckname, int total)
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
