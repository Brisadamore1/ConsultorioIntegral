namespace Desktop.Views
{
    partial class ProfesionalesView
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
            tabControl1 = new TabControl();
            tabPageLista = new TabPage();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            txtFiltro = new TextBox();
            dataGridProfesionalesView = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            checkBox = new CheckBox();
            label2 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label13 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtEspecialidad = new TextBox();
            txtMatricula = new TextBox();
            txtProfesion = new TextBox();
            txtNombre = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            btnSalir = new FontAwesome.Sharp.IconButton();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesionalesView).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1313, 612);
            tabControl1.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(dataGridProfesionalesView);
            tabPageLista.Font = new Font("Segoe UI", 11F);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(1305, 579);
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
            btnBuscar.Location = new Point(1117, 14);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(156, 52);
            btnBuscar.TabIndex = 29;
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
            label7.Size = new Size(306, 37);
            label7.TabIndex = 28;
            label7.Text = "Buscar profesionales:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(337, 29);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Multiline = true;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PlaceholderText = "Filtrar por profesional o profesión...";
            txtFiltro.Size = new Size(774, 37);
            txtFiltro.TabIndex = 25;
            // 
            // dataGridProfesionalesView
            // 
            dataGridProfesionalesView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridProfesionalesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProfesionalesView.Location = new Point(25, 79);
            dataGridProfesionalesView.Margin = new Padding(3, 4, 3, 4);
            dataGridProfesionalesView.Name = "dataGridProfesionalesView";
            dataGridProfesionalesView.RowHeadersWidth = 75;
            dataGridProfesionalesView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProfesionalesView.Size = new Size(1248, 473);
            dataGridProfesionalesView.TabIndex = 23;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(checkBox);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(label14);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label13);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(label11);
            tabPageAgregarEditar.Controls.Add(label12);
            tabPageAgregarEditar.Controls.Add(txtTelefono);
            tabPageAgregarEditar.Controls.Add(txtEmail);
            tabPageAgregarEditar.Controls.Add(txtEspecialidad);
            tabPageAgregarEditar.Controls.Add(txtMatricula);
            tabPageAgregarEditar.Controls.Add(txtProfesion);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(1305, 579);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // checkBox
            // 
            checkBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox.Location = new Point(634, 411);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(41, 37);
            checkBox.TabIndex = 49;
            checkBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(15, 22, 41);
            label2.Font = new Font("Berlin Sans FB", 19.8000011F);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(391, 411);
            label2.Name = "label2";
            label2.Size = new Size(118, 37);
            label2.TabIndex = 48;
            label2.Text = "Nuevo:";
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
            btnCancelar.Location = new Point(661, 500);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 49);
            btnCancelar.TabIndex = 38;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.FromArgb(15, 22, 41);
            label14.Font = new Font("Berlin Sans FB", 19.8000011F);
            label14.ForeColor = Color.Silver;
            label14.Location = new Point(391, 352);
            label14.Name = "label14";
            label14.Size = new Size(143, 37);
            label14.TabIndex = 47;
            label14.Text = "Teléfono:";
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
            btnGuardar.Location = new Point(445, 500);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(184, 49);
            btnGuardar.TabIndex = 39;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(15, 22, 41);
            label13.Font = new Font("Berlin Sans FB", 19.8000011F);
            label13.ForeColor = Color.Silver;
            label13.Location = new Point(391, 234);
            label13.Name = "label13";
            label13.Size = new Size(201, 37);
            label13.TabIndex = 46;
            label13.Text = "Especialidad:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(15, 22, 41);
            label9.Font = new Font("Berlin Sans FB", 19.8000011F);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(391, 294);
            label9.Name = "label9";
            label9.Size = new Size(107, 37);
            label9.TabIndex = 45;
            label9.Text = "Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(15, 22, 41);
            label10.Font = new Font("Berlin Sans FB", 19.8000011F);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(391, 174);
            label10.Name = "label10";
            label10.Size = new Size(160, 37);
            label10.TabIndex = 44;
            label10.Text = "Matrícula:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(15, 22, 41);
            label11.Font = new Font("Berlin Sans FB", 19.8000011F);
            label11.ForeColor = Color.Silver;
            label11.Location = new Point(391, 117);
            label11.Name = "label11";
            label11.Size = new Size(152, 37);
            label11.TabIndex = 43;
            label11.Text = "Profesión:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(15, 22, 41);
            label12.Font = new Font("Berlin Sans FB", 19.8000011F);
            label12.ForeColor = Color.Silver;
            label12.Location = new Point(391, 57);
            label12.Name = "label12";
            label12.Size = new Size(141, 37);
            label12.TabIndex = 42;
            label12.Text = "Nombre:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(634, 352);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Teléfono";
            txtTelefono.Size = new Size(260, 37);
            txtTelefono.TabIndex = 29;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(634, 294);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "tu@email.com";
            txtEmail.Size = new Size(260, 37);
            txtEmail.TabIndex = 28;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Font = new Font("Segoe UI", 12F);
            txtEspecialidad.Location = new Point(634, 234);
            txtEspecialidad.Margin = new Padding(3, 4, 3, 4);
            txtEspecialidad.Multiline = true;
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.PlaceholderText = "Especialidad (Opcional)";
            txtEspecialidad.Size = new Size(260, 37);
            txtEspecialidad.TabIndex = 27;
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Segoe UI", 12F);
            txtMatricula.Location = new Point(634, 174);
            txtMatricula.Margin = new Padding(3, 4, 3, 4);
            txtMatricula.Multiline = true;
            txtMatricula.Name = "txtMatricula";
            txtMatricula.PlaceholderText = "Matrícula";
            txtMatricula.Size = new Size(260, 37);
            txtMatricula.TabIndex = 23;
            // 
            // txtProfesion
            // 
            txtProfesion.Font = new Font("Segoe UI", 12F);
            txtProfesion.Location = new Point(634, 117);
            txtProfesion.Margin = new Padding(3, 4, 3, 4);
            txtProfesion.Multiline = true;
            txtProfesion.Name = "txtProfesion";
            txtProfesion.PlaceholderText = "Profesión";
            txtProfesion.Size = new Size(260, 37);
            txtProfesion.TabIndex = 22;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(634, 57);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre completo";
            txtNombre.Size = new Size(260, 37);
            txtNombre.TabIndex = 21;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(15, 22, 41);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(2001, 82);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(605, 9);
            label1.Name = "label1";
            label1.Size = new Size(356, 67);
            label1.TabIndex = 0;
            label1.Text = "Profesionales";
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
            btnEliminar.Location = new Point(1351, 397);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(176, 49);
            btnEliminar.TabIndex = 37;
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
            btnEditar.Location = new Point(1351, 328);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(176, 49);
            btnEditar.TabIndex = 35;
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
            btnAgregar.Location = new Point(1351, 256);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(176, 49);
            btnAgregar.TabIndex = 36;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click_1;
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
            btnSalir.Location = new Point(1351, 514);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(176, 49);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "&Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleRight;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // ProfesionalesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1559, 743);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProfesionalesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ProfesionalesView";
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesionalesView).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Panel panel1;
        private Label label1;
        public TextBox txtFiltro;
        public DataGridView dataGridProfesionalesView;
        public TextBox txtTelefono;
        public TextBox txtEmail;
        public TextBox txtEspecialidad;
        public TextBox txtMatricula;
        public TextBox txtProfesion;
        public TextBox txtNombre;
        public TabControl tabControl1;
        public TabPage tabPageLista;
        public TabPage tabPageAgregarEditar;
        private Label label7;
        private Label label14;
        private Label label13;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        public CheckBox checkBox;
        private Label label2;
    }
}