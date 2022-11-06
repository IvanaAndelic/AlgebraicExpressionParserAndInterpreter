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

        private void button1Evaluate_Click(object sender, EventArgs e)
        {
            if (expression == null || textBoxExpression.TextLength == 0)
            {
                MessageBox.Show("Invalid expression");
                return;
            }
            if (double.TryParse(textBoxValueForX0.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double x0) == false)
            {
                MessageBox.Show("Invalid x0");
                return;
            }
            if (double.TryParse(textBoxValueForXn.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double xn) == false)
            {
                MessageBox.Show("Invalid xn");
                return;
            }
            if (double.TryParse(textBoxYMin.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double yMin) == false)
            {
                MessageBox.Show("Invalid yMin");
                return;
            }
            if (double.TryParse(textBoxYMax.Text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double yMax) == false)
            {
                MessageBox.Show("Invalid yMax");
                return;
            }
            //TODO:Check if x0 and xn valid
            if (int.TryParse(textBoxIntervalsNumber.Text, out int n) == false)
            {
                MessageBox.Show("Invalid n");
                return;
            }
            if (n <= 0)
            {
                MessageBox.Show("Invalid n");
                return;
            }

            functionGridView.XLeft = x0;
            functionGridView.XRight = xn;
            functionGridView.NumberOfPoints = n;
            functionGridView.YBottom = yMin;
            functionGridView.YTop = yMax;
            functionGridView.AdjustYScaleAutomatically = checkBoxAdjustAutomatically.Checked;
            functionGridView.Expression=parser.Parse(textBoxExpression.Text);
            functionGridView.Invalidate();
        }

        private void checkBoxAdjustAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            textBoxYMin.Enabled = !checkBoxAdjustAutomatically.Checked;
            textBoxYMax.Enabled = !checkBoxAdjustAutomatically.Checked;
        }
    }
}
