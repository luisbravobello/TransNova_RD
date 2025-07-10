namespace CapaPresentacion
{
    partial class Transportes
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
            grpInformacion = new GroupBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            txtRuta = new TextBox();
            lblDestinoFinal = new Label();
            txtCapacidad = new NumericUpDown();
            label2 = new Label();
            timePickerHoraInicio = new DateTimePicker();
            label3 = new Label();
            cmbLugarInicio = new ComboBox();
            lblCapacidad = new Label();
            cmbDestinoFinal = new ComboBox();
            lblRuta = new Label();
            btncancelar = new Button();
            btnGuardar = new Button();
            lblTitulo = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            grpMetro = new GroupBox();
            txtLineaMetro = new TextBox();
            txtVagonesMetro = new NumericUpDown();
            txtEstacionesMetro = new NumericUpDown();
            label8 = new Label();
            lblEstaciones = new Label();
            grpTaxiBus = new GroupBox();
            txtTarifa = new TextBox();
            label4 = new Label();
            txtPlaca = new TextBox();
            txtConductor = new TextBox();
            lblPlaca = new Label();
            label7 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1.SuspendLayout();
            grpInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpMetro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtVagonesMetro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEstacionesMetro).BeginInit();
            grpTaxiBus.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 45);
            panel1.Controls.Add(grpInformacion);
            panel1.Controls.Add(btncancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 507);
            panel1.TabIndex = 0;
            // 
            // grpInformacion
            // 
            grpInformacion.Controls.Add(lblTipo);
            grpInformacion.Controls.Add(cmbTipo);
            grpInformacion.Controls.Add(txtRuta);
            grpInformacion.Controls.Add(lblDestinoFinal);
            grpInformacion.Controls.Add(txtCapacidad);
            grpInformacion.Controls.Add(label2);
            grpInformacion.Controls.Add(timePickerHoraInicio);
            grpInformacion.Controls.Add(label3);
            grpInformacion.Controls.Add(cmbLugarInicio);
            grpInformacion.Controls.Add(lblCapacidad);
            grpInformacion.Controls.Add(cmbDestinoFinal);
            grpInformacion.Controls.Add(lblRuta);
            grpInformacion.ForeColor = Color.White;
            grpInformacion.Location = new Point(3, 185);
            grpInformacion.Name = "grpInformacion";
            grpInformacion.Size = new Size(400, 247);
            grpInformacion.TabIndex = 3;
            grpInformacion.TabStop = false;
            grpInformacion.Text = "Datos:";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.FlatStyle = FlatStyle.Flat;
            lblTipo.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipo.ForeColor = Color.LightGray;
            lblTipo.Location = new Point(17, 19);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(171, 17);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Seleccione un transporte:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(194, 17);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(179, 23);
            cmbTipo.TabIndex = 3;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(194, 51);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(179, 23);
            txtRuta.TabIndex = 17;
            // 
            // lblDestinoFinal
            // 
            lblDestinoFinal.AutoSize = true;
            lblDestinoFinal.FlatStyle = FlatStyle.Flat;
            lblDestinoFinal.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDestinoFinal.ForeColor = Color.LightGray;
            lblDestinoFinal.Location = new Point(17, 206);
            lblDestinoFinal.Name = "lblDestinoFinal";
            lblDestinoFinal.Size = new Size(93, 17);
            lblDestinoFinal.TabIndex = 4;
            lblDestinoFinal.Text = "Destino Final:";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(194, 91);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(179, 23);
            txtCapacidad.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(17, 169);
            label2.Name = "label2";
            label2.Size = new Size(107, 17);
            label2.TabIndex = 5;
            label2.Text = "Lugar de inicio:";
            // 
            // timePickerHoraInicio
            // 
            timePickerHoraInicio.Location = new Point(194, 129);
            timePickerHoraInicio.Name = "timePickerHoraInicio";
            timePickerHoraInicio.Size = new Size(200, 23);
            timePickerHoraInicio.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(17, 135);
            label3.Name = "label3";
            label3.Size = new Size(81, 17);
            label3.TabIndex = 6;
            label3.Text = "Hora Inicio:";
            // 
            // cmbLugarInicio
            // 
            cmbLugarInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLugarInicio.FormattingEnabled = true;
            cmbLugarInicio.Location = new Point(194, 163);
            cmbLugarInicio.Name = "cmbLugarInicio";
            cmbLugarInicio.Size = new Size(179, 23);
            cmbLugarInicio.TabIndex = 10;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.FlatStyle = FlatStyle.Flat;
            lblCapacidad.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacidad.ForeColor = Color.LightGray;
            lblCapacidad.Location = new Point(17, 97);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(88, 17);
            lblCapacidad.TabIndex = 7;
            lblCapacidad.Text = "Capacidad:";
            // 
            // cmbDestinoFinal
            // 
            cmbDestinoFinal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestinoFinal.FormattingEnabled = true;
            cmbDestinoFinal.Location = new Point(194, 200);
            cmbDestinoFinal.Name = "cmbDestinoFinal";
            cmbDestinoFinal.Size = new Size(179, 23);
            cmbDestinoFinal.TabIndex = 9;
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.FlatStyle = FlatStyle.Flat;
            lblRuta.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRuta.ForeColor = Color.LightGray;
            lblRuta.Location = new Point(17, 57);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(42, 17);
            lblRuta.TabIndex = 8;
            lblRuta.Text = "Ruta:";
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.LightSkyBlue;
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.Location = new Point(197, 455);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(75, 23);
            btncancelar.TabIndex = 20;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(128, 128, 255);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(77, 455);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Silver;
            lblTitulo.Location = new Point(77, 153);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(199, 24);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Registro Transporte";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.Transportes;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(411, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(46, 17);
            label1.TabIndex = 13;
            label1.Text = "Linea:";
            // 
            // grpMetro
            // 
            grpMetro.Controls.Add(txtLineaMetro);
            grpMetro.Controls.Add(txtVagonesMetro);
            grpMetro.Controls.Add(txtEstacionesMetro);
            grpMetro.Controls.Add(label8);
            grpMetro.Controls.Add(lblEstaciones);
            grpMetro.Controls.Add(label1);
            grpMetro.Location = new Point(461, 80);
            grpMetro.Name = "grpMetro";
            grpMetro.Size = new Size(314, 122);
            grpMetro.TabIndex = 1;
            grpMetro.TabStop = false;
            grpMetro.Text = "Metro";
            // 
            // txtLineaMetro
            // 
            txtLineaMetro.Location = new Point(129, 13);
            txtLineaMetro.Name = "txtLineaMetro";
            txtLineaMetro.Size = new Size(179, 23);
            txtLineaMetro.TabIndex = 18;
            // 
            // txtVagonesMetro
            // 
            txtVagonesMetro.Location = new Point(129, 79);
            txtVagonesMetro.Name = "txtVagonesMetro";
            txtVagonesMetro.Size = new Size(179, 23);
            txtVagonesMetro.TabIndex = 17;
            // 
            // txtEstacionesMetro
            // 
            txtEstacionesMetro.Location = new Point(129, 50);
            txtEstacionesMetro.Name = "txtEstacionesMetro";
            txtEstacionesMetro.Size = new Size(179, 23);
            txtEstacionesMetro.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(6, 83);
            label8.Name = "label8";
            label8.Size = new Size(69, 17);
            label8.TabIndex = 15;
            label8.Text = "Vagones:";
            // 
            // lblEstaciones
            // 
            lblEstaciones.AutoSize = true;
            lblEstaciones.FlatStyle = FlatStyle.Flat;
            lblEstaciones.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstaciones.ForeColor = Color.Black;
            lblEstaciones.Location = new Point(6, 48);
            lblEstaciones.Name = "lblEstaciones";
            lblEstaciones.Size = new Size(79, 17);
            lblEstaciones.TabIndex = 14;
            lblEstaciones.Text = "Estaciones:";
            // 
            // grpTaxiBus
            // 
            grpTaxiBus.Controls.Add(txtTarifa);
            grpTaxiBus.Controls.Add(label4);
            grpTaxiBus.Controls.Add(txtPlaca);
            grpTaxiBus.Controls.Add(txtConductor);
            grpTaxiBus.Controls.Add(lblPlaca);
            grpTaxiBus.Controls.Add(label7);
            grpTaxiBus.Location = new Point(455, 264);
            grpTaxiBus.Name = "grpTaxiBus";
            grpTaxiBus.Size = new Size(363, 144);
            grpTaxiBus.TabIndex = 2;
            grpTaxiBus.TabStop = false;
            grpTaxiBus.Text = "Taxi / Bus";
            // 
            // txtTarifa
            // 
            txtTarifa.Location = new Point(173, 97);
            txtTarifa.Name = "txtTarifa";
            txtTarifa.Size = new Size(179, 23);
            txtTarifa.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 99);
            label4.Name = "label4";
            label4.Size = new Size(46, 17);
            label4.TabIndex = 21;
            label4.Text = "Tarifa:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(173, 63);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(179, 23);
            txtPlaca.TabIndex = 20;
            // 
            // txtConductor
            // 
            txtConductor.Location = new Point(173, 29);
            txtConductor.Name = "txtConductor";
            txtConductor.Size = new Size(179, 23);
            txtConductor.TabIndex = 19;
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.FlatStyle = FlatStyle.Flat;
            lblPlaca.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlaca.ForeColor = Color.Black;
            lblPlaca.Location = new Point(6, 63);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(49, 17);
            lblPlaca.TabIndex = 15;
            lblPlaca.Text = "Placa:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(6, 31);
            label7.Name = "label7";
            label7.Size = new Size(161, 17);
            label7.TabIndex = 14;
            label7.Text = "Nombre del conductor:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Transportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 507);
            Controls.Add(grpTaxiBus);
            Controls.Add(grpMetro);
            Controls.Add(panel1);
            Name = "Transportes";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transportes";
            Load += FormNuevo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpInformacion.ResumeLayout(false);
            grpInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpMetro.ResumeLayout(false);
            grpMetro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtVagonesMetro).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEstacionesMetro).EndInit();
            grpTaxiBus.ResumeLayout(false);
            grpTaxiBus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitulo;
        private PictureBox pictureBox1;
        private ComboBox cmbTipo;
        private Label lblTipo;
        private ComboBox cmbLugarInicio;
        private ComboBox cmbDestinoFinal;
        private Label lblRuta;
        private Label lblCapacidad;
        private Label label3;
        private Label label2;
        private Label lblDestinoFinal;
        private Label label1;
        private NumericUpDown txtCapacidad;
        private DateTimePicker timePickerHoraInicio;
        private TextBox txtRuta;
        private GroupBox grpMetro;
        private TextBox txtLineaMetro;
        private NumericUpDown txtVagonesMetro;
        private NumericUpDown txtEstacionesMetro;
        private Label label8;
        private Label lblEstaciones;
        private GroupBox grpTaxiBus;
        private TextBox txtConductor;
        private Label lblPlaca;
        private Label label7;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btncancelar;
        private Button btnGuardar;
        private TextBox txtPlaca;
        private TextBox txtTarifa;
        private Label label4;
        private GroupBox grpInformacion;
    }
}