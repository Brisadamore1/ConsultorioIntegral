namespace Desktop.Views
{
    partial class TurnosView
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
            btnBuscar = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            txtFiltro = new TextBox();
            dataGridTurnosView = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            comboEstado = new ComboBox();
            comboPacientes = new ComboBox();
            label2 = new Label();
            dateTimeFecha = new DateTimePicker();
            comboProfesionales = new ComboBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label6 = new Label();
            txtDuracion = new TextBox();
            label8 = new Label();
            label5 = new Label();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            btnSalir = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTurnosView).BeginInit();
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
            panel1.Size = new Size(1912, 82);
            panel1.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(540, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 67);
            label1.TabIndex = 0;
            label1.Text = "Turnos";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 612);
            tabControl1.TabIndex = 30;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(dataGridTurnosView);
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
            btnBuscar.TabIndex = 29;
            btnBuscar.Text = "&Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(15, 22, 41);
            label7.Font = new Font("Berlin Sans FB", 19.8000011F);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(25, 29);
            label7.Name = "label7";
            label7.Size = new Size(214, 37);
            label7.TabIndex = 28;
            label7.Text = "Buscar turnos:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(245, 29);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Multiline = true;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(729, 37);
            txtFiltro.TabIndex = 25;
            // 
            // dataGridTurnosView
            // 
            dataGridTurnosView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTurnosView.Location = new Point(25, 79);
            dataGridTurnosView.Margin = new Padding(3, 4, 3, 4);
            dataGridTurnosView.Name = "dataGridTurnosView";
            dataGridTurnosView.RowHeadersWidth = 62;
            dataGridTurnosView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTurnosView.Size = new Size(1111, 473);
            dataGridTurnosView.TabIndex = 23;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(comboEstado);
            tabPageAgregarEditar.Controls.Add(comboPacientes);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Controls.Add(dateTimeFecha);
            tabPageAgregarEditar.Controls.Add(comboProfesionales);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(txtDuracion);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(1168, 579);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // comboEstado
            // 
            comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstado.FormattingEnabled = true;
            comboEstado.Location = new Point(514, 292);
            comboEstado.Margin = new Padding(3, 4, 3, 4);
            comboEstado.Name = "comboEstado";
            comboEstado.Size = new Size(228, 28);
            comboEstado.TabIndex = 37;
            // 
            // comboPacientes
            // 
            comboPacientes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPacientes.FormattingEnabled = true;
            comboPacientes.Location = new Point(514, 65);
            comboPacientes.Margin = new Padding(3, 4, 3, 4);
            comboPacientes.Name = "comboPacientes";
            comboPacientes.Size = new Size(228, 28);
            comboPacientes.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 71);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 35;
            label2.Text = "Paciente:";
            // 
            // dateTimeFecha
            // 
            dateTimeFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimeFecha.Format = DateTimePickerFormat.Custom;
            dateTimeFecha.Location = new Point(514, 168);
            dateTimeFecha.Name = "dateTimeFecha";
            dateTimeFecha.Size = new Size(214, 27);
            dateTimeFecha.TabIndex = 0;
            dateTimeFecha.Value = new DateTime(2025, 11, 23, 14, 57, 33, 0);
            // 
            // comboProfesionales
            // 
            comboProfesionales.DropDownStyle = ComboBoxStyle.DropDownList;
            comboProfesionales.FormattingEnabled = true;
            comboProfesionales.Location = new Point(514, 111);
            comboProfesionales.Margin = new Padding(3, 4, 3, 4);
            comboProfesionales.Name = "comboProfesionales";
            comboProfesionales.Size = new Size(228, 28);
            comboProfesionales.TabIndex = 34;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(617, 385);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 67);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(426, 385);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(108, 67);
            btnGuardar.TabIndex = 32;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(399, 300);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 31;
            label3.Text = "Estado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(407, 231);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 30;
            label6.Text = "Duración:";
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(514, 231);
            txtDuracion.Margin = new Padding(3, 4, 3, 4);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(228, 27);
            txtDuracion.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(389, 117);
            label8.Name = "label8";
            label8.Size = new Size(86, 20);
            label8.TabIndex = 26;
            label8.Text = "Profesional:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 171);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 25;
            label5.Text = "Fecha y Hora:";
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
            btnEditar.Location = new Point(1214, 328);
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
            btnAgregar.Location = new Point(1214, 256);
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
            btnSalir.Location = new Point(1214, 514);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(176, 49);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "&Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleRight;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // TurnosView
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
            Name = "TurnosView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TurnosView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTurnosView).EndInit();
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
        public DataGridView dataGridTurnosView;
        public TabPage tabPageAgregarEditar;
        public DateTimePicker dateTimeFecha;
        public ComboBox comboProfesionales;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label3;
        private Label label6;
        public TextBox txtDuracion;
        private Label label8;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnSalir;
        public ComboBox comboPacientes;
        private Label label2;
        public ComboBox comboEstado;
        private Label label7;
    }
}