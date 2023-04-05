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
using System.Drawing.Printing;
using FunctionGridView;

namespace GUI
{
    public partial class MainForm : Form
    {
        Parser parser = new Parser();
        IExpression expression = null;

        public MainForm()
        {
            InitializeComponent();
            textBoxErrors.Text = string.Empty;
        }

        private void EquationTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxExpression.TextLength != 0)
                {
                    expression = parser.Parse(textBoxExpression.Text);
                    button1Evaluate.Enabled = true;
                }
                else
                {
                    button1Evaluate.Enabled = false;
                }
                textBoxErrors.Text = String.Empty;
            }
            catch (ParserException pe)
            {
                textBoxErrors.Text = pe.Message;
                button1Evaluate.Enabled = false;
            }
            catch (FunctionGridView.EvaluateGridPositionsException pe)
            {
                textBoxErrors.Text = pe.Message;
                button1Evaluate.Enabled = false;
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
            if (x0 >= xn)
            {
                MessageBox.Show("Left bound cannot be greater than left bound");
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
            functionGridView.SetBounds(x0, xn, yMin,yMax);
            functionGridView.NumberOfPoints = n;
            functionGridView.AdjustYScaleAutomatically = checkBoxAdjustAutomatically.Checked;
            functionGridView.Expression = parser.Parse(textBoxExpression.Text);
            functionGridView.Invalidate();
        }

        private void checkBoxAdjustAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            textBoxYMin.Enabled = !checkBoxAdjustAutomatically.Checked;
            textBoxYMax.Enabled = !checkBoxAdjustAutomatically.Checked;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(functionGridView.Width, functionGridView.Height);
            functionGridView.DrawToBitmap(myBitmap1, new Rectangle(0, 0, functionGridView.Width, functionGridView.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 50);
            var font = new Font(textBoxExpression.Font.FontFamily, 20, FontStyle.Regular);
            e.Graphics.DrawString("f(x) = "+textBoxExpression.Text, font, Brushes.Coral, 10, 10);
            myBitmap1.Dispose();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            myPrinDialog1.Document = printDocument1;
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
