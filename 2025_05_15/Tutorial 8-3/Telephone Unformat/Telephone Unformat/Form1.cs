using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，
        // 並判斷其是否正確地以美國電話號碼格式輸入：
        // (XXX)XXX-XXXX
        // 如果參數格式正確，方法回傳 true，否則回傳 false。
        private bool IsValidFormat(string str)
        {

        }

        // unformat 方法接受一個傳址的字串參數，
        // 假設其內容為格式化的電話號碼：(XXX)XXX-XXXX。
        // 此方法會將字串中的括號與連字號移除，達到去格式化的效果。
        private void Unformat(ref string str)
        {

        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;

            if (IsValidFormat(input))
            { 
                Unformat(ref input); //去除格式
                MessageBox.Show("去除格式後的電話號碼為：" + input, "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確的電話號碼格式：(XXX)XXX-XXXX", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberTextBox.Focus(); // 將焦點設回輸入框
                numberTextBox.SelectAll(); // 選取輸入框中的所有文字
                numberTextBox.Clear(); // 清除輸入框中的文字
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}

