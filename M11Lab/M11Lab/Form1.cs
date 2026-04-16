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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 0 BUTTON
            calculator.nextState(0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // DIVISION BUTTON
            calculator.nextState(new Divide());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // 1 BUTTON
            calculator.nextState(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 2 BUTTON
            calculator.nextState(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 4 BUTTON
            calculator.nextState(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 3 BUTTON
            calculator.nextState(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 5 BUTTON
            calculator.nextState(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 6 BUTTON
            calculator.nextState(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 7 BUTTON
            calculator.nextState(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {   
            // 8 BUTTON
            calculator.nextState(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 9 BUTTON
            calculator.nextState(9);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // MUTIPLY BUTTON
            calculator.nextState(new Multiply());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // SUBTRACT BUTTON
            calculator.nextState(new Subtract());  
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // ADD BUTTON
            calculator.nextState(new Add());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // EQUAL BUTTON
            calculator.nextState(eq);
        }
    }
}
