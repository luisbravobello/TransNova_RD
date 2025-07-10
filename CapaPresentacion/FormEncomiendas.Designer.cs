namespace CapaPresentacion
{
    partial class FormEncomiendas
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
            dgvEncomiendas = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            grpDatos = new GroupBox();
            cmbNuevoEstado = new ComboBox();
            lblEstado = new Label();
            llbEncomiendas = new Label();
            cmbEstado = new ComboBox();
            dateTimePickerFechaEstimada = new DateTimePicker();
            numPeso = new NumericUpDown();
            txtDireccionEntrega = new TextBox();
            txtDestinatario = new TextBox();
            txtRemitente = new TextBox();
            cmbPlaca = new ComboBox();
            cmbTipoTransporte = new ComboBox();
            txtCodigoSeguimiento = new TextBox();
            lblestadopaquete = new Label();
            lblFechaEstimada = new Label();
            lblPeso = new Label();
            lblDireccionEntrega = new Label();
            lblDestinatario = new Label();
            lblRemitente = new Label();
            label3 = new Label();
            lblPlaca = new Label();
            Codigo = new Label();
            btnGuardar = new Button();
            btnMostrarEncomiendas = new Button();
            btnCancelar = new Button();
            btnActualizarEstado = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEncomiendas).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            SuspendLayout();
            // 
            // dgvEncomiendas
            // 
            dgvEncomiendas.AllowUserToAddRows = false;
            dgvEncomiendas.AllowUserToDeleteRows = false;
            dgvEncomiendas.BackgroundColor = Color.FromArgb(30, 30, 45);
            dgvEncomiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEncomiendas.Location = new Point(434, 33);
            dgvEncomiendas.Name = "dgvEncomiendas";
            dgvEncomiendas.ReadOnly = true;
            dgvEncomiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEncomiendas.Size = new Size(915, 600);
            dgvEncomiendas.TabIndex = 0;
            dgvEncomiendas.CellFormatting += dgvEncomiendas_CellFormatting;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 45);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(grpDatos);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(418, 721);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.repartidora_joven_con_cajas;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(418, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(llbEncomiendas);
            grpDatos.Controls.Add(cmbEstado);
            grpDatos.Controls.Add(dateTimePickerFechaEstimada);
            grpDatos.Controls.Add(numPeso);
            grpDatos.Controls.Add(txtDireccionEntrega);
            grpDatos.Controls.Add(txtDestinatario);
            grpDatos.Controls.Add(txtRemitente);
            grpDatos.Controls.Add(cmbPlaca);
            grpDatos.Controls.Add(cmbTipoTransporte);
            grpDatos.Controls.Add(txtCodigoSeguimiento);
            grpDatos.Controls.Add(lblestadopaquete);
            grpDatos.Controls.Add(lblFechaEstimada);
            grpDatos.Controls.Add(lblPeso);
            grpDatos.Controls.Add(lblDireccionEntrega);
            grpDatos.Controls.Add(lblDestinatario);
            grpDatos.Controls.Add(lblRemitente);
            grpDatos.Controls.Add(label3);
            grpDatos.Controls.Add(lblPlaca);
            grpDatos.Controls.Add(Codigo);
            grpDatos.ForeColor = Color.White;
            grpDatos.Location = new Point(12, 306);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(403, 405);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos:";
            // 
            // cmbNuevoEstado
            // 
            cmbNuevoEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNuevoEstado.FormattingEnabled = true;
            cmbNuevoEstado.Location = new Point(1132, 665);
            cmbNuevoEstado.Name = "cmbNuevoEstado";
            cmbNuevoEstado.Size = new Size(157, 23);
            cmbNuevoEstado.TabIndex = 20;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Century Gothic", 9F);
            lblEstado.ForeColor = Color.Black;
            lblEstado.Location = new Point(1012, 668);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(114, 17);
            lblEstado.TabIndex = 19;
            lblEstado.Text = "Actualizar Estado:";
            // 
            // llbEncomiendas
            // 
            llbEncomiendas.AutoSize = true;
            llbEncomiendas.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llbEncomiendas.ForeColor = Color.White;
            llbEncomiendas.Location = new Point(129, -3);
            llbEncomiendas.Name = "llbEncomiendas";
            llbEncomiendas.Size = new Size(150, 22);
            llbEncomiendas.TabIndex = 18;
            llbEncomiendas.Text = "ENCOMIENDAS";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(187, 356);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 17;
            // 
            // dateTimePickerFechaEstimada
            // 
            dateTimePickerFechaEstimada.Location = new Point(186, 318);
            dateTimePickerFechaEstimada.Name = "dateTimePickerFechaEstimada";
            dateTimePickerFechaEstimada.Size = new Size(200, 23);
            dateTimePickerFechaEstimada.TabIndex = 16;
            // 
            // numPeso
            // 
            numPeso.Location = new Point(186, 276);
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(199, 23);
            numPeso.TabIndex = 15;
            // 
            // txtDireccionEntrega
            // 
            txtDireccionEntrega.Location = new Point(186, 230);
            txtDireccionEntrega.Name = "txtDireccionEntrega";
            txtDireccionEntrega.Size = new Size(199, 23);
            txtDireccionEntrega.TabIndex = 14;
            // 
            // txtDestinatario
            // 
            txtDestinatario.Location = new Point(186, 189);
            txtDestinatario.Name = "txtDestinatario";
            txtDestinatario.Size = new Size(199, 23);
            txtDestinatario.TabIndex = 13;
            // 
            // txtRemitente
            // 
            txtRemitente.Location = new Point(186, 154);
            txtRemitente.Name = "txtRemitente";
            txtRemitente.Size = new Size(199, 23);
            txtRemitente.TabIndex = 12;
            // 
            // cmbPlaca
            // 
            cmbPlaca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlaca.FormattingEnabled = true;
            cmbPlaca.Location = new Point(186, 122);
            cmbPlaca.Name = "cmbPlaca";
            cmbPlaca.Size = new Size(199, 23);
            cmbPlaca.TabIndex = 11;
            // 
            // cmbTipoTransporte
            // 
            cmbTipoTransporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoTransporte.FormattingEnabled = true;
            cmbTipoTransporte.Location = new Point(186, 76);
            cmbTipoTransporte.Name = "cmbTipoTransporte";
            cmbTipoTransporte.Size = new Size(199, 23);
            cmbTipoTransporte.TabIndex = 10;
            cmbTipoTransporte.SelectedIndexChanged += cmbTipoTransporte_SelectedIndexChanged;
            // 
            // txtCodigoSeguimiento
            // 
            txtCodigoSeguimiento.Location = new Point(186, 42);
            txtCodigoSeguimiento.Name = "txtCodigoSeguimiento";
            txtCodigoSeguimiento.Size = new Size(199, 23);
            txtCodigoSeguimiento.TabIndex = 9;
            // 
            // lblestadopaquete
            // 
            lblestadopaquete.AutoSize = true;
            lblestadopaquete.Font = new Font("Century Gothic", 9F);
            lblestadopaquete.ForeColor = Color.White;
            lblestadopaquete.Location = new Point(4, 365);
            lblestadopaquete.Name = "lblestadopaquete";
            lblestadopaquete.Size = new Size(128, 17);
            lblestadopaquete.TabIndex = 8;
            lblestadopaquete.Text = "Estado del paquete:";
            // 
            // lblFechaEstimada
            // 
            lblFechaEstimada.AutoSize = true;
            lblFechaEstimada.Font = new Font("Century Gothic", 9F);
            lblFechaEstimada.ForeColor = Color.White;
            lblFechaEstimada.Location = new Point(5, 324);
            lblFechaEstimada.Name = "lblFechaEstimada";
            lblFechaEstimada.Size = new Size(107, 17);
            lblFechaEstimada.TabIndex = 7;
            lblFechaEstimada.Text = "Fecha estimada:";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Century Gothic", 9F);
            lblPeso.ForeColor = Color.White;
            lblPeso.Location = new Point(3, 277);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(116, 17);
            lblPeso.TabIndex = 6;
            lblPeso.Text = "Peso del paquete:";
            // 
            // lblDireccionEntrega
            // 
            lblDireccionEntrega.AutoSize = true;
            lblDireccionEntrega.Font = new Font("Century Gothic", 9F);
            lblDireccionEntrega.ForeColor = Color.White;
            lblDireccionEntrega.Location = new Point(1, 232);
            lblDireccionEntrega.Name = "lblDireccionEntrega";
            lblDireccionEntrega.Size = new Size(151, 17);
            lblDireccionEntrega.TabIndex = 5;
            lblDireccionEntrega.Text = "Direccion de la Entrega:";
            // 
            // lblDestinatario
            // 
            lblDestinatario.AutoSize = true;
            lblDestinatario.Font = new Font("Century Gothic", 9F);
            lblDestinatario.ForeColor = Color.White;
            lblDestinatario.Location = new Point(3, 189);
            lblDestinatario.Name = "lblDestinatario";
            lblDestinatario.Size = new Size(84, 17);
            lblDestinatario.TabIndex = 4;
            lblDestinatario.Text = "Destinatario:";
            // 
            // lblRemitente
            // 
            lblRemitente.AutoSize = true;
            lblRemitente.Font = new Font("Century Gothic", 9F);
            lblRemitente.ForeColor = Color.White;
            lblRemitente.Location = new Point(5, 150);
            lblRemitente.Name = "lblRemitente";
            lblRemitente.Size = new Size(70, 17);
            lblRemitente.TabIndex = 3;
            lblRemitente.Text = "Remitente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(119, 17);
            label3.TabIndex = 2;
            label3.Text = "Tipo de Transporte:";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Century Gothic", 9F);
            lblPlaca.ForeColor = Color.White;
            lblPlaca.Location = new Point(5, 111);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(45, 17);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa:";
            // 
            // Codigo
            // 
            Codigo.AutoSize = true;
            Codigo.Font = new Font("Century Gothic", 9F);
            Codigo.ForeColor = Color.White;
            Codigo.Location = new Point(4, 42);
            Codigo.Name = "Codigo";
            Codigo.Size = new Size(147, 17);
            Codigo.TabIndex = 0;
            Codigo.Text = "Codigo de seguimiento";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(128, 128, 255);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(457, 665);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnMostrarEncomiendas
            // 
            btnMostrarEncomiendas.BackColor = Color.CadetBlue;
            btnMostrarEncomiendas.FlatStyle = FlatStyle.Flat;
            btnMostrarEncomiendas.Location = new Point(563, 665);
            btnMostrarEncomiendas.Name = "btnMostrarEncomiendas";
            btnMostrarEncomiendas.Size = new Size(149, 23);
            btnMostrarEncomiendas.TabIndex = 3;
            btnMostrarEncomiendas.Text = "Mostrar Encomiendas";
            btnMostrarEncomiendas.UseVisualStyleBackColor = false;
            btnMostrarEncomiendas.Click += btnMostrarEncomiendas_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.CornflowerBlue;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(908, 665);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnActualizarEstado
            // 
            btnActualizarEstado.FlatStyle = FlatStyle.Flat;
            btnActualizarEstado.Location = new Point(744, 665);
            btnActualizarEstado.Name = "btnActualizarEstado";
            btnActualizarEstado.Size = new Size(110, 23);
            btnActualizarEstado.TabIndex = 5;
            btnActualizarEstado.Text = "Actualizar Estado";
            btnActualizarEstado.UseVisualStyleBackColor = true;
            btnActualizarEstado.Click += btnActualizarEstado_Click;
            // 
            // FormEncomiendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 721);
            Controls.Add(cmbNuevoEstado);
            Controls.Add(btnActualizarEstado);
            Controls.Add(lblEstado);
            Controls.Add(btnCancelar);
            Controls.Add(btnMostrarEncomiendas);
            Controls.Add(btnGuardar);
            Controls.Add(panel1);
            Controls.Add(dgvEncomiendas);
            Name = "FormEncomiendas";
            Text = "Encomiendas";
            Load += FormEncomiendas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEncomiendas).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEncomiendas;
        private Panel panel1;
        private GroupBox grpDatos;
        private NumericUpDown numPeso;
        private TextBox txtDireccionEntrega;
        private TextBox txtDestinatario;
        private TextBox txtRemitente;
        private ComboBox cmbPlaca;
        private ComboBox cmbTipoTransporte;
        private TextBox txtCodigoSeguimiento;
        private Label lblestadopaquete;
        private Label lblFechaEstimada;
        private Label lblPeso;
        private Label lblDireccionEntrega;
        private Label lblDestinatario;
        private Label lblRemitente;
        private Label label3;
        private Label lblPlaca;
        private Label Codigo;
        private ComboBox cmbEstado;
        private DateTimePicker dateTimePickerFechaEstimada;
        private Button btnGuardar;
        private Button btnMostrarEncomiendas;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private Label llbEncomiendas;
        private Button btnActualizarEstado;
        private ComboBox cmbNuevoEstado;
        private Label lblEstado;
    }
}