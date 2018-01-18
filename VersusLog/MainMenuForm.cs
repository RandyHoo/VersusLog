using System;
using System.Windows.Forms;

namespace VersusLog
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 戦績ログ遷移処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCVSLogButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new VSLogForm();
            ViewForm.Show();
            Hide();
        }

        /// <summary>
        /// デッキマスタ変更遷移処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCDeckMasterChangeButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new DeckMasterChangeForm();
            ViewForm.Show();
            Hide();
        }

        /// <summary>
        /// フォーマットマスタ変更遷移処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCFormatMasterChangeButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new FormatMasterChangeForm();
            ViewForm.Show();
            Hide();
        }

        /// <summary>
        /// SQL実行遷移処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCSQLButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new SQLForm();
            ViewForm.Show();
            Hide();
        }
    }
}
