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
using System.Globalization;

namespace CustomControls

{
    public delegate double Function(double x);
    public class FunctionGridView : System.Windows.Forms.Panel
    {
        private double XLeft = -1;
        private double XRight = 1;
        private double YBottom = -1;
        private double YTop = 1;
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
            m_displayBounds = new RectangleF((float)x0, (float)y0, (float)(xn - x0), (float)(yn - y0));
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
            return (int)(((YTop - y) / m_displayBounds.Height) * ClientRectangle.Height);
        }
        public int ScreenX(double x)
        {
            return (int)(((x - XLeft) / m_displayBounds.Width) * ClientRectangle.Width);
        }

        private void DrawGrid(Graphics g)
        {
            using (Pen pen = new Pen(Color.Gray))
            {
                MarkAxes(g, pen);
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
            int y0 = ClientRectangle.Top;
            int y1 = ClientRectangle.Bottom;
            double x = XLeft;
            double increment = m_displayBounds.Width / 5;
            while (x <= m_displayBounds.Width)
            {
                int xScr = ScreenX(x);
                graphics.DrawLine(penGrid, xScr, y0, xScr, y1);

                var label = x.ToString("F", CultureInfo.InvariantCulture);
                var labelSize = graphics.MeasureString(label, drawFont);
                float y = ScreenY(0);
                var labelRectangle = new RectangleF(new PointF(xScr - labelSize.Width / 2, y + 3), labelSize);
                if (IsInsideView(labelRectangle))
                {
                    graphics.DrawString(label, drawFont, drawBrush, labelRectangle);
                }
                x += increment;
            }
            if (XLeft < 0 && XRight > 0)
            {
                int xScr = ScreenX(0);
                graphics.DrawLine(pen, xScr, y0, xScr, y1);
            }
        }

        private bool IsInsideView(RectangleF rect)
        {
            var viewRect = new RectangleF(0, 0, ClientRectangle.Width, ClientRectangle.Height);
            return viewRect.Contains(rect);
        }

        private void MarkYAxes(Graphics graphics, Pen pen, Pen penGrid)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x0 = ClientRectangle.Left;
            int x1 = ClientRectangle.Right;
            double y = YBottom;
            double increment = m_displayBounds.Height / 5;
            while (y <= m_displayBounds.Height)
            {
                int yScr = ScreenY(y);
                graphics.DrawLine(penGrid, x0, yScr, x1, yScr);

                var label = y.ToString("F", CultureInfo.InvariantCulture);
                var labelSize = graphics.MeasureString(label, drawFont);
                float x = ScreenX(0);
                var labelRectangle = new RectangleF(new PointF(x + 3, yScr - labelSize.Height / 2), labelSize);
                if (IsInsideView(labelRectangle))
                {
                    graphics.DrawString(label, drawFont, drawBrush, labelRectangle);
                }
                y += increment;
            }
            if (YBottom < 0 && YTop > 0)
            {
                int yScr = ScreenY(0);
                graphics.DrawLine(pen, x0, yScr, x1, yScr);
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
