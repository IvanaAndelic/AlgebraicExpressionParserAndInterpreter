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
                expression = parser.Parse(EnterFunctionTextBox1.Text);
            }

            catch(ParserException pe)
            {
                textBoxErrors.Text = pe.Message;
            }
        }

        private void richTextBox1Fx_TextChanged(object sender, EventArgs e)
        {
            var x_start =Double.Parse(ValueForX0TextBox1.Text);
            var x_end = Double.Parse(ValueForXnTextBox1.Text);

            for (var i = x_start; i <= x_end; ++i)
            {
                var result = expression.Interpret(new Context(i));
                richTextBox1Fx.Text = result.ToString();
            }

        }



        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            var x_start = Double.Parse(ValueForX0TextBox1.Text);
            var x_end =Double.Parse(ValueForXnTextBox1.Text);

            for (var i = x_start; i <= x_end; ++i)
            {
                richTextBox2.Text = i.ToString();
            }
        }

        private void button1Evaluate_Click(object sender, EventArgs e)
        {
            richTextBox1Fx_TextChanged(sender, e);
            richTextBox2_TextChanged(sender, e);

        }
    }
}
