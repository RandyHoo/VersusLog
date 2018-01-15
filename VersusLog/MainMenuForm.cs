using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VersusLog
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MCVSLogButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new VSLogForm();
            ViewForm.Show();
            this.Hide();
        }

        private void MCDeckMasterChangeButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new DeckMasterChangeForm();
            ViewForm.Show();
            this.Hide();
        }

        private void MCFormatMasterChangeButton_Click(object sender, EventArgs e)
        {
            //表示フォーム切り替え
            Form ViewForm = new FormatMasterChangeForm();
            ViewForm.Show();
            this.Hide();
        }
    }
}
