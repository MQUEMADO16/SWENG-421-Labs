using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M5Lab
{
    public partial class Form1 : Form
    {
        private List<string> operationsStrings;
        OperationFactoryIF operationFactory;
        OperationIF currentOperation;

        public Form1()
        {
            InitializeComponent();
            operationsStrings = new List<string>();
            operationFactory = new OperationFactory();
        }

        // Initial Setup
        private void Form1_Load(object sender, EventArgs e)
        {
            operationsStrings = File.ReadAllLines("modules.txt").ToList();

            // Sort by alphabetical order
            operationsStrings.Sort();
            currentOperation = operationFactory.create(operationsStrings.First());

            comboBox1.Items.Clear();
            foreach (string operation in operationsStrings)
            {
                comboBox1.Items.Add(operation);
            }

            if (comboBox1.Items.Count > 0) { comboBox1.SelectedIndex = 0; }
            textBox2.Text = currentOperation.getValue().ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newOperation = comboBox1.SelectedItem.ToString();
            currentOperation = operationFactory.create(newOperation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentOperation.GetType().Name == "Log")
                currentOperation.compute();
            currentOperation.compute(Double.Parse(textBox1.Text));
            textBox2.Text = currentOperation.getValue().ToString();
        }
    }
}
