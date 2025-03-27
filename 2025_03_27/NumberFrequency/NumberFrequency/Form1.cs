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
                // �T�O���k�B��O�B�I�ƹB��
                frequency = frequencyOFNumber(numbers, number) / (double)SIZE;
                MessageBox.Show("�Ʀr" + number + "�X�{�����v��" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("���A���~�A�п�J���");
            }
        }

        private int frequencyOFNumber(int[] numbers, int number)
        {
            // ��l�ƭp�ƾ�
            int count = 0;

            // �M���Ʀr�}�C
            for (int i = 0; i < numbers.Length; i++)
            {
                // �p�G��e�Ʀr����ؼмƦr�A�p�ƾ��[�@
                if (numbers[i] == number)
                {
                    count++;
                }
            }

            // ��^�ؼмƦr�X�{������
            return count;
        }
    }
}
