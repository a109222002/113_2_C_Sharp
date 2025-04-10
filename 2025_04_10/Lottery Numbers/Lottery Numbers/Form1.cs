using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;//陣列的大小
            int[] lotteryNumbers = new int[SIZE];//儲存樂透號碼陣列
            Random rand = new Random();

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                //產生1~42的亂數，並檢查產生的亂數沒有與陣列中元素重複，再放入陣列中
                int number;
                do
                {
                    number = rand.Next(1, 43);//產生1~42的亂數
                } while (lotteryNumbers.Contains(number));//檢查是否已經存在於陣列中
                lotteryNumbers[i] = number;//將不重複的亂數放入陣列中
            }

            //firstLabel.Text = lotteryNumbers[0].ToString();
            //secondLabel.Text = lotteryNumbers[1].ToString();
            //thirdLabel.Text = lotteryNumbers[2].ToString();
            //fourthLabel.Text = lotteryNumbers[3].ToString();
            //fifthLabel.Text = lotteryNumbers[4].ToString();

            //使用迴圈來顯示樂透號碼
            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
