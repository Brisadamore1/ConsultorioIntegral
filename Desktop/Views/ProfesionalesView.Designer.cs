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
            txtFiltro = new TextBox();
            label7 = new Label();
            dataGridProfesionalesView = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtTelefono = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtEspecialidad = new TextBox();
            label8 = new Label();
            txtMatricula = new TextBox();
            label5 = new Label();
            txtProfesion = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            iconButtonSalir = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesionalesView).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 77);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(823, 508);
            tabControl1.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(dataGridProfesionalesView);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(815, 475);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(141, 20);
            txtFiltro.Margin = new Padding(3, 4, 3, 4);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(564, 27);
            txtFiltro.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 27);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 24;
            label7.Text = "Busar Profesional:";
            // 
            // dataGridProfesionalesView
            // 
            dataGridProfesionalesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProfesionalesView.Location = new Point(25, 64);
            dataGridProfesionalesView.Margin = new Padding(3, 4, 3, 4);
            dataGridProfesionalesView.Name = "dataGridProfesionalesView";
            dataGridProfesionalesView.RowHeadersWidth = 62;
            dataGridProfesionalesView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProfesionalesView.Size = new Size(764, 389);
            dataGridProfesionalesView.TabIndex = 23;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(txtTelefono);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(txtEmail);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(txtEspecialidad);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(txtMatricula);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(txtProfesion);
            tabPageAgregarEditar.Controls.Add(label4);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(815, 475);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(423, 368);
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
            btnGuardar.Location = new Point(232, 368);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(108, 67);
            btnGuardar.TabIndex = 32;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(295, 295);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(228, 27);
            txtTelefono.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 288);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 31;
            label3.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(295, 241);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(228, 27);
            txtEmail.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(185, 241);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 30;
            label6.Text = "Email:";
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(295, 196);
            txtEspecialidad.Margin = new Padding(3, 4, 3, 4);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(228, 27);
            txtEspecialidad.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(185, 196);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 26;
            label8.Text = "Especialidad:";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(295, 142);
            txtMatricula.Margin = new Padding(3, 4, 3, 4);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(228, 27);
            txtMatricula.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(183, 142);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 25;
            label5.Text = "Matrícula:";
            // 
            // txtProfesion
            // 
            txtProfesion.Location = new Point(295, 90);
            txtProfesion.Margin = new Padding(3, 4, 3, 4);
            txtProfesion.Name = "txtProfesion";
            txtProfesion.Size = new Size(228, 27);
            txtProfesion.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 90);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 24;
            label4.Text = "Profesión:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(295, 33);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(228, 27);
            txtNombre.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 37);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 20;
            label2.Text = "Nombre:";
            // 
            // iconButtonSalir
            // 
            iconButtonSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonSalir.BackColor = Color.Sienna;
            iconButtonSalir.ForeColor = Color.White;
            iconButtonSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            iconButtonSalir.IconColor = Color.White;
            iconButtonSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSalir.IconSize = 44;
            iconButtonSalir.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSalir.Location = new Point(859, 436);
            iconButtonSalir.Margin = new Padding(3, 4, 3, 4);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(123, 75);
            iconButtonSalir.TabIndex = 22;
            iconButtonSalir.Text = "&Salir";
            iconButtonSalir.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSalir.UseVisualStyleBackColor = false;
            iconButtonSalir.Click += iconButtonSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Sienna;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnEliminar.IconColor = Color.White;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 44;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(859, 356);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(123, 72);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eli&minar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.Sienna;
            btnEditar.ForeColor = Color.White;
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            btnEditar.IconColor = Color.White;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 45;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(859, 276);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(123, 72);
            btnEditar.TabIndex = 20;
            btnEditar.Text = "&Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.Sienna;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregar.IconColor = Color.White;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(859, 196);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(123, 72);
            btnAgregar.TabIndex = 19;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.Sienna;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.White;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(859, 116);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(123, 72);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "&Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Tan;
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 70);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Tan;
            label1.Font = new Font("Copperplate Gothic Bold", 28.2F);
            label1.ForeColor = Color.Sienna;
            label1.Location = new Point(272, 9);
            label1.Name = "label1";
            label1.Size = new Size(415, 53);
            label1.TabIndex = 0;
            label1.Text = "Profesionales";
            // 
            // ProfesionalesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 620);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(iconButtonSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnBuscar);
            Controls.Add(tabControl1);
            Name = "ProfesionalesView";
            Text = "ProfesionalesView";
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesionalesView).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FontAwesome.Sharp.IconButton iconButtonSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Panel panel1;
        private Label label1;
        public TextBox txtFiltro;
        private Label label7;
        public DataGridView dataGridProfesionalesView;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        public TextBox txtTelefono;
        private Label label3;
        public TextBox txtEmail;
        private Label label6;
        public TextBox txtEspecialidad;
        private Label label8;
        public TextBox txtMatricula;
        private Label label5;
        public TextBox txtProfesion;
        private Label label4;
        public TextBox txtNombre;
        private Label label2;
        public TabControl tabControl1;
        public TabPage tabPageLista;
        public TabPage tabPageAgregarEditar;
    }
}