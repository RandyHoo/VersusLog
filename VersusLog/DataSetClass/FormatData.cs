namespace VersusLog
{
    /// <summary>
    /// フォーマットデータクラス
    /// </summary>
    class FormatData
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// フォーマット名
        /// </summary>
        public string Formatname { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="formatname">フォーマット名</param>
        public FormatData(object id, string formatname)
        {
            this.Id = System.Convert.ToInt32(id);
            this.Formatname = formatname;
        }
    }
}
