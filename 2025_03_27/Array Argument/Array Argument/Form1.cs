using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Array_Argument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // goButton 控制項的 Click 事件處理程序。
        // 當使用者點擊 goButton 時，這個方法會被呼叫。
        private void goButton_Click(object sender, EventArgs e)
        {
            // 建立一個 int 陣列，包含三個元素 1, 2, 3。
            int[] numbers = { 1, 2, 3 };

            // 在清單框中顯示陣列的原始內容。
            // 先添加一行描述文字，然後逐一添加陣列中的每個元素。
            outputListBox.Items.Add("陣列的原始內容:");
            foreach (int number in numbers)
            {
                outputListBox.Items.Add(number);
            }

            // 將陣列傳遞給 SetToZero 方法，將陣列中的所有元素設為 0。
            SetToZero(numbers);

            // 再次在清單框中顯示陣列。
            // 先添加一行空白行，再添加一行描述文字，然後逐一添加陣列中的每個元素。
            outputListBox.Items.Add("");
            outputListBox.Items.Add("呼叫 SetToZero 之後:");
            foreach (int number in numbers)
            {
                outputListBox.Items.Add(number);
            }
        }

        // SetToZero 方法接受一個 int 陣列作為參數並將其元素設為 0。
        // 這個方法會遍歷陣列中的每個元素，並將其值設為 0。
        private void SetToZero(int[] iArray)
        {
            for (int index = 0; index < iArray.Length; index++)
            {
                iArray[index] = 0;
            }
        }

        // exitButton 控制項的 Click 事件處理程序。
        // 當使用者點擊 exitButton 時，這個方法會被呼叫，並關閉表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
