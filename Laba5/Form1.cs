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
                double[] probabilities = new double[9];
                bool[] p = new bool[9];

                // Заполнение массива вероятностей
                for (int i = 1; i <= 8; i++)
                {
                    probabilities[i] = Convert.ToDouble(Controls.Find("textBox" + i, true)[0].Text);
                }

                // Заполнение списка генераторами случайных чисел
                for (int i = 0; i < p.Length; i++)
                {
                    randomList.Add(new Random(randomGenerator.Next(10000)));
                }


            }
        }
    }
}