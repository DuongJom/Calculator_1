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
            string operation = txtScreen.Text;
            double re = 0;
            while (operation.Contains("x") || operation.Contains("/"))
            {
                string firstNum = "", secondNum = "";
                char op = ' ';
                string remain = "";
                int start = 0, end = 0;
                re = 0;
                for (int i = 0; i < operation.Length; i++)
                {
                    if (operation[i] == 'x')
                    {
                        remain = "";
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (operation[j] == '+' || operation[j] == '-' || operation[j] == 'x' || operation[j] == '/' && j != 0)
                            {
                                start = j;
                                break;
                            }
                            firstNum += operation[j];
                        }
                        firstNum = Reverse(firstNum);
                        for (int j = i + 1; j < operation.Length; j++)
                        {
                            if (operation[j] == '+' || operation[j] == '-' || operation[j] == 'x' || operation[j] == '/')
                            {
                                end = j;
                                break;
                            }
                            secondNum += operation[j];
                        }
                        op = operation[i];
                        if (countOperator(operation, i+1) == 0) remain = "";
                        else if (countOperator(operation, i+1) > 0)
                        {
                            for (int j = end; j < operation.Length; j++)
                                remain += operation[j];
                        }
                        re = Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum);
                        break;
                    }
                    else if (operation[i] == '/')
                    {
                        remain = "";
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (operation[j] == '+' || operation[j] == '-' || operation[j] == 'x' || operation[j] == '/' && j != 0)
                            {
                                start = j;
                                break;
                            }
                            firstNum += operation[j];
                        }
                        firstNum = Reverse(firstNum);
                        for (int j = i + 1; j < operation.Length; j++)
                        {
                            if (operation[j] == '+' || operation[j] == '-' || operation[j] == 'x' || operation[j] == '/' && j < operation.Length)
                            {
                                end = j;
                                break;
                            }
                            secondNum += operation[j];
                        }
                        op = operation[i];
                        if (countOperator(operation, i + 1) == 0) remain = "";
                        else if (countOperator(operation, i + 1) > 0)
                        {
                            for (int j = end; j < operation.Length; j++)
                                remain += operation[j];
                        }
                        re = Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum);
                        break;
                    }
                }
                if (start == 0)
                    operation = re.ToString() + remain;
                else
                    operation = operation.Substring(0, start + 1) + re.ToString() + remain;
                if (checkContain(operation) == true)
                    break;
            }
            while (operation.Contains("+") || operation.Contains("-"))
            {
                string firstNum = "", secondNum = "";
                int pos = 0;
                char op = '+';
                if (operation[0] == '-')
                {
                    firstNum = getFirstNumAndSecondNum(operation, 1)[0];
                    secondNum = getFirstNumAndSecondNum(operation, 1)[1];
                    pos = Convert.ToInt32(getFirstNumAndSecondNum(operation, 1)[2]);
                    op = Convert.ToChar(getFirstNumAndSecondNum(operation, 1)[3]);
                }
                else
                {
                    firstNum = getFirstNumAndSecondNum(operation, 0)[0];
                    secondNum = getFirstNumAndSecondNum(operation, 0)[1];
                    pos = Convert.ToInt32(getFirstNumAndSecondNum(operation, 0)[2]);
                    op = Convert.ToChar(getFirstNumAndSecondNum(operation, 0)[3]);
                }
                string remain = "";
                if (countOperator(operation, 1) == 1) remain = "";
                else if (countOperator(operation, 1) > 1)
                {
                    for (int i = pos; i < operation.Length; i++)
                    {
                        remain += operation[i];
                    }
                }
                switch (op)
                {
                    case '+':
                        re = Math.Round(Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum), 2);
                        break;
                    case '-':
                        re = Math.Round(Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum), 2);
                        break;
                }
                operation = re.ToString() + remain;
                if ((countOperator(operation, 1) == 0 && operation[0] == '-') || (countOperator(operation, 1) == 0 && operation[0] != '-'))
                    break;
            }
            lblResult.Text = re.ToString();

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtScreen.ResetText();
            lblResult.Text = "0";
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int countOperator(string s, int pos)
        {
            int count = 0;
            for (int i = pos; i < s.Length; i++)
                if (s[i] == '+' || s[i] == '-')
                    count++;
            return count;
        }
        public static bool checkContain(string s)
        {
            bool flag = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'x' || s[i] == '/')
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static string[] getFirstNumAndSecondNum(string operation, int start)
        {
            string firstNum = "";
            string secondNum = "";
            char op = ' ';
            int pos = 0;
            for (int i = 1; i < operation.Length; i++)
            {
                if (operation[i] == '+' || operation[i] == '-')
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        firstNum += operation[j];
                    }
                    firstNum = Reverse(firstNum);
                    for (int j = i + 1; j < operation.Length; j++)
                    {
                        if (operation[j] == '+' || operation[j] == '-')
                        {
                            pos = j;
                            break;
                        }
                        secondNum += operation[j];
                    }
                    op = operation[i];
                    break;
                }
            }
            return new string[] { firstNum, secondNum, pos.ToString(), op.ToString() };
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length > 0)
            {
                txtScreen.Text = txtScreen.Text.Remove(txtScreen.Text.Length - 1, 1);
            }
        }
    }
}
