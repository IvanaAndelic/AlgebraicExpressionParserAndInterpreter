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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls

{
    public delegate double Function(double x);
    public class FunctionGridView : System.Windows.Forms.Panel
    {
        public double XLeft = -1;
        public double XRight = 1;
        public double YBottom = -1;
        public double YTop = 1;
        public bool AdjustYScaleAutomatically = false;
        public int NumberOfPoints = 10;
        public IExpression Expression = null;


        public FunctionGridView()
        {
            BackColor = SystemColors.Window;
            BorderStyle = BorderStyle.FixedSingle;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public void SetBounds(double x0, double xn, double y0, double yn)
        {
            XLeft = x0;
            XRight = xn;
            YBottom = y0;
            YTop = yn;
            m_displayBounds = new RectangleF((float)x0, (float)y0, (float)(xn -x0), (float)(yn -y0));
        }

        private RectangleF m_displayBounds = new RectangleF(-5, -5, 10, 10);

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (Expression == null)
                return;
            var values = EvaluateExpression();
            if (AdjustYScaleAutomatically)
            {
                YBottom = values.Min();
                YTop = values.Max();
            }
            DrawGrid(pe.Graphics);
            DrawExpression(pe.Graphics, values);

        }
        public int ScreenY(double y)
        {
            return (int)((1 - y / (m_displayBounds.Height / 2)) * ClientRectangle.Height / 2);
        }
        public int ScreenX(double x)
        {
            return (int)(((x-XLeft) / m_displayBounds.Width) * ClientRectangle.Width);
        }

        private void DrawGrid(Graphics g)
        {
            using (Pen pen = new Pen(Color.Gray))
            {
                MarkAxes(g, pen);
                //g.DrawLine(pen, 0, ClientRectangle.Height / 2,
                //    ClientRectangle.Width, ClientRectangle.Height / 2);
                //g.DrawLine(pen, ClientRectangle.Width / 2, 0,
                //    ClientRectangle.Width / 2, ClientRectangle.Height);
            }
        }
        private void MarkAxes(Graphics graphics, Pen pen)
        {
            using (Pen penGrid = new Pen(Color.LightGray))
            {
                penGrid.DashStyle = DashStyle.Dot;
                MarkXAxes(graphics, pen, penGrid);
                MarkYAxes(graphics, pen, penGrid);
            }
        }

        private void MarkXAxes(Graphics graphics, Pen pen, Pen penGrid)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int y0 = ScreenY(YTop);
            int y1 = ScreenY(YBottom);
            double x = XLeft;
            double increment = m_displayBounds.Width / 5;
            while (x <= m_displayBounds.Width)
            {
                int xScr = ScreenX(x);
                graphics.DrawLine(penGrid, xScr, 0, xScr, this.Height);
                graphics.DrawLine(pen, xScr, y0, xScr, y1);
                float y = ScreenY(0);
                SizeF labelSize = graphics.MeasureString(x.ToString(), drawFont);
                //if (DaLiJeCijeliUnutarPanela(new Point((int)(xScr - labelSize.Width / 2), (int)(y + 3)), labelSize)) {
                graphics.DrawString(x.ToString(), drawFont, drawBrush, xScr - labelSize.Width / 2, y + 3);
                //}
                x += increment;
            }
        }

        private void MarkYAxes(Graphics graphics, Pen pen, Pen penGrid)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x0 = ScreenX(0) - 3;
            int x1 = ScreenX(0) + 3;
            double y = -m_displayBounds.Height;
            double increment = m_displayBounds.Height / 5;
            while (y <= m_displayBounds.Height)
            {
                int yScr = ScreenY(y);
                graphics.DrawLine(penGrid, 0, yScr, this.Width, yScr);
                graphics.DrawLine(pen, x0, yScr, x1, yScr);
                SizeF labelSize = graphics.MeasureString(y.ToString(), drawFont);
                //if (DaLiJeCijeliUnutarPanela(new Point(X1, (int)(Yscr - velicina.Height / 2)), velicina)) {
                graphics.DrawString(y.ToString(), drawFont, drawBrush, x1, yScr - labelSize.Height / 2);
                //}
                y += increment;
            }
        }
        private void DrawExpression(Graphics g, double[] values)
        {
            if (Expression == null)
                return;
            double xFactor = ClientRectangle.Width / (XRight - XLeft);
            double yFactor = ClientRectangle.Height / (YTop - YBottom);
            PointF[] points = new PointF[NumberOfPoints + 1];
            for (int i = 0; i <= NumberOfPoints; ++i)
            {
                double x = (XRight - XLeft) / NumberOfPoints * i;
                double y = values[i];
                float xClient = (float)((x) * xFactor);
                float yClient = (float)((YBottom - y) * yFactor) + ClientRectangle.Height;
                PointF point = new PointF(xClient, yClient);
                points[i] = point;
            }
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawCurve(Pens.Black, points);
        }


        private double[] EvaluateExpression()
        {
            double[] values = new double[NumberOfPoints + 1];
            for (int i = 0; i <= NumberOfPoints; ++i)
            {
                double x = (XRight - XLeft) / NumberOfPoints * i + XLeft;
                double y = Expression.Evaluate(new Context(x));
                values[i] = y;
            }
            return values;
        }
    }
}
