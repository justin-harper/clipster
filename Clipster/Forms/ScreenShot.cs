namespace Clipster.Forms
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    internal class ScreenShot
    {
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
                    g.DrawString(ts.ToString(), f, Brushes.White, b.Width - w.Width, b.Height - w.Height);
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