namespace Clipster
{
    partial class Clipster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clipster));
            this.Options_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.mySplitButton1 = new MySplitbutton.MySplitButton();
            this.ScreenClipMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.ScreenClipMenu.SuspendLayout();
            this.OptionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options_Button
            // 
            this.Options_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Options_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Options_Button.Image = global::Clipster.Properties.Resources.toolset_ubL_icon;
            this.Options_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Options_Button.Location = new System.Drawing.Point(241, 3);
            this.Options_Button.Name = "Options_Button";
            this.Options_Button.Size = new System.Drawing.Size(115, 38);
            this.Options_Button.TabIndex = 4;
            this.Options_Button.Text = "Options  ";
            this.Options_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_Button.UseVisualStyleBackColor = true;
            this.Options_Button.Click += new System.EventHandler(this.Options_Button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.Options_Button, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mySplitButton1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 44);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Cancel_Button.Image = global::Clipster.Properties.Resources.Cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(122, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(113, 38);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "Cancel  ";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // mySplitButton1
            // 
            this.mySplitButton1.ButtonDropDownList = this.ScreenClipMenu;
            this.mySplitButton1.ButtonText = "New  ";
            this.mySplitButton1.ContextMenuStrip = this.ScreenClipMenu;
            this.mySplitButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitButton1.Location = new System.Drawing.Point(3, 3);
            this.mySplitButton1.Name = "mySplitButton1";
            this.mySplitButton1.Size = new System.Drawing.Size(113, 38);
            this.mySplitButton1.TabIndex = 6;
            this.mySplitButton1.MainButtonClick += new System.EventHandler(this.MySplitButton1_MainButtonClick);
            // 
            // ScreenClipMenu
            // 
            this.ScreenClipMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToClipboardToolStripMenuItem});
            this.ScreenClipMenu.Name = "ScreenClipMenu";
            this.ScreenClipMenu.Size = new System.Drawing.Size(170, 26);
            // 
            // saveToClipboardToolStripMenuItem
            // 
            this.saveToClipboardToolStripMenuItem.Checked = true;
            this.saveToClipboardToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveToClipboardToolStripMenuItem.Name = "saveToClipboardToolStripMenuItem";
            this.saveToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToClipboardToolStripMenuItem.Text = "Save To Clipboard";
            this.saveToClipboardToolStripMenuItem.Click += new System.EventHandler(this.SaveToClipboardToolStripMenuItem_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Clipster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 47);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clipster";
            this.Text = "Clipster";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ScreenClipMenu.ResumeLayout(false);
            this.OptionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Options_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.ContextMenuStrip OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ScreenClipMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem;
        private MySplitbutton.MySplitButton mySplitButton1;
    }
}

