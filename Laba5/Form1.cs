namespace Laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsValidDoubleInput(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (!double.TryParse(textBox.Text, out _)) return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValidDoubleInput(textBox1, textBox2, textBox3, textBox6, textBox5, textBox4, textBox7, textBox8))
            {
                MessageBox.Show("������: ������� ���������� ������.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else work();

            void work()
            {
                // ������������� ���������� ��������� ����� � ������ ��� �������� ���
                Random randomGenerator = new Random();
                List<Random> randomList = new List<Random>();

                // ���������� ��� �������� �����������
                int n = Convert.ToInt32(textBox9.Text);
                if (n > 100000)
                {
                    MessageBox.Show("������: ��������� ���� ��� ����� ����������, ��������.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int trueCount = 0;

                // ������ ������������ � ������
                bool[] blocks = new bool[7];
                double[] probabilities = new double[9];
                bool[] p = new bool[9];

                // ���������� ������� ������������
                for (int i = 1; i <= 8; i++)
                {
                    probabilities[i] = Convert.ToDouble(Controls.Find("textBox" + i, true)[0].Text);
                }

                // ���������� ������ ������������ ��������� �����
                for (int i = 0; i < p.Length; i++)
                {
                    randomList.Add(new Random(randomGenerator.Next(10000)));
                }

                // ������� ����
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j < p.Length; j++)
                    {
                        double randomValue = randomList[j - 1].NextDouble();
                        p[j] = randomValue <= probabilities[j];
                    }

                    // ���������� ������
                    blocks[0] = (p[1] && p[2]) || (p[3] && p[4]);
                    blocks[1] = (p[5] || (p[6] && p[7])) && p[8];
                    blocks[2] = p[9] || (p[10] && (p[11] || p[12]));
                    blocks[3] = p[13] || p[14] || (p[15] && p[16]);

                    // ���������� ����������
                    bool result = blocks[0] || (blocks[1] && blocks[2] && blocks[3]);

                    if (result)
                    {
                        trueCount++;
                    }
                }
            }
        }
    }
}