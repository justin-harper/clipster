using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Clipster.Forms
{
    public partial class ScreenGrabber : Form
    {
        public ScreenGrabber(bool saveToClipboard, bool showCursor, string fileName, string fileExt)
        {
            InitializeComponent();
            Clipping = false;
            SaveToClipBoard = saveToClipboard;
            ShowCursor = showCursor;
            FileName = fileName;
            FileExt = fileExt;
        }

        private readonly bool SaveToClipBoard;
        private readonly bool ShowCursor;
        private readonly string FileName;
        private readonly string FileExt;

        private Rectangle ScreenShotRect { get; set; }
        private Point StartPoint { get; set; }
        private Point EndingPoint { get; set; }
        private Graphics g;
        private Pen MyPen = new Pen(Color.Red, 5);
        private SolidBrush MyBrush = new SolidBrush(System.Drawing.Color.Transparent);

        private Point CurentMousePos { get; set; }

        private bool Clipping { get; set; }

        private void ScreenGrabber_Load(object sender, EventArgs e)
        {
            int height = 0;
            int width = 0;
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            Location = new Point(screenLeft, screenTop);

            foreach (Screen s in Screen.AllScreens)
            {
                if (s.Bounds.Height > height)
                {
                    height = s.Bounds.Height;
                }
                width += s.Bounds.Width;
            }
            Width = width;
            Height = height;
            g = CreateGraphics();
        }

        private void ScreenGrabber_MouseDown(object sender, MouseEventArgs e)
        {
            //StartPoint = PointToClient(Cursor.Position);

            StartPoint = new Point(e.X, e.Y);
            Console.WriteLine($"StartPoint: {StartPoint.ToString()}");
            Clipping = true;
        }

        private void ScreenGrabber_MouseMove(object sender, MouseEventArgs e)
        {
            if (Clipping)
            {
                CurentMousePos = new Point(e.X, e.Y);
                Invalidate();
            }
        }

        private void ScreenGrabber_MouseUp(object sender, MouseEventArgs e)
        {
            Clipping = false;

            SaveSelection();
        }

        private void SaveSelection()
        {
            Point upperLeft = new Point();
            Point bottomRight = new Point();

            upperLeft.X = ScreenShotRect.X;
            upperLeft.Y = ScreenShotRect.Y;

            bottomRight.X = ScreenShotRect.X + ScreenShotRect.Width;
            bottomRight.Y = ScreenShotRect.Y + ScreenShotRect.Height;

            ScreenShot.CaptureImage(ShowCursor, SaveToClipBoard, ScreenShotRect, FileName, FileExt);
        }

        private void ScreenGrabber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void DrawRectangle(Point p1, Point p2, SolidBrush fill, Pen stroke)
        {

            //want to draw a rect from p1 to p2

            Rectangle r = new Rectangle(Math.Min(p1.X, p2.X),
                                        Math.Min(p1.Y, p2.Y),
                                        Math.Abs(p1.X - p2.X),
                                        Math.Abs(p1.Y - p2.Y));



            ScreenShotRect = r;
            Console.WriteLine($"ScreenShotRect: {ScreenShotRect.ToString()}");
            g.FillRectangle(fill, ScreenShotRect);
            g.DrawRectangle(stroke, ScreenShotRect);

            int i = 0;
        }

        private void ScreenGrabber_Paint(object sender, PaintEventArgs e)
        {


            DrawRectangle(StartPoint, CurentMousePos, MyBrush, MyPen);
        }
    }
}
