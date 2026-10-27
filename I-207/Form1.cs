using System;
using System.Windows.Forms;

namespace I_207
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопки с цифрами 0-9
        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isNewNumber)
            {
                textBox1.Text = btn.Text;
                isNewNumber = false;
            }
            else
            {
                textBox1.Text = textBox1.Text + btn.Text;
            }
        }

        // Кнопки операций +, -, *, /, ^
        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (textBox1.Text != "")
            {
                // Заменяем точку на запятую, чтобы Parse не выдал ошибку
                firstNumber = double.Parse(textBox1.Text.Replace('.', ','));
                operation = btn.Text;
                isNewNumber = true;
            }
        }

        // Кнопка равно =
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || operation == "")
                return;

            double secondNumber = double.Parse(textBox1.Text.Replace('.', ','));
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("На ноль делить нельзя!");
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
                case "^":
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
            }

            // Выводим результат
            textBox1.Text = result.ToString();

            // Сбрасываем операцию, чтобы можно было считать дальше
            operation = "";
            isNewNumber = true;
        }

        // Кнопка точки .
        private void button11_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                textBox1.Text = "0,";
                isNewNumber = false;
            }
            else if (!textBox1.Text.Contains(",") && !textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        // Кнопка процента %
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double number = double.Parse(textBox1.Text.Replace('.', ','));
                textBox1.Text = (number / 100).ToString();
                isNewNumber = true;
            }
        }

        // Кнопка очистки C
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            firstNumber = 0;
            operation = "";
            isNewNumber = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
