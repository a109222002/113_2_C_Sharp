using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_To_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個大小為 5 的整數陣列，用來存放從檔案讀取的數值。
                const int SIZE = 5;
                int[] numbers = new int[SIZE];

                // 用於迴圈的計數變數，初始值為 0。
                int index = 0;

                // 宣告一個 StreamReader 變數，用來讀取檔案。
                StreamReader inputFile;

                // 開啟名為 "Values.txt" 的檔案，並取得 StreamReader 物件。
                inputFile = File.OpenText("Values.txt");

                // 使用 while 迴圈將檔案的內容讀取到陣列中。
                // 當 index 小於陣列長度且檔案未到結尾時，繼續讀取。
                while (index < numbers.Length && !inputFile.EndOfStream)
                {
                    // 讀取檔案中的一行文字，將其轉換為整數並存入陣列中。
                    numbers[index] = int.Parse(inputFile.ReadLine());
                    // 將 index 增加 1，以便存放下一個數值。
                    index++;
                }

                // 關閉檔案。
                inputFile.Close();

                // 使用 foreach 迴圈將陣列中的每個數值顯示在列表框中。
                foreach (int value in numbers)
                {
                    outputListBox.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                // 如果發生例外，顯示錯誤訊息。
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
