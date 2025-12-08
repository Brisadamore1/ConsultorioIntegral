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
            panelTitulo = new Panel();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            Principal = new FontAwesome.Sharp.IconMenuItem();
            itemMenuProfesionales = new FontAwesome.Sharp.IconMenuItem();
            itemMenuPacientes = new FontAwesome.Sharp.IconMenuItem();
            contactosDeEmergenciaToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            itemMenuTurnos = new FontAwesome.Sharp.IconMenuItem();
            sesionesToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            reportesToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            pacientesToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            itemMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            panelTitulo.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(15, 22, 41);
            panelTitulo.Controls.Add(label1);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.ForeColor = Color.OldLace;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Margin = new Padding(3, 4, 3, 4);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1729, 82);
            panelTitulo.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(692, 9);
            label1.Name = "label1";
            label1.Size = new Size(531, 67);
            label1.TabIndex = 0;
            label1.Text = "Consultorio Integral";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(15, 22, 41);
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Principal, itemMenuProfesionales, itemMenuPacientes, contactosDeEmergenciaToolStripMenuItem, itemMenuTurnos, sesionesToolStripMenuItem, reportesToolStripMenuItem, iconMenuItem2 });
            menuStrip1.Location = new Point(9, 97);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(14, 4, 0, 4);
            menuStrip1.Size = new Size(1811, 53);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Principal
            // 
            Principal.Font = new Font("Berlin Sans FB", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Principal.ForeColor = Color.Silver;
            Principal.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            Principal.IconColor = Color.Silver;
            Principal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Principal.IconSize = 40;
            Principal.ImageScaling = ToolStripItemImageScaling.None;
            Principal.Name = "Principal";
            Principal.Size = new Size(197, 45);
            Principal.Text = "Principal";
            // 
            // itemMenuProfesionales
            // 
            itemMenuProfesionales.Font = new Font("Berlin Sans FB", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemMenuProfesionales.ForeColor = Color.Silver;
            itemMenuProfesionales.IconChar = FontAwesome.Sharp.IconChar.HandHoldingMedical;
            itemMenuProfesionales.IconColor = Color.Silver;
            itemMenuProfesionales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            itemMenuProfesionales.IconSize = 40;
            itemMenuProfesionales.ImageScaling = ToolStripItemImageScaling.None;
            itemMenuProfesionales.Name = "itemMenuProfesionales";
            itemMenuProfesionales.Size = new Size(252, 45);
            itemMenuProfesionales.Text = "Profesionales";
            itemMenuProfesionales.Click += profesionalesToolStripMenuItem_Click;
            // 
            // itemMenuPacientes
            // 
            itemMenuPacientes.Font = new Font("Berlin Sans FB", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemMenuPacientes.ForeColor = Color.Silver;
            itemMenuPacientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            itemMenuPacientes.IconColor = Color.Silver;
            itemMenuPacientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            itemMenuPacientes.IconSize = 41;
            itemMenuPacientes.ImageScaling = ToolStripItemImageScaling.None;
            itemMenuPacientes.Name = "itemMenuPacientes";
            itemMenuPacientes.Size = new Size(206, 45);
            itemMenuPacientes.Text = "Pacientes";
            itemMenuPacientes.Click += itemMenuPacientes_Click;
            // 
            // contactosDeEmergenciaToolStripMenuItem
            // 
            contactosDeEmergenciaToolStripMenuItem.BackColor = Color.FromArgb(15, 22, 41);
            contactosDeEmergenciaToolStripMenuItem.Font = new Font("Berlin Sans FB", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contactosDeEmergenciaToolStripMenuItem.ForeColor = Color.Silver;
            contactosDeEmergenciaToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.PhoneVolume;
            contactosDeEmergenciaToolStripMenuItem.IconColor = Color.Silver;
            contactosDeEmergenciaToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            contactosDeEmergenciaToolStripMenuItem.IconSize = 38;
            contactosDeEmergenciaToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            contactosDeEmergenciaToolStripMenuItem.Name = "contactosDeEmergenciaToolStripMenuItem";
            contactosDeEmergenciaToolStripMenuItem.Size = new Size(381, 45);
            contactosDeEmergenciaToolStripMenuItem.Text = "Contactos de Emergencia";
            contactosDeEmergenciaToolStripMenuItem.Click += contactosDeEmergenciaToolStripMenuItem_Click;
            // 
            // itemMenuTurnos
            // 
            itemMenuTurnos.Font = new Font("Berlin Sans FB", 18F);
            itemMenuTurnos.ForeColor = Color.Silver;
            itemMenuTurnos.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            itemMenuTurnos.IconColor = Color.Silver;
            itemMenuTurnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            itemMenuTurnos.IconSize = 38;
            itemMenuTurnos.ImageScaling = ToolStripItemImageScaling.None;
            itemMenuTurnos.Name = "itemMenuTurnos";
            itemMenuTurnos.Size = new Size(149, 45);
            itemMenuTurnos.Text = "Turnos";
            itemMenuTurnos.Click += itemMenuTurnos_Click;
            // 
            // sesionesToolStripMenuItem
            // 
            sesionesToolStripMenuItem.Font = new Font("Berlin Sans FB", 18F);
            sesionesToolStripMenuItem.ForeColor = Color.Silver;
            sesionesToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            sesionesToolStripMenuItem.IconColor = Color.Silver;
            sesionesToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sesionesToolStripMenuItem.IconSize = 38;
            sesionesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sesionesToolStripMenuItem.Name = "sesionesToolStripMenuItem";
            sesionesToolStripMenuItem.Size = new Size(164, 45);
            sesionesToolStripMenuItem.Text = "Sesiones";
            sesionesToolStripMenuItem.Click += sesionesToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pacientesToolStripMenuItem });
            reportesToolStripMenuItem.Font = new Font("Berlin Sans FB", 18F);
            reportesToolStripMenuItem.ForeColor = Color.Silver;
            reportesToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            reportesToolStripMenuItem.IconColor = Color.Silver;
            reportesToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            reportesToolStripMenuItem.IconSize = 38;
            reportesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(174, 45);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.BackColor = Color.FromArgb(15, 22, 41);
            pacientesToolStripMenuItem.ForeColor = Color.Silver;
            pacientesToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.Users;
            pacientesToolStripMenuItem.IconColor = Color.Silver;
            pacientesToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            pacientesToolStripMenuItem.IconSize = 38;
            pacientesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(242, 44);
            pacientesToolStripMenuItem.Text = "Pacientes";
            pacientesToolStripMenuItem.Click += pacientesToolStripMenuItem_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { itemMenuSalirDelSistema });
            iconMenuItem2.Font = new Font("Berlin Sans FB", 18F);
            iconMenuItem2.ForeColor = Color.Silver;
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            iconMenuItem2.IconColor = Color.Silver;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.IconSize = 40;
            iconMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(122, 45);
            iconMenuItem2.Text = "Salir";
            // 
            // itemMenuSalirDelSistema
            // 
            itemMenuSalirDelSistema.BackColor = Color.FromArgb(15, 22, 41);
            itemMenuSalirDelSistema.ForeColor = Color.Silver;
            itemMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            itemMenuSalirDelSistema.IconColor = Color.Silver;
            itemMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            itemMenuSalirDelSistema.IconSize = 40;
            itemMenuSalirDelSistema.ImageScaling = ToolStripItemImageScaling.None;
            itemMenuSalirDelSistema.Name = "itemMenuSalirDelSistema";
            itemMenuSalirDelSistema.Size = new Size(319, 46);
            itemMenuSalirDelSistema.Text = "Salir del sistema";
            itemMenuSalirDelSistema.Click += itemMenuSalirDelSistema_Click;
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(32, 19);
            iconMenuItem3.Text = "iconMenuItem3";
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(17F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1729, 652);
            Controls.Add(panelTitulo);
            Controls.Add(menuStrip1);
            Font = new Font("Mongolian Baiti", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Sienna;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(7, 4, 7, 4);
            Name = "MenuPrincipalView";
            Text = "Home";
            WindowState = FormWindowState.Maximized;
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTitulo;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem Principal;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem itemMenuSalirDelSistema;
        private Label label1;
        private FontAwesome.Sharp.IconMenuItem itemMenuProfesionales;
        private FontAwesome.Sharp.IconMenuItem contactosDeEmergenciaToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem itemMenuTurnos;
        private FontAwesome.Sharp.IconMenuItem itemMenuPacientes;
        private FontAwesome.Sharp.IconMenuItem sesionesToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem reportesToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem pacientesToolStripMenuItem;
    }
}
