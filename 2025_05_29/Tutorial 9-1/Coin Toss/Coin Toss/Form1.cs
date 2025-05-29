using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的 Coin 物件，用來模擬擲硬幣的動作
            Coin myCoin = new Coin(); // 建立 Coin 物件
            outputListBox.Items.Clear(); // 清空 ListBox 的內容

            // 擲硬幣五次，並將結果顯示在 ListBox 中
            for (int i = 0; i < 5; i++)
            {
                myCoin.Toss(); // 擲硬幣
                string sideUp = myCoin.GetSideUp(); // 獲取硬幣正面
                outputListBox.Items.Add(sideUp); // 將結果添加到 ListBox 中
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的視窗，結束應用程式
            this.Close();
        }
    }
}
