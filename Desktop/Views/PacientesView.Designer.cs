namespace Desktop.Views
{
    partial class PacientesView
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
            tabPageAgregarEditar = new TabPage();
            label14 = new Label();
            label13 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            dateTimeFecha = new DateTimePicker();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            comboProfesionales = new ComboBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            tabPageLista = new TabPage();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            txtFiltro = new TextBox();
            dataGridPacientesView = new DataGridView();
            tabControl1 = new TabControl();
            btnSalir = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabPageAgregarEditar.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPacientesView).BeginInit();
            tabControl1.SuspendLayout();
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
            panel1.Size = new Size(1851, 82);
            panel1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(561, 9);
            label1.Name = "label1";
            label1.Size = new Size(261, 67);
            label1.TabIndex = 0;
            label1.Text = "Pacientes";
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(label14);
            tabPageAgregarEditar.Controls.Add(label13);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(label11);
            tabPageAgregarEditar.Controls.Add(label12);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(dateTimeFecha);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(comboProfesionales);
            tabPageAgregarEditar.Controls.Add(txtTelefono);
            tabPageAgregarEditar.Controls.Add(txtEmail);
            tabPageAgregarEditar.Controls.Add(txtDni);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(1168, 579);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.FromArgb(15, 22, 41);
            label14.Font = new Font("Berlin Sans FB", 19.8000011F);
            label14.ForeColor = Color.Silver;
            label14.Location = new Point(306, 351);
            label14.Name = "label14";
            label14.Size = new Size(179, 37);
            label14.TabIndex = 41;
            label14.Text = "Profesional:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(15, 22, 41);
            label13.Font = new Font("Berlin Sans FB", 19.8000011F);
            label13.ForeColor = Color.Silver;
            label13.Location = new Point(306, 233);
            label13.Name = "label13";
            label13.Size = new Size(107, 37);
            label13.TabIndex = 40;
            label13.Text = "Email:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(15, 22, 41);
            label9.Font = new Font("Berlin Sans FB", 19.8000011F);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(306, 293);
            label9.Name = "label9";
            label9.Size = new Size(143, 37);
            label9.TabIndex = 39;
            label9.Text = "Teléfono:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(15, 22, 41);
            label10.Font = new Font("Berlin Sans FB", 19.8000011F);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(306, 173);
            label10.Name = "label10";
            label10.Size = new Size(284, 37);
            label10.TabIndex = 38;
            label10.Text = "Fecha Nacimiento:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(15, 22, 41);
            label11.Font = new Font("Berlin Sans FB", 19.8000011F);
            label11.ForeColor = Color.Silver;
            label11.Location = new Point(306, 116);
            label11.Name = "label11";
            label11.Size = new Size(73, 37);
            label11.TabIndex = 37;
            label11.Text = "Dni:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(15, 22, 41);
            label12.Font = new Font("Berlin Sans FB", 19.8000011F);
            label12.ForeColor = Color.Silver;
            label12.Location = new Point(306, 56);
            label12.Name = "label12";
            label12.Size = new Size(141, 37);
            label12.TabIndex = 36;
            label12.Text = "Nombre:";
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
            btnCancelar.Location = new Point(619, 475);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 49);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // dateTimeFecha
            // 
            dateTimeFecha.Font = new Font("Segoe UI", 12F);
            dateTimeFecha.Format = DateTimePickerFormat.Short;
            dateTimeFecha.Location = new Point(633, 179);
            dateTimeFecha.Name = "dateTimeFecha";
            dateTimeFecha.Size = new Size(176, 34);
            dateTimeFecha.TabIndex = 0;
            dateTimeFecha.Value = new DateTime(2025, 11, 23, 14, 57, 33, 0);
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
            btnGuardar.Location = new Point(402, 475);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(184, 49);
            btnGuardar.TabIndex = 35;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // comboProfesionales
            // 
            comboProfesionales.DropDownStyle = ComboBoxStyle.DropDownList;
            comboProfesionales.Font = new Font("Segoe UI", 12F);
            comboProfesionales.FormattingEnabled = true;
            comboProfesionales.Location = new Point(633, 351);
            comboProfesionales.Margin = new Padding(3, 4, 3, 4);
            comboProfesionales.Name = "comboProfesionales";
            comboProfesionales.Size = new Size(260, 36);
            comboProfesionales.TabIndex = 34;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(633, 293);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Teléfono";
            txtTelefono.Size = new Size(260, 37);
            txtTelefono.TabIndex = 28;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(633, 233);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "tu@email.com (Opcional)";
            txtEmail.Size = new Size(260, 37);
            txtEmail.TabIndex = 27;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 12F);
            txtDni.Location = new Point(633, 119);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Multiline = true;
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "Dni";
            txtDni.Size = new Size(260, 37);
            txtDni.TabIndex = 22;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(633, 56);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre completo";
            txtNombre.Size = new Size(260, 37);
            txtNombre.TabIndex = 21;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(dataGridPacientesView);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(1168, 579);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
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
            btnBuscar.Location = new Point(980, 14);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(156, 52);
            btnBuscar.TabIndex = 28;
            btnBuscar.Text = "&Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(15, 22, 41);
            label7.Font = new Font("Berlin Sans FB", 19.8000011F);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(25, 29);
            label7.Name = "label7";
            label7.Size = new Size(259, 37);
            label7.TabIndex = 27;
            label7.Text = "Buscar pacientes:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(290, 29);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Multiline = true;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(684, 37);
            txtFiltro.TabIndex = 25;
            // 
            // dataGridPacientesView
            // 
            dataGridPacientesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPacientesView.Location = new Point(25, 79);
            dataGridPacientesView.Margin = new Padding(3, 4, 3, 4);
            dataGridPacientesView.Name = "dataGridPacientesView";
            dataGridPacientesView.RowHeadersWidth = 62;
            dataGridPacientesView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPacientesView.Size = new Size(1111, 473);
            dataGridPacientesView.TabIndex = 23;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 612);
            tabControl1.TabIndex = 29;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(64, 64, 64);
            btnSalir.Font = new Font("Berlin Sans FB", 19.8000011F);
            btnSalir.ForeColor = Color.White;
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnSalir.IconColor = Color.White;
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 47;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(1214, 514);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(176, 49);
            btnSalir.TabIndex = 30;
            btnSalir.Text = "&Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleRight;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
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
            btnEliminar.TabIndex = 33;
            btnEliminar.Text = "Eli&minar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
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
            btnEditar.TabIndex = 31;
            btnEditar.Text = "&Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click_1;
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
            btnAgregar.TabIndex = 32;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // PacientesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 743);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnSalir);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PacientesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PacientesView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPacientesView).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        public TabPage tabPageAgregarEditar;
        public DateTimePicker dateTimeFecha;
        public ComboBox comboProfesionales;
        public TextBox txtTelefono;
        public TextBox txtEmail;
        public TextBox txtDni;
        public TextBox txtNombre;
        public TabPage tabPageLista;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Label label7;
        public TextBox txtFiltro;
        public DataGridView dataGridPacientesView;
        public TabControl tabControl1;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label14;
        private Label label13;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}