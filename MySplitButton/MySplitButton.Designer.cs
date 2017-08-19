using System.ComponentModel;
using System.Windows.Forms;

namespace MySplitbutton
{
    partial class MySplitButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.MainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Image = global::MySplitButton.Properties.Resources.DropDownArrow;
            this.button2.Location = new System.Drawing.Point(95, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(17, 38);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // MainButton
            // 
            this.MainButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MainButton.Image = global::MySplitButton.Properties.Resources.TaskBarIcon1;
            this.MainButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainButton.Location = new System.Drawing.Point(0, 0);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(95, 38);
            this.MainButton.TabIndex = 0;
            this.MainButton.Text = "text";
            this.MainButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MainButton.UseVisualStyleBackColor = true;
            this.MainButton.Click += new System.EventHandler(this.MainButton_Click);
            // 
            // MySplitButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MainButton);
            this.Name = "MySplitButton";
            this.Size = new System.Drawing.Size(127, 38);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        public Button MainButton;
    }
}
