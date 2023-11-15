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
                MessageBox.Show("Ошибка: Введите корректные данные.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else work();

            void work()
            {
                // Инициализация генератора случайных чисел и списка для хранения них
                Random randomGenerator = new Random();
                List<Random> randomList = new List<Random>();

                // Переменные для хранения результатов
                int n = Convert.ToInt32(textBox9.Text);
                if (n > 100000)
                {
                    MessageBox.Show("Ошибка: Компьютер слаб для таких вычислений, извините.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int trueCount = 0;

                // Массив вероятностей и блоков
                bool[] ways = new bool[8];
                double[] valuesP = new double[9];
                bool[] p = new bool[9];

                // Заполнение массива вероятностей
                for (int i = 1; i <= 8; i++)
                {
                    valuesP[i] = Convert.ToDouble(Controls.Find("textBox" + i, true)[0].Text);
                }

                // Заполнение списка генераторами случайных чисел
                for (int i = 0; i < p.Length; i++)
                {
                    randomList.Add(new Random(randomGenerator.Next(10000)));
                }

                // Главный цикл
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j < p.Length; j++)
                    {
                        double randomValue = randomList[j - 1].NextDouble();
                        p[j] = randomValue <= valuesP[j];
                    }

                    // Вычисление путей
                    ways[0] = p[1] && p[2] && p[3];
                    ways[1] = p[1] && p[2] && p[8] && p[6];
                    ways[2] = p[1] && p[7] && p[5] && p[6];
                    ways[3] = p[1] && p[7] && p[5] && p[8] && p[3];

                    ways[4] = p[4] && p[5] && p[6];
                    ways[5] = p[4] && p[5] && p[8] && p[3];
                    ways[6] = p[4] && p[7] && p[2] && p[3];
                    ways[7] = p[4] && p[7] && p[2] && p[8] && p[6];

                    // Вычисление результата
                    bool result = ways[0] || ways[1] || ways[2] || ways[3] || ways[4] || ways[5] || ways[6] || ways[7] || ways[8];

                    if (result)
                    {
                        trueCount++;
                    }
                }

                double result1 = (1 - (1 - valuesP[1]) * (1 - valuesP[4])) * (1 - (1 - valuesP[2]) * (1 - valuesP[5]) * (1 - (1 - valuesP[3]) * (1 - valuesP[6])));
                double result2 = (1 - (1 - valuesP[1]) * (1 - valuesP[4])) * (1 - (1 - valuesP[2] * valuesP[3]) * (1 - valuesP[5] * valuesP[6]));
                double result3 = (1 - (1 - valuesP[1] * valuesP[2]) * (1 - valuesP[4] * valuesP[5])) * (1 - (1 - valuesP[3]) * (1 - valuesP[6]));
                double result4 = (1 - valuesP[1] * valuesP[2] * valuesP[3]) * (1 - valuesP[4] - valuesP[5] - valuesP[6]);

                double result5 = valuesP[8] * result1 + (1 - valuesP[8]) * result2;
                double result6 = valuesP[8] * result3 + (1 - valuesP[8]) * result4;

                double finalResult = valuesP[7] * result5 + (1 - valuesP[7]) * result6;

                textBox10.Text = Convert.ToString(finalResult);
                textBox11.Text = Convert.ToString((double)trueCount / n);

            }
        }
    }
}