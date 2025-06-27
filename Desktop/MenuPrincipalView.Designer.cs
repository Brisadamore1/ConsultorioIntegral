namespace Desktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            Principal = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Principal });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(14, 4, 0, 4);
            menuStrip1.Size = new Size(1700, 47);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Principal
            // 
            Principal.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Principal.ForeColor = Color.Black;
            Principal.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            Principal.IconColor = Color.Sienna;
            Principal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Principal.IconSize = 35;
            Principal.ImageScaling = ToolStripItemImageScaling.None;
            Principal.Name = "Principal";
            Principal.Size = new Size(142, 39);
            Principal.Text = "Principal";
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(17F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1700, 652);
            Controls.Add(menuStrip1);
            Font = new Font("Mongolian Baiti", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Sienna;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(7, 4, 7, 4);
            Name = "MenuPrincipalView";
            Text = "Consultorio Integral";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem Principal;
    }
}
