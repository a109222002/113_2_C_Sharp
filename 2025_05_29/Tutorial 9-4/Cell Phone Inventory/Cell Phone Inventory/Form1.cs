using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        // 並將使用者於表單輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得使用者輸入的品牌名稱並指派給 CellPhone 物件
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的型號並指派給 CellPhone 物件
            phone.Model = modelTextBox.Text;

            // 嘗試將使用者輸入的價格轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提醒使用者價格格式錯誤
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件

            GetPhoneData(myPhone); // 呼叫 GetPhoneData 方法，將使用者輸入的資料指派給 myPhone 物件

            phoneList.Add(myPhone); // 將 myPhone 物件加入到 phoneList 清單中

            // 將新手機的品牌和型號組合成字串，並加入到 phoneListBox 中
            phoneListBox.Items.Add(myPhone.Brand+" "+ myPhone.Model);

            // 清空輸入欄位
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();
            // 將焦點設回品牌輸入欄位
            brandTextBox.Focus();


        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 當使用者選擇手機清單中的項目時，取得所選項目的索引
            int index = phoneListBox.SelectedIndex;
            
            MessageBox.Show(phoneList[index].Price.ToString("C"));// 顯示所選手機的價格，格式化為貨幣形式
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式
            this.Close();
        }
    }
}
