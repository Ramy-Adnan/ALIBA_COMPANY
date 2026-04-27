using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_about : DevExpress.XtraEditors.XtraForm
    {
        public FRM_about()
        {
            InitializeComponent();
        }

        private void FRM_about_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a font and a path for the text
            Font font = new Font("Arial", 20, FontStyle.Bold);
            GraphicsPath path = new GraphicsPath();

            // Add the text to the path
            path.AddString("رامي العفلوكي", font.FontFamily, (int)font.Style, font.Size, new PointF(0, 0), StringFormat.GenericDefault);

            // Draw the heart shape
            DrawHeart(g, path);
        }

        private void DrawHeart(Graphics g, GraphicsPath textPath)
        {
            // Define heart shape using Bezier curves
            GraphicsPath heartPath = new GraphicsPath();
            
            heartPath.AddBezier(new Point(100, 150), new Point(50, 50), new Point(150, 50), new Point(100, 150));
            heartPath.AddBezier(new Point(100, 150), new Point(200, 50), new Point(300, 50), new Point(100, 150));

            // Transform textPath to fit inside the heart shape
            Matrix transformMatrix = new Matrix();
            transformMatrix.Rotate(45);
            transformMatrix.Translate(100, 100);
            textPath.Transform(transformMatrix);

            // Draw the heart shape
            Pen pen = new Pen(Color.Red, 2);
            g.DrawPath(pen, heartPath);

            // Draw the text along the heart shape
            pen = new Pen(Color.Blue, 1);
            g.DrawPath(pen, textPath);
        }
    }
}