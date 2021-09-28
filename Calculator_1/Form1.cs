using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtScreen.Enabled = false;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn9.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn6.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn3.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtScreen.Text += btn0.Text;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtScreen.Text += ",";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            txtScreen.Text += "x";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            txtScreen.Text += "/";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtScreen.Text += "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtScreen.Text += "-";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //int firstNum = Convert.ToInt32(txtScreen.Text[0]-'0');
            //int secondNum = Convert.ToInt32(txtScreen.Text[2]-'0');
            //char op = txtScreen.Text[1];
            //switch (op)
            //{
            //    case '+':
            //        txtScreen.Text = (firstNum + secondNum).ToString();
            //        break;
            //    case '-':
            //        txtScreen.Text = (firstNum - secondNum).ToString();
            //        break;
            //    case 'x':
            //        txtScreen.Text = (firstNum * secondNum).ToString();
            //        break;
            //    case '/':
            //        txtScreen.Text = (firstNum / secondNum).ToString();
            //        break;
            //}
            string operation = txtScreen.Text;
            int firstNum = Convert.ToInt32(operation[0] - '0');
            int secondNum = Convert.ToInt32(operation[2] - '0');
            char op = operation[1];
            int result=0;
            switch (op)
            {
                case '+':
                    result += firstNum + secondNum;
                    break;
                case '-':
                    result += firstNum - secondNum;
                    break;
                case 'x':
                    result += firstNum * secondNum;
                    break;
                case '/':
                    result += firstNum / secondNum;
                    break;
            }
            if (operation.Length > 3)
            {
                for (int i = 3; i < operation.Length; i++)
                {
                    if (operation[i]=='+' || operation[i]=='-' ||
                        operation[i]=='x' || operation[i]=='/')
                    {
                        firstNum = result;
                        secondNum = Convert.ToInt32(operation[i + 1] - '0');
                        op = operation[i];
                        switch (op)
                        {
                            case '+':
                                result = firstNum + secondNum;
                                break;
                            case '-':
                                result = firstNum - secondNum;
                                break;
                            case 'x':
                                result = firstNum * secondNum;
                                break;
                            case '/':
                                result = firstNum / secondNum;
                                break;
                        }
                    }
                }
                txtScreen.Text = result.ToString();
            }
            else
            {
                txtScreen.Text = result.ToString();
            }

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtScreen.ResetText();
        }
    }
}
