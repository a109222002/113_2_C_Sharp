using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Display_Elements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getNamesButton_Click(object sender, EventArgs e)
        {
            // 建立一個陣列來存放三個字串
            // 這裡定義了一個常數SIZE，陣列的大小為3
            const int SIZE = 3;
            string[] names = new string[SIZE];

            // 獲取名字
            names[0] = name1TextBox.Text;
            names[1] = name2TextBox.Text;
            names[2] = name3TextBox.Text;

            // 顯示名字
            MessageBox.Show(names[0]);
            MessageBox.Show(names[1]);
            MessageBox.Show(names[2]);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}