using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kab2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Input(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                char symbol = textBox.Text[^1];
                if (!(symbol >= '0' && symbol <= '9') && !(symbol == ' '))
                {
                    MessageBox.Show("Ошибка ввода! Вводите только цифры или пробел");
                    textBox.Text = textBox.Text[0..^1];
                }
            }
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox.Text += " ";
                int n = 0;
                int x = 1;
                int number = 0;
                int previousNumber = 0;
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i] >= '0' && textBox.Text[i] <= '9')
                    {
                        number = number * 10 + textBox.Text[i];
                    }
                    else
                    {
                        if (number == previousNumber && n < 1)
                        {
                            n = x;
                        }
                        x++;
                        previousNumber = number;
                        number = 0;
                    }

                }
                if (n == 0)
                {
                    MessageBox.Show("Рядом стоящих пар одинаковых чисел нет");
                }
                else
                {
                    MessageBox.Show("Одинаковые числа под номерами " + (n - 1) + " и " + n);
                }
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            textBox.Focus();
        }
    }
}

