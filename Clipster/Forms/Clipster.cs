namespace Clipster
{
    using System;
    using System.Deployment.Application;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;

    public partial class Clipster : Form
    {
        ScreenGrabber sg;

        public Clipster()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CheckForUpdates();
        }

        private void Options_Button_Click(object sender, EventArgs e)
        {
            if (OptionsMenu.Visible == false)
            {
                Point p = new Point(0,0);
                p.Y += Options_Button.Height  - 1;
                p.X += 1;
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
            
            sg = new ScreenGrabber(saveToClipboardToolStripMenuItem.Checked, fileName, fileExt);
            sg.MouseUpEvent += ShowMe;
            sg.MouseDownEvent += HideMe;
            sg.Show();
        }

        private void HideMe(object sender, EventArgs e)
        {
            Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            sg.Close();
        }

        private void ShowMe(object sender, EventArgs e)
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

        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForUpdates() == false)
            {
                MessageBox.Show(@"Application is up to date", @"No Update Available");
            }
        }

        private bool CheckForUpdates()
        {
            try
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                if (ad.CheckForUpdate())
                {
                    if (MessageBox.Show(@"Update to the latest version?", @"Update Available",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DoUpdate(ad);
                    }
                    return true;
                }
                else {return false;}
            }
            catch (Exception e)
            {
                MessageBox.Show("Error checking for updates", "Error");
                return false;
            }
        }

        private void DoUpdate(ApplicationDeployment ad)
        {
            ad.Update();
            MessageBox.Show($"Application updated successfuly{Environment.NewLine}Please relaunch the application", "Update Success");
            Environment.Exit(0);
        }
    }
}
