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
namespace GUI
{
    public partial class Form1 : Form
    {
        Parser parser = new Parser();
        IExpression expression = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void EquationTextChanged(object sender, EventArgs e)
        {
            try
            {
                expression = parser.Parse(textBoxExpression.Text);
                textBoxErrors.Clear();

            }
            catch (ParserException pe)
            {
                textBoxErrors.Text = pe.Message;
            }

        }

        private void EvaluateButtonClick(object sender, EventArgs e)
        {
            //var x = Double.Parse(textBoxValueForX.Text);
            //var result=expression.Interpret(new Context(x));
            //textBoxResult.Text = result.ToString();

        }

        private void button1Evaluate_Click(object sender, EventArgs e)
        {
            functionGridView.XLeft = -3;
            functionGridView.XRight = 3;
            functionGridView.Expression=parser.Parse(textBoxExpression.Text);
            functionGridView.Invalidate();
        }
    }
}
