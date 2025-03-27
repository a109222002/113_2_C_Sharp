namespace NumberFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int number;
            double frequency;
            Random random = new Random();
            int[] numbers = new int[SIZE];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            if (int.TryParse(NumberTextBox.Text, out number))
            {
                // 確保除法運算是浮點數運算
                frequency = frequencyOFNumber(numbers, number) / (double)SIZE;
                MessageBox.Show("數字" + number + "出現的機率為" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("型態錯誤，請輸入整數");
            }
        }

        private int frequencyOFNumber(int[] numbers, int number)
        {
            // 初始化計數器
            int count = 0;

            // 遍歷數字陣列
            for (int i = 0; i < numbers.Length; i++)
            {
                // 如果當前數字等於目標數字，計數器加一
                if (numbers[i] == number)
                {
                    count++;
                }
            }

            // 返回目標數字出現的次數
            return count;
        }
    }
}
