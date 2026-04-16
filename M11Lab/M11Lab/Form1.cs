using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M11Lab
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();
        Equals eq = new Equals();
        TextBox calctext;

        public Form1()
        {
            InitializeComponent();
            calctext = textBox1;
        }

        private void update_display()
        {
            if (Calculator.state.GetType() == typeof(DigitOneState))
            {
                calctext.Text = Calculator.num1.ToString();
            } else if(Calculator.state.GetType() == typeof(DigitTwoState))
            {
                calctext.Text = Calculator.num2.ToString();
            } else if(Calculator.state.GetType() == typeof(EqualState))
            {
                calctext.Text = eq.result.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 0 BUTTON
            calculator.nextState(0);
            update_display();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // DIVISION BUTTON
            calculator.nextState(new Divide());
            update_display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1 BUTTON
            calculator.nextState(1);
            update_display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 2 BUTTON
            calculator.nextState(2);
            update_display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 4 BUTTON
            calculator.nextState(4);
            update_display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 3 BUTTON
            calculator.nextState(3);
            update_display();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 5 BUTTON
            calculator.nextState(5);
            update_display();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 6 BUTTON
            calculator.nextState(6);
            update_display();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 7 BUTTON
            calculator.nextState(7);
            update_display();
        }

        private void button9_Click(object sender, EventArgs e)
        {   
            // 8 BUTTON
            calculator.nextState(8);
            update_display();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 9 BUTTON
            calculator.nextState(9);
            update_display();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // MUTIPLY BUTTON
            calculator.nextState(new Multiply());
            update_display();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // SUBTRACT BUTTON
            calculator.nextState(new Subtract());
            update_display();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // ADD BUTTON
            calculator.nextState(new Add());
            update_display();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // EQUAL BUTTON
            calculator.nextState(eq);
            update_display();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            // TAKE NEGATIVE BUTTON
            if (Calculator.state.GetType() == typeof(DigitOneState))
            {
                Calculator.num1 = Calculator.num1 * -1;
            }
            else if (Calculator.state.GetType() == typeof(DigitTwoState))
            {
                Calculator.num2 = Calculator.num2 * -1;
            }

            update_display();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // 1/X BUTTON
            if (Calculator.state.GetType() == typeof(DigitOneState))
            {
                Calculator.num1 = 1 / Calculator.num1;
            }
            else if (Calculator.state.GetType() == typeof(DigitTwoState))
            {
                Calculator.num2 = 1 / Calculator.num2;
            }

            update_display();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // SQRT BUTTON

            if (Calculator.state.GetType() == typeof(DigitOneState))
            {
                Calculator.num1 = Math.Sqrt(Calculator.num1);
            }
            else if (Calculator.state.GetType() == typeof(DigitTwoState))
            {
                Calculator.num2 = Math.Sqrt(Calculator.num2);
            }

            update_display();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // CLEAR BUTTON
            Calculator.num1 = 0;
            Calculator.num2 = 0;
            Calculator.state = new DigitOneState();
            Calculator.lastOperand = 0;
            Calculator.lastOperator = null;
            update_display();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // . BUTTON

            if (Calculator.state.GetType() == typeof(DigitOneState))
            {
                Calculator.num1 = Calculator.num1 / 10;
            }
            else if (Calculator.state.GetType() == typeof(DigitTwoState))
            {
                Calculator.num2 = Calculator.num2 / 10;
            }

            update_display();
        }
    }
}
