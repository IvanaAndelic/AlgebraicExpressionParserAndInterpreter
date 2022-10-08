using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgebraicExpressionInterpreter;
using AlgebraicExpressionParser;

namespace CustomControls

{
    public class FunctionGridView : PictureBox
    {
        public double XLeft = -3;
        public double XRight = 3;
        public double YBottom = -1;
        public double YTop = 1;
        public IExpression Expression;


        public FunctionGridView()
        {
            BackColor = SystemColors.Window;
            BorderStyle = BorderStyle.FixedSingle;
            InitializeExpression();
        }

        private void InitializeExpression()
        {
            var parser = new Parser();
            Expression = parser.Parse("sin(x)");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawGrid(pe.Graphics);
            DrawExpression(pe.Graphics);
        }

        private void DrawGrid(Graphics g)
        {

        }
        private void DrawExpression(Graphics g)
        {
            if (Expression == null)
                return;
            double xFactor = ClientRectangle.Width / (XRight - XLeft);
            double yFactor = ClientRectangle.Height / (YTop - YBottom);
            int n = 20;
            PointF[] points = new PointF[n + 1];
            for (int i = 0; i <= n; ++i)
            {
                double x = (XRight - XLeft) / n * i;
                double y = Expression.Interpret(new Context(x));
                float xClient = (float)((x) * xFactor);
                float yClient = (float)((y - YBottom) * yFactor);
                PointF point = new PointF(xClient, yClient);
                points[i] = point;
            }
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawCurve(Pens.Black, points);
        }
    }
}
