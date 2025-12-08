namespace Desktop.Views
{
    partial class SesionesView
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
            dataGridSesionesView = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            comboTurnos = new ComboBox();
            checkBoxPagado = new CheckBox();
            txtNotas = new TextBox();
            numericHonorario = new NumericUpDown();
            btnSalir = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSesionesView).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericHonorario).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(15, 22, 41);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1850, 82);
            panel1.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(15, 22, 41);
            label1.Font = new Font("Times New Roman", 34.8F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(543, 9);
            label1.Name = "label1";
            label1.Size = new Size(234, 67);
            label1.TabIndex = 0;
            label1.Text = "Sesiones";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 612);
            tabControl1.TabIndex = 31;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(dataGridSesionesView);
            tabPageLista.Font = new Font("Segoe UI", 11F);
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
            btnBuscar.Location = new Point(980, 20);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(156, 49);
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
            label7.Location = new Point(25, 30);
            label7.Name = "label7";
            label7.Size = new Size(232, 37);
            label7.TabIndex = 27;
            label7.Text = "Buscar sesiones:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(263, 32);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Multiline = true;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(711, 37);
            txtFiltro.TabIndex = 25;
            // 
            // dataGridSesionesView
            // 
            dataGridSesionesView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridSesionesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSesionesView.Location = new Point(25, 77);
            dataGridSesionesView.Margin = new Padding(3, 4, 3, 4);
            dataGridSesionesView.Name = "dataGridSesionesView";
            dataGridSesionesView.RowHeadersWidth = 62;
            dataGridSesionesView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridSesionesView.Size = new Size(1111, 473);
            dataGridSesionesView.TabIndex = 23;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(comboTurnos);
            tabPageAgregarEditar.Controls.Add(checkBoxPagado);
            tabPageAgregarEditar.Controls.Add(txtNotas);
            tabPageAgregarEditar.Controls.Add(numericHonorario);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(1168, 579);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
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
            btnCancelar.Location = new Point(551, 431);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 49);
            btnCancelar.TabIndex = 50;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = false;
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
            btnGuardar.Location = new Point(333, 431);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(184, 49);
            btnGuardar.TabIndex = 51;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(15, 22, 41);
            label5.Font = new Font("Berlin Sans FB", 19.8000011F);
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(289, 293);
            label5.Name = "label5";
            label5.Size = new Size(106, 37);
            label5.TabIndex = 49;
            label5.Text = "Notas:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(15, 22, 41);
            label8.Font = new Font("Berlin Sans FB", 19.8000011F);
            label8.ForeColor = Color.Silver;
            label8.Location = new Point(289, 228);
            label8.Name = "label8";
            label8.Size = new Size(137, 37);
            label8.TabIndex = 48;
            label8.Text = "Pagado:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(15, 22, 41);
            label9.Font = new Font("Berlin Sans FB", 19.8000011F);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(289, 158);
            label9.Name = "label9";
            label9.Size = new Size(176, 37);
            label9.TabIndex = 47;
            label9.Text = "Honorarios:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(15, 22, 41);
            label10.Font = new Font("Berlin Sans FB", 19.8000011F);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(289, 90);
            label10.Name = "label10";
            label10.Size = new Size(106, 37);
            label10.TabIndex = 46;
            label10.Text = "Turno:";
            // 
            // comboTurnos
            // 
            comboTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTurnos.Font = new Font("Segoe UI", 12F);
            comboTurnos.FormattingEnabled = true;
            comboTurnos.Location = new Point(513, 91);
            comboTurnos.Margin = new Padding(3, 4, 3, 4);
            comboTurnos.Name = "comboTurnos";
            comboTurnos.Size = new Size(382, 36);
            comboTurnos.TabIndex = 44;
            // 
            // checkBoxPagado
            // 
            checkBoxPagado.AutoSize = true;
            checkBoxPagado.Font = new Font("Segoe UI", 12F);
            checkBoxPagado.Location = new Point(513, 248);
            checkBoxPagado.Name = "checkBoxPagado";
            checkBoxPagado.Size = new Size(18, 17);
            checkBoxPagado.TabIndex = 43;
            checkBoxPagado.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            txtNotas.Font = new Font("Segoe UI", 12F);
            txtNotas.Location = new Point(513, 293);
            txtNotas.Margin = new Padding(3, 4, 3, 4);
            txtNotas.Multiline = true;
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(382, 85);
            txtNotas.TabIndex = 42;
            // 
            // numericHonorario
            // 
            numericHonorario.DecimalPlaces = 2;
            numericHonorario.Font = new Font("Segoe UI", 12F);
            numericHonorario.Location = new Point(513, 161);
            numericHonorario.Margin = new Padding(3, 4, 3, 4);
            numericHonorario.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericHonorario.Name = "numericHonorario";
            numericHonorario.Size = new Size(240, 34);
            numericHonorario.TabIndex = 39;
            numericHonorario.TextAlign = HorizontalAlignment.Right;
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
            btnSalir.TabIndex = 35;
            btnSalir.Text = "&Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleRight;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
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
            btnEliminar.TabIndex = 34;
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
            btnEditar.TabIndex = 32;
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
            btnAgregar.TabIndex = 33;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // SesionesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 743);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SesionesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SesionesView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSesionesView).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericHonorario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl1;
        public TabPage tabPageLista;
        public TextBox txtFiltro;
        public DataGridView dataGridSesionesView;
        public TabPage tabPageAgregarEditar;
        public NumericUpDown numericHonorario;
        public TextBox txtNotas;
        public ComboBox comboTurnos;
        public CheckBox checkBoxPagado;
        private Label label7;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label label10;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}