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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個整數陣列作為參數，
        // 並返回該陣列中數值的平均值。
        private Average(List<int> scores)
        {
            int total = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                total += scores[i];
            }
        }

        // Highest 方法接受一個整數陣列作為參數，
        // 並返回該陣列中的最大值。
        private Highest(List<int> scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
        }

        // Lowest 方法接受一個整數陣列作為參數，
        // 並返回該陣列中的最小值。
        private Lowest(List<int> scores)
        {
            int lowest = scores[0];
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int index = 0;
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開文件
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空分數陣列
                    
                    // 讀取文件
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        // 讀取分數
                        testScores[index] = int.Parse(inputFile.ReadLine());
                        index++;
                    }
                    inputFile.Close();
                    // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);
                    // 顯示結果
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch
            {
                // 顯示錯誤訊息
                MessageBox.Show("Error reading file. Please check the file format and try again.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 計算平均分數
        private double Average(int[] scores)
        {
            double total = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }
            return total / scores.Length;
        }
        // 計算最高分數
        private int Highest(int[] scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }
        // 計算最低分數
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
            return lowest;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }

        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            // 文件選擇確認
            if (openFile.FileName != "")
            {
                // 顯示文件名
                fileNameLabel.Text = openFile.FileName;
            }
            else
            {
                // 清空文件名
                fileNameLabel.Text = "";
            }
        }
    }
}
