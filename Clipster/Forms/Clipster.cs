using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clipster.Forms;

namespace Clipster
{
    public partial class Clipster : Form
    {
        public Clipster()
        {
            InitializeComponent();
        }

        private void Options_Button_Click(object sender, EventArgs e)
        {
            if (OptionsMenu.Visible == false)
            {
                //Point p = Options_Button.Location;
                Point p = new Point(0,0);
                p.Y += Options_Button.Height  - 1;
                p.X += 1;
                //p.Y += Options_Button.Height - OptionsMenu.Margin.Bottom + 2;
                OptionsMenu.Show(Options_Button, p);
            }
        }

        private void MySplitButton1_MainButtonClick(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string fileExt = string.Empty;

            if (saveToClipboardToolStripMenuItem.Checked == false)
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    DefaultExt = "png",
                    Filter =
                        "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg",
                    Title = "Save Screenshot As",
                    InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfd.FileName;
                    fileExt = fileName.Split('.').Last();
                }
                else
                {
                    return;
                }
            }

            Hide();
            ScreenGrabber sg = new ScreenGrabber(saveToClipboardToolStripMenuItem.Checked, fileName, fileExt);
            sg.FormClosed += ShowMe;
            sg.Show();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {

        }

        private void ShowMe(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void SaveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToClipboardToolStripMenuItem.Checked = !saveToClipboardToolStripMenuItem.Checked;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAboutBox mab = new MyAboutBox();
            mab.Show();
        }
    }
}
