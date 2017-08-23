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
        public ScreenGrabber(bool saveToClipboard, string fileName, string fileExt)
        {
            InitializeComponent();
            Clipping = false;
            SaveToClipBoard = saveToClipboard;
            FileName = fileName;
            FileExt = fileExt;
        }

        public event EventHandler MouseDownEvent;
        public event EventHandler MouseUpEvent;

        private readonly bool SaveToClipBoard;
        private readonly bool ShowCursor;
        private readonly string FileName;
        private readonly string FileExt;

        private Rectangle ScreenShotRect { get; set; }
        private Point StartPoint { get; set; }
        private Point CurentMousePos { get; set; }
        private Graphics g;
        private Pen MyPen = new Pen(Color.Red, 5);
        private SolidBrush MyBrush = new SolidBrush(System.Drawing.Color.Transparent);
        private SolidBrush StringBrush = new SolidBrush(Color.Red);


        private bool Clipping { get; set; }
        private bool Done;

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
            MouseDownEvent?.Invoke(this, e);
            StartPoint = new Point(e.X, e.Y);
            Console.WriteLine($"StartPoint: {StartPoint}");
            Clipping = true;
        }

        private void ScreenGrabber_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Clipping) {return;}

            CurentMousePos = new Point(e.X, e.Y);
            Invalidate();
        }

        private void ScreenGrabber_MouseUp(object sender, MouseEventArgs e)
        {
            Clipping = false;
            SaveSelection();
            MouseUpEvent?.Invoke(this, e);
        }

        private void SaveSelection()
        {
            double o = Opacity;
            Opacity = 0.0;
            System.Threading.Thread.Sleep(250);
            Rectangle x = RectangleToScreen(ScreenShotRect);
            ScreenShot.CaptureImage(ShowCursor, SaveToClipBoard, x, FileName, FileExt);
            Opacity = o;
            Done = true;
            Invalidate();
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
            Rectangle r = new Rectangle(Math.Min(p1.X, p2.X),
                                        Math.Min(p1.Y, p2.Y),
                                        Math.Abs(p1.X - p2.X),
                                        Math.Abs(p1.Y - p2.Y));

            ScreenShotRect = r;
            g.FillRectangle(fill, ScreenShotRect);
            g.DrawRectangle(stroke, ScreenShotRect);

            if (!Done) {return;}

            string mess = SaveToClipBoard ? "Copied To Clipboard" : "Saved to File";
            Font f = new Font("Arial", 32f);
            SizeF s = g.MeasureString(mess, f);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            g.DrawString(mess, f, StringBrush, ScreenShotRect, sf);
            Timer t = new Timer
            {
                Interval = 1000,
            };

            t.Tick += DoneTimerTick;
            t.Start();
        }

        private void ScreenGrabber_Paint(object sender, PaintEventArgs e)
        {
            DrawRectangle(StartPoint, CurentMousePos, MyBrush, MyPen);
        }

        private void DoneTimerTick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
