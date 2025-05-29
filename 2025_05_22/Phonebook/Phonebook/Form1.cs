using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    // 結構：用來儲存電話簿的單一聯絡人資料，包括姓名與電話號碼
    struct PhoneBookEntry
    {
        public string name;   // 聯絡人姓名
        public string phone;  // 聯絡人電話號碼
    }

    public partial class Form1 : Form
    {
        // 欄位：用來儲存所有電話簿聯絡人資料的清單
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadFile 方法：讀取 PhoneList.txt 檔案內容，
        // 並將每一筆資料轉換為 PhoneBookEntry 結構，存入 phoneList 清單中。
        // 檔案每一行格式應為「姓名,電話號碼」。
        private void ReadFile()
        {
            StreamReader inputFile;//開啟檔案的StreamReader物件
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = File.OpenText(openFile.FileName);//開啟檔案
                    string line;
                    while (!inputFile.EndOfStream)// 檔案還有資料可讀取
                    {
                        // 讀取檔案每一行，去除空白字元
                        line = inputFile.ReadLine().Trim();
                        // 以逗號分隔姓名與電話號碼
                        string[] parts = line.Split(','); 
                        if (parts.Length == 2)// 如果格式正確
                        {
                            PhoneBookEntry entry = new PhoneBookEntry();//宣告一個PhoneBookEntry結構
                            entry.name = parts[0].Trim(); // 姓名
                            entry.phone = parts[1].Trim(); // 電話號碼
                            phoneList.Add(entry); // 將資料加入清單
                        }
                        else// 如果格式不正確，顯示錯誤訊息
                        {
                            MessageBox.Show("檔案格式錯誤");
                        }
                    }
                    inputFile.Close(); // 關閉檔案
                }
                catch (Exception ex)//嘗試讀取檔案時發生例外狀況
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
        }

        // DisplayNames 方法：將 phoneList 清單中的所有聯絡人姓名
        // 顯示在 nameListBox 控制項中，供使用者選擇。
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)//遍歷所有電話資料
            {
                nameListBox.Items.Add(entry.name); // 將姓名加入 ListBox
            }
        }

        // Form1_Load 事件：當表單載入時執行，通常用來初始化資料，
        // 例如讀取電話簿檔案並顯示聯絡人清單。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 讀取電話簿資料

            DisplayNames(); // 顯示所有姓名在 nameListBox 中
        }

        // nameListBox_SelectedIndexChanged 事件：
        // 當使用者在 nameListBox 中選取不同的姓名時觸發，
        // 用來顯示對應聯絡人的電話號碼。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 取得選取的索引
            if (index !=-1)
            {
                // 顯示選取的聯絡人電話號碼
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 如果沒有選取任何項目，清空顯示的電話號碼
                phoneLabel.Text = "";
            }
        }

        // exitButton_Click 事件：當使用者按下「離開」按鈕時執行，
        //如果有新增電話簿資料，將資料寫回檔案，
        // 用來關閉表單並結束程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            //檢查是否有開啟過檔案
            if (!string.IsNullOrEmpty(openFile.FileName) && File.Exists(openFile.FileName))
            {
                StreamWriter writer = null;
                try
                {
                    // 開啟檔案寫入資料
                    writer = new StreamWriter(openFile.FileName);
                    foreach (PhoneBookEntry entry in phoneList)
                    {
                        // 將姓名與電話號碼寫入檔案
                        writer.WriteLine($"{entry.name},{entry.phone}");
                    }
                }
                catch (Exception ex)
                {
                    // 如果寫入檔案時發生例外狀況，顯示錯誤訊息
                    MessageBox.Show("Error writing file: " + ex.Message);
                }
                finally
                {
                    // 確保檔案被關閉
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
            // 如果沒有開啟過檔案，則不寫入任何資料
            else
            {
                MessageBox.Show("沒有開啟檔案，無法寫入資料");
            }
            // 關閉表單
            this.Close();
        }

        //讀取textboxName與textboxPhone的資料，加入phoneList清單
        //並更新nameListBox與phoneLabel的顯示

        private void button1_Click(object sender, EventArgs e)
        {
            PhoneBookEntry entry; // 宣告一個PhoneBookEntry結構
            entry.name = textBoxName.Text.Trim(); // 取得姓名
            entry.phone = textBoxPhone.Text.Trim(); // 取得電話號碼
            // 檢查姓名與電話號碼是否為空
            if (string.IsNullOrEmpty(entry.name) || string.IsNullOrEmpty(entry.phone))
            {
                MessageBox.Show("姓名或電話號碼不能為空");
                return;
            }
            // 檢查姓名是否重複
            foreach (PhoneBookEntry item in phoneList)
            {
                if (item.name == entry.name)
                {
                    MessageBox.Show("此姓名已存在，請輸入其他姓名");
                    return;
                }
            }
            // 檢查電話號碼是否為3個數字-4個數字
            if (!System.Text.RegularExpressions.Regex.IsMatch(entry.phone, @"^\d{3}-\d{4}$"))
            {
                MessageBox.Show("電話號碼格式錯誤，請輸入正確的格式 (XXX-XXXX)");
                return;
            }
            // 將資料加入phoneList清單
            phoneList.Add(entry); // 將資料加入清單
            nameListBox.Items.Add(entry.name); // 將姓名加入 ListBox
            // 清空textboxName與textboxPhone的資料
            textBoxName.Clear();
            textBoxPhone.Clear();
            // 清空phoneLabel的資料
            phoneLabel.Text = "";
        }
    }
}
