namespace Desktop.Views
{
    partial class ContactosEmergenciaView
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
            panel1 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPageLista = new TabPage();
            label7 = new Label();
            txtFiltro = new TextBox();
            dataGridContactosEmergenciaView = new DataGridView();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            tabPageAgregarEditar = new TabPage();
            comboPacientes = new ComboBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtRelacion = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            iconButtonSalir = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridContactosEmergenciaView).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(15, 22, 41);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1787, 82);
            panel1.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(406, 9);
            label1.Name = "label1";
            label1.Size = new Size(658, 67);
            label1.TabIndex = 0;
            label1.Text = "Contactos de Emergencia";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 612);
            tabControl1.TabIndex = 4;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(dataGridContactosEmergenciaView);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(1168, 579);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(15, 22, 41);
            label7.Font = new Font("Berlin Sans FB", 19.8000011F);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(25, 30);
            label7.Name = "label7";
            label7.Size = new Size(260, 37);
            label7.TabIndex = 26;
            label7.Text = "Buscar contactos:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(291, 32);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Multiline = true;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(682, 35);
            txtFiltro.TabIndex = 25;
            // 
            // dataGridContactosEmergenciaView
            // 
            dataGridContactosEmergenciaView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridContactosEmergenciaView.Location = new Point(25, 77);
            dataGridContactosEmergenciaView.Margin = new Padding(3, 4, 3, 4);
            dataGridContactosEmergenciaView.Name = "dataGridContactosEmergenciaView";
            dataGridContactosEmergenciaView.RowHeadersWidth = 62;
            dataGridContactosEmergenciaView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridContactosEmergenciaView.Size = new Size(1111, 473);
            dataGridContactosEmergenciaView.TabIndex = 23;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(15, 22, 41);
            btnBuscar.Font = new Font("Berlin Sans FB", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.Silver;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Silver;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 45;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(980, 18);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(156, 49);
            btnBuscar.TabIndex = 23;
            btnBuscar.Text = "&Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(comboPacientes);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(txtTelefono);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(txtRelacion);
            tabPageAgregarEditar.Controls.Add(label4);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(1168, 579);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // comboPacientes
            // 
            comboPacientes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPacientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboPacientes.FormattingEnabled = true;
            comboPacientes.Location = new Point(603, 219);
            comboPacientes.Margin = new Padding(3, 4, 3, 4);
            comboPacientes.Name = "comboPacientes";
            comboPacientes.Size = new Size(241, 36);
            comboPacientes.TabIndex = 35;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(64, 64, 64);
            btnCancelar.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnCancelar.ForeColor = Color.Silver;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Silver;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 45;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(630, 410);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 49);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(41, 23, 61);
            btnGuardar.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnGuardar.ForeColor = Color.Silver;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Silver;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 45;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(413, 410);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(184, 49);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(15, 22, 41);
            label3.Font = new Font("Berlin Sans FB", 19.8000011F);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(390, 280);
            label3.Name = "label3";
            label3.Size = new Size(143, 37);
            label3.TabIndex = 31;
            label3.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(603, 280);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(241, 37);
            txtTelefono.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(15, 22, 41);
            label6.Font = new Font("Berlin Sans FB", 19.8000011F);
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(390, 215);
            label6.Name = "label6";
            label6.Size = new Size(148, 37);
            label6.TabIndex = 30;
            label6.Text = "Paciente:";
            // 
            // txtRelacion
            // 
            txtRelacion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRelacion.Location = new Point(603, 145);
            txtRelacion.Margin = new Padding(3, 4, 3, 4);
            txtRelacion.Multiline = true;
            txtRelacion.Name = "txtRelacion";
            txtRelacion.Size = new Size(241, 37);
            txtRelacion.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(15, 22, 41);
            label4.Font = new Font("Berlin Sans FB", 19.8000011F);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(390, 145);
            label4.Name = "label4";
            label4.Size = new Size(144, 37);
            label4.TabIndex = 24;
            label4.Text = "Relación:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(603, 77);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(241, 37);
            txtNombre.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(15, 22, 41);
            label2.Font = new Font("Berlin Sans FB", 19.8000011F);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(390, 77);
            label2.Name = "label2";
            label2.Size = new Size(141, 37);
            label2.TabIndex = 20;
            label2.Text = "Nombre:";
            // 
            // iconButtonSalir
            // 
            iconButtonSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonSalir.BackColor = Color.FromArgb(64, 64, 64);
            iconButtonSalir.Font = new Font("Berlin Sans FB", 19.8000011F);
            iconButtonSalir.ForeColor = Color.White;
            iconButtonSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            iconButtonSalir.IconColor = Color.White;
            iconButtonSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSalir.IconSize = 47;
            iconButtonSalir.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSalir.Location = new Point(1214, 514);
            iconButtonSalir.Margin = new Padding(3, 4, 3, 4);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(176, 49);
            iconButtonSalir.TabIndex = 27;
            iconButtonSalir.Text = "&Salir";
            iconButtonSalir.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSalir.UseVisualStyleBackColor = false;
            iconButtonSalir.Click += iconButtonSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(15, 22, 41);
            btnEliminar.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnEliminar.ForeColor = Color.Silver;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnEliminar.IconColor = Color.Silver;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 43;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(1214, 397);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(176, 49);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eli&minar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.FromArgb(15, 22, 41);
            btnEditar.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnEditar.ForeColor = Color.Silver;
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEditar.IconColor = Color.Silver;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 45;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(1214, 328);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(176, 49);
            btnEditar.TabIndex = 24;
            btnEditar.Text = "&Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(15, 22, 41);
            btnAgregar.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnAgregar.ForeColor = Color.Silver;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnAgregar.IconColor = Color.Silver;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.IconSize = 45;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(1214, 256);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(176, 49);
            btnAgregar.TabIndex = 24;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // ContactosEmergenciaView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 739);
            Controls.Add(iconButtonSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ContactosEmergenciaView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ContactosEmergenciaView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridContactosEmergenciaView).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl1;
        public TabPage tabPageLista;
        public TextBox txtFiltro;
        public DataGridView dataGridContactosEmergenciaView;
        public TabPage tabPageAgregarEditar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label3;
        public TextBox txtTelefono;
        private Label label6;
        public TextBox txtRelacion;
        private Label label8;
        public TextBox txtMatricula;
        private Label label5;
        public TextBox txtProfesion;
        private Label label4;
        public TextBox txtNombre;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButtonSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        public ComboBox comboPacientes;
        private Label label7;
    }
}