using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;
using System.Globalization;

namespace GUI2
{
    

    public partial class Form1 : Form
    {
        Parser parser = new Parser();
        IExpression expression = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void EnterFunctionTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                expression = parser.Parse(textBoxFunction.Text);
                textBoxErrors.Clear();
            }
            catch(ParserException pe)
            {
                textBoxErrors.Text = pe.Message;
            }
        }

        private void button1Evaluate_Click(object sender, EventArgs e)
        {
            listViewExpressionValues.Items.Clear();

            if (expression==null || textBoxFunction.TextLength == 0)
            {
                MessageBox.Show("Invalid expression");
                return;
            }
            if(double.TryParse(textBoxValueForX0.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double x0) == false)
            {
                MessageBox.Show("Invalid x0");
                return;
            } 
            if(double.TryParse(textBoxValueForXn.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double xn) == false)
            {
                MessageBox.Show("Invalid xn");
                return;
            }
            //TODO:Check if x0 and xn valid
            if(int.TryParse(textBoxIntervalsNumber.Text, out int n) == false)
            {
                MessageBox.Show("Invalid n");
                return;
            }
            if (n <= 0)
            {
                MessageBox.Show("Invalid n");
                return;
            }
            for(int i=0; i <= n; ++i)
            {
                double x = (xn - x0) / n * i;
                double y=expression.Interpret(new Context(x));
                listViewExpressionValues.Items.Add(new ListViewItem(new string[] { x.ToString(),y.ToString()}));
            }
        }
    }
}
