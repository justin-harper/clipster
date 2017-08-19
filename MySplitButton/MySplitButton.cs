﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySplitbutton
{
    public partial class MySplitButton : UserControl
    {
        [Category("Appearance")]
        [Description("Text to display on the main button")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string ButtonText
        {
            get => MainButton.Text; set => MainButton.Text = value;
        }

        [Category("Behavior")]
        [Description("Context menu to display")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public ContextMenuStrip ButtonDropDownList
        {
            get => this.ContextMenuStrip;
            set => this.ContextMenuStrip = value;
        }

        public event EventHandler MainButtonClick;

        public MySplitButton()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ButtonDropDownList == null) {return;}

            if (ButtonDropDownList.Visible == false)
            {
                Point p = new Point()
                {
                    Y = 0 + MainButton.Height - 1,
                    X = 0 + 1,
                };
                ButtonDropDownList.Show(MainButton, p);
            }
            else
            {
                ButtonDropDownList.Hide();
            }
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            MainButtonClick?.Invoke(sender, e);
        }
    }
}
