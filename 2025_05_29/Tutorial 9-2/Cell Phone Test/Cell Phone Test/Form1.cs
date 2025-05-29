using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法接收一個 CellPhone 物件作為參數，
        // 並將使用者於表單輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;

            phone.Brand = brandTextBox.Text; // 從品牌輸入框取得品牌名稱
            phone.Model = modelTextBox.Text; // 從型號輸入框取得型號名稱
            // 嘗試將價格輸入框的文字轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price; // 如果轉換成功，設定手機價格
            }
            else
            {
                // 如果轉換失敗，顯示錯誤訊息並清空價格輸入框
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }

        // 當使用者按下「建立物件」按鈕時所觸發的事件處理方法。
        // 此方法負責建立 CellPhone 物件並顯示相關資料。
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            // 建立一個 CellPhone 物件，並將指派給myPhone變數。
            CellPhone myPhone = new CellPhone();
            // 呼叫 GetPhoneData 方法，將表單輸入的資料指派給 myPhone 物件。
            GetPhoneData(myPhone);

            // 將myPhone 物件的資料顯示在表單的標籤上。
            brandLabel.Text = myPhone.Brand;
            modelLabel.Text = myPhone.Model;
            priceLabel.Text = myPhone.Price.ToString("C2"); // 使用 "C" 格式化為貨幣格式
        }

        // 當使用者按下「離開」按鈕時所觸發的事件處理方法。
        // 此方法會關閉目前的表單，結束程式執行。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式。
            this.Close();
        }
    }
}
