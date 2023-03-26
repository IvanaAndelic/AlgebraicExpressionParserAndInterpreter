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
    public partial class MainForm : Form
    {
        Parser parser = new Parser();
        IExpression expression = null;
        
        //line which is currently being printed
        int counter ;
        //defines the page that is currently being printed
        int curPage;
        //declaring of the bitmap object
        Bitmap bmp;
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
            //provjeriti x0>=xn; dodati messageBox
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
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //Before printing, set counter variables to initial value
            counter = 0;
            curPage = 1;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dataGridView = new DataGridView();
            bmp = new Bitmap(dataGridView.Width, dataGridView.Height);
            dataGridView.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView.Width, dataGridView.Height));
            printPreviewDialog1.ShowDialog();

        }
    }
}
