using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Clipster.Forms
{
    internal class ScreenShot
    {
        public static void CaptureImage(bool showCursor, Size curSize, Point curPos, Point startP,
            Point destP, Rectangle bounds, string FilePath, string fileExtension, bool saveToClipboard)
        {
            using (Bitmap b = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.CopyFromScreen(startP, destP, bounds.Size);
                    if (showCursor)
                    {
                        Rectangle cursorBounds = new Rectangle(curPos, curSize);
                        Cursors.Default.Draw(g, cursorBounds);
                    }

                    DateTime ts = DateTime.Now;
                    Font f = new Font("Arial", 12f);
                    SizeF w = g.MeasureString(ts.ToString(), f);
                    g.FillRectangle(Brushes.Black, b.Width - w.Width, b.Height - w.Height, w.Width, w.Height);
                    g.DrawString(ts.ToString(), f, Brushes.White, 2, 2);
                }

                if (saveToClipboard)
                {
                    Image img = b;
                    Clipboard.SetImage(img);
                }
                else
                {
                    switch (fileExtension)
                    {
                        case ".png": b.Save(FilePath, ImageFormat.Png); break;
                        default: b.Save(FilePath, ImageFormat.Jpeg); break;
                    }
                }
            }
        }

        public static void CaptureImage(bool showCursor, bool saveToClipBoard, Rectangle saveArea, string fileName, string ext)
        {
            using (Bitmap b = new Bitmap(saveArea.Width, saveArea.Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Point p = new Point(saveArea.X, saveArea.Y);
                    

                    g.CopyFromScreen(p, Point.Empty, saveArea.Size);

                    if (showCursor)
                    {
                        Rectangle cursorBounds = new Rectangle(Cursor.Position, Cursor.Clip.Size);
                        Cursors.Default.Draw(g, cursorBounds);
                    }

                    DateTime ts = DateTime.Now;
                    Font f = new Font("Arial", 12f);
                    SizeF w = g.MeasureString(ts.ToString(), f);
                    g.FillRectangle(Brushes.Black, b.Width - w.Width, b.Height - w.Height, w.Width, w.Height);
                    g.DrawString(ts.ToString(), f, Brushes.White, 2, 2);
                }

                if (saveToClipBoard)
                {
                    Image img = b;
                    Clipboard.SetImage(img);
                }
                else
                {
                    switch (ext)
                    {
                        case ".png": b.Save(fileName, ImageFormat.Png); break;
                        default: b.Save(fileName, ImageFormat.Jpeg); break;
                    }
                }
            }
        }
    }
}