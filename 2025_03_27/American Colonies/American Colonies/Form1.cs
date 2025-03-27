using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace American_Colonies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // SequentialSearch 方法在字串陣列中搜尋指定的值。
        // 如果找到該值，則返回其位置。否則，返回 -1。
        // 參數:
        //   sArray: 要搜尋的字串陣列。
        //   value: 要搜尋的值。
        // 返回:
        //   如果找到該值，則返回其在陣列中的位置。否則，返回 -1。
        private int SequentialSearch(string[] sArray, string value)
        {
            bool found = false;  // 標誌搜尋結果
            int index = 0;       // 用於遍歷陣列
            int position = -1;   // 如果找到值，則返回其位置

            // 搜尋陣列。
            while (!found && index < sArray.Length)
            {
                if (sArray[index] == value)
                {
                    found = true;
                    position = index;
                }

                index++;
            }

            // 返回位置
            return position;
        }

        // okButton_Click 方法在使用者點擊 "確定" 按鈕時觸發。
        // 它會檢查使用者選擇的項目是否在最初的13個殖民地名稱陣列中。
        // 如果在陣列中，則顯示 "是的，那是其中之一的殖民地。" 的訊息。
        // 否則，顯示 "不，那不是其中之一的殖民地。" 的訊息。
        private void okButton_Click(object sender, EventArgs e)
        {
            string selection;   // 保存使用者的選擇

            // 建立包含殖民地名稱的陣列。
            string[] colonies = {  "德拉瓦", "賓夕法尼亞", "新澤西",
                                    "喬治亞", "康乃狄克", "麻薩諸塞",
                                    "馬里蘭", "南卡羅來納", "新罕布夏",
                                    "維吉尼亞", "紐約", "北卡羅來納",
                                    "羅德島" };

            if (selectionListBox.SelectedIndex != -1)
            {
                // 獲取選定的項目。
                selection = selectionListBox.SelectedItem.ToString();

                // 確定該項目是否在陣列中。
                if (SequentialSearch(colonies, selection) != -1)
                {
                    MessageBox.Show("是的，那是其中之一的殖民地。");
                }
                else
                {
                    MessageBox.Show("不，那不是其中之一的殖民地。");
                }
            }
        }

        // exitButton_Click 方法在使用者點擊 "退出" 按鈕時觸發。
        // 它會關閉當前的表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
