using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // 初始化表單元件
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // 定義座位的行數與列數
            const int ROWS = 6; // 總共有6列
            const int COLS = 4; // 總共有4行

            int row; // 儲存使用者輸入的列號
            int col; // 儲存使用者輸入的行號

            // 定義座位價格的二維陣列
            decimal[,] seatPrices = {
                    {450m, 450m, 450m, 450m}, // 第0列的價格
                    {425m, 425m, 425m, 425m}, // 第1列的價格
                    {400m, 400m, 400m, 400m}, // 第2列的價格
                    {375m, 375m, 375m, 375m}, // 第3列的價格
                    {375m, 375m, 375m, 375m}, // 第4列的價格
                    {350m, 350m, 350m, 350m}  // 第5列的價格
                };

            // 嘗試將列號的文字輸入轉換為整數
            if (int.TryParse(rowTextBox.Text, out row))
            {
                // 嘗試將行號的文字輸入轉換為整數
                if (int.TryParse(colTextBox.Text, out col))
                {
                    // 檢查列號是否在有效範圍內
                    if (row >= 0 && row < seatPrices.GetLength(0))
                    {
                        // 檢查行號是否在有效範圍內
                        if (col >= 0 && col < seatPrices.GetLength(1))
                        {
                            // 顯示對應座位的價格，格式化為貨幣格式
                            priceLabel.Text = seatPrices[row, col].ToString("C");
                        }
                        else
                        {
                            // 行號超出範圍，顯示錯誤訊息
                            MessageBox.Show("行編號0~3！");
                            colTextBox.Focus(); // 將焦點移回行號輸入框
                            return;
                        }
                    }
                    else
                    {
                        // 列號超出範圍，顯示錯誤訊息
                        MessageBox.Show("列編號0~5！");
                        rowTextBox.Focus(); // 將焦點移回列號輸入框
                        return;
                    }
                }
                else
                {
                    // 行號輸入無效，顯示錯誤訊息
                    MessageBox.Show("請輸入有效的行號");
                    colTextBox.Focus(); // 將焦點移回行號輸入框
                    return;
                }
            }
            else
            {
                // 列號輸入無效，顯示錯誤訊息
                MessageBox.Show("請輸入有效的列號");
                rowTextBox.Focus(); // 將焦點移回列號輸入框
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }

        private void rowPromptLabel_Click(object sender, EventArgs e)
        {
            // 此方法目前未實作
        }
    }
}
