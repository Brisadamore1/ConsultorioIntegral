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
            itemMenuProfesionales = new ToolStripMenuItem();
            itemMenuPacientes = new ToolStripMenuItem();
            contactosDeEmergenciaToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            sesiónToolStripMenuItem = new ToolStripMenuItem();
            menuSalirDelSistema = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Principal, itemMenuProfesionales, itemMenuPacientes, contactosDeEmergenciaToolStripMenuItem, turnosToolStripMenuItem, sesiónToolStripMenuItem, menuSalirDelSistema });
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
            // itemMenuProfesionales
            // 
            itemMenuProfesionales.Name = "itemMenuProfesionales";
            itemMenuProfesionales.Size = new Size(111, 39);
            itemMenuProfesionales.Text = "Profesionales";
            itemMenuProfesionales.Click += profesionalesToolStripMenuItem_Click;
            // 
            // itemMenuPacientes
            // 
            itemMenuPacientes.Name = "itemMenuPacientes";
            itemMenuPacientes.Size = new Size(84, 39);
            itemMenuPacientes.Text = "Pacientes";
            itemMenuPacientes.Click += itemMenuPacientes_Click;
            // 
            // contactosDeEmergenciaToolStripMenuItem
            // 
            contactosDeEmergenciaToolStripMenuItem.Name = "contactosDeEmergenciaToolStripMenuItem";
            contactosDeEmergenciaToolStripMenuItem.Size = new Size(192, 39);
            contactosDeEmergenciaToolStripMenuItem.Text = "Contactos de Emergencia";
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(67, 39);
            turnosToolStripMenuItem.Text = "Turnos";
            // 
            // sesiónToolStripMenuItem
            // 
            sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            sesiónToolStripMenuItem.Size = new Size(66, 39);
            sesiónToolStripMenuItem.Text = "Sesión";
            // 
            // menuSalirDelSistema
            // 
            menuSalirDelSistema.Name = "menuSalirDelSistema";
            menuSalirDelSistema.Size = new Size(52, 39);
            menuSalirDelSistema.Text = "Salir";
            menuSalirDelSistema.Click += menuSalirDelSistema_Click;
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
        private ToolStripMenuItem itemMenuProfesionales;
        private ToolStripMenuItem itemMenuPacientes;
        private ToolStripMenuItem contactosDeEmergenciaToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem sesiónToolStripMenuItem;
        private ToolStripMenuItem menuSalirDelSistema;
    }
}
