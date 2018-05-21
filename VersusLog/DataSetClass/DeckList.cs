namespace VersusLog
{
    /// <summary>
    /// 戦績ログクラス
    /// </summary>
    class DeckList
    {
        /// <summary>
        /// デッキID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// デッキ・大分類
        /// </summary>
        public string Deck_majorclass { get; set; }

        /// <summary>
        /// デッキ・小分類
        /// </summary>
        public string Deck_smallclass { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">デッキID</param>
        /// <param name="deck_majorclass">デッキ・大分類</param>
        /// <param name="deck_smallclass">デッキ・小分類</param>
        public DeckList(object id, string deck_majorclass, string deck_smallclass)
        {
            this.ID = System.Convert.ToInt32(id);
            this.Deck_majorclass = deck_majorclass;
            this.Deck_smallclass = deck_smallclass;
        }
    }
}
