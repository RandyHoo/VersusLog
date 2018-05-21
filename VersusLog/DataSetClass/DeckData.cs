namespace VersusLog
{
    /// <summary>
    /// デッキデータクラス
    /// </summary>
    class DeckData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// デッキ大分類
        /// </summary>
        public string Majorclass { get; set; }

        /// <summary>
        /// デッキ小分類
        /// </summary>
        public string Smallclass { get; set; }

        /// <summary>
        /// デッキタイプ1
        /// </summary>
        public string Decktype1 { get; set; }

        /// <summary>
        /// デッキタイプ2
        /// </summary>
        public string DeckType2 { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="majorclass">デッキ大分類</param>
        /// <param name="smallclass">デッキ小分類</param>
        /// <param name="decktype1">デッキタイプ1</param>
        /// <param name="decktype2">デッキタイプ2</param>
        public DeckData(object id, string majorclass, string smallclass, string decktype1, string decktype2)
        {
            this.Id = System.Convert.ToInt32(id);
            this.Majorclass = majorclass;
            this.Smallclass = smallclass;
            this.Decktype1 = decktype1;
            this.DeckType2 = decktype2;
        }
    }
}
