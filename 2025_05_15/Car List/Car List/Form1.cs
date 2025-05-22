using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // 建立一個汽車清單作為欄位，用來儲存所有汽車資料
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetData 方法會取得使用者在三個文字方塊中輸入的資料，
        // 並將這些資料指派給傳入參數 auto 的各個欄位。
        // 若輸入格式錯誤，會顯示錯誤訊息。
        private void GetData(ref Automobile auto)
        {
            try
            {
                // 從文字方塊取得廠牌、年份與里程數，並轉換成對應型別
                auto.make = makeTextBox.Text;
                auto.year = int.Parse(yearTextBox.Text);
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("輸入資料格式錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當使用者按下「新增汽車」按鈕時觸發此事件
        // 1. 建立一個新的 Automobile 結構實例
        // 2. 取得使用者輸入的資料並指派給該實例
        // 3. 將該汽車資料加入清單
        // 4. 清空所有文字方塊
        // 5. 將游標焦點移回廠牌輸入框
        private void addButton_Click(object sender, EventArgs e)
        {
            //建立一個新的汽車結構實例
            Automobile car = new Automobile();
            //取得使用者輸入的資料
            GetData(ref car);

            carList.Add(car);

            makeTextBox.Clear();
            yearTextBox.Clear();
            mileageTextBox.Clear();

            makeTextBox.Focus();
        }

        // 當使用者按下「顯示清單」按鈕時觸發此事件
        // 1. 先清空 ListBox 內容
        // 2. 逐一將清單中的每一台汽車資料格式化為字串，並加入 ListBox 顯示
        private void displayButton_Click(object sender, EventArgs e)
        {
            string output;
            // 清空 ListBox 內容
            carListBox.Items.Clear();
            // 逐一將清單中的每一台汽車資料格式化為字串
            foreach (Automobile aCar in carList)
            {
                // 將汽車資料格式化為「年份 廠牌，里程數：xxx 公里」的字串
                output = aCar.year + " 年 " + aCar.make +
                    "，里程數：" + aCar.mileage + " 公里";
                // 將格式化後的字串加入 ListBox 顯示
                carListBox.Items.Add(output);
            }
        }
    }
}
