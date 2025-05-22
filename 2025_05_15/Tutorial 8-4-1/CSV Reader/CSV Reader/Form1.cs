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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line;// 儲存讀取的每一列資料
                //int count = 0;// 計算讀取的列數
                int total = 0;// 計算總分數
                double average = 0;// 計算平均分數

                char[] delim = { ',',' ',':' };// 定義分隔符號為逗號,空格

                // 顯示檔案選擇對話方塊，讓使用者選擇要開啟的CSV檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟使用者所選擇的檔案，準備進行讀取
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        // 讀取每一列資料
                        line = inputFile.ReadLine();
                        line = line.Trim();// 去除前後空白
                        string[] tokens = line.Split(delim);// 使用分隔符號將資料分割成陣列
                        total = 0;// 每次讀取新列時，重置總分數為0
                        string name = tokens[0];// 取得學生姓名

                        // 將分割後的資料轉換為整數，並計算總分數
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            // 將字串轉換為整數，並加總到總分數中
                            total += int.Parse(tokens[i]);
                        }
                        // 計算平均分數
                        average = (double)total / (tokens.Length-1);// 計算平均值
                        // 將平均分數加入到ListBox中
                        averagesListBox.Items.Add(name+ "同學的平均分數為：" + average.ToString("F2"));// 顯示平均分數
                    }
                }
                else
                {
                    // 若使用者未選擇檔案，顯示提示訊息
                    MessageBox.Show("未選擇任何檔案。");
                }
            }
            catch (Exception ex)
            {
                // 發生例外狀況時，顯示錯誤訊息與詳細內容
                MessageBox.Show("發生錯誤：" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式
            this.Close();
        }
    }
}
