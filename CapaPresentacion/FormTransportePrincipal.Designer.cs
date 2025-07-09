namespace CapaPresentacion
{
    partial class FormTransportePrincipal
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
            panelMenuLateral = new Panel();
            btnUsuarios = new Button();
            btnReportes = new Button();
            label1 = new Label();
            lblusuario = new Label();
            btnCerrar = new Button();
            pictureBox1 = new PictureBox();
            btnEncomiendas = new Button();
            btneditar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            cmbTipo = new ComboBox();
            dgvTransportes = new DataGridView();
            txtBusqueda = new TextBox();
            lblBuscar = new Label();
            lblInformacionTransportes = new Label();
            panelMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransportes).BeginInit();
            SuspendLayout();
            // 
            // panelMenuLateral
            // 
            panelMenuLateral.BackColor = Color.FromArgb(30, 30, 45);
            panelMenuLateral.Controls.Add(btnUsuarios);
            panelMenuLateral.Controls.Add(btnReportes);
            panelMenuLateral.Controls.Add(label1);
            panelMenuLateral.Controls.Add(lblusuario);
            panelMenuLateral.Controls.Add(btnCerrar);
            panelMenuLateral.Controls.Add(pictureBox1);
            panelMenuLateral.Controls.Add(btnEncomiendas);
            panelMenuLateral.Controls.Add(btneditar);
            panelMenuLateral.Controls.Add(btnEliminar);
            panelMenuLateral.Controls.Add(btnNuevo);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.Location = new Point(0, 0);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(222, 607);
            panelMenuLateral.TabIndex = 0;
            panelMenuLateral.Paint += panelMenuLateral_Paint;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.CadetBlue;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Century Gothic", 9F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(23, 311);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(184, 23);
            btnUsuarios.TabIndex = 10;
            btnUsuarios.Text = "USUARIOS";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.BurlyWood;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Century Gothic", 9F);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(23, 340);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(184, 23);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "REPORTES";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGray;
            label1.Location = new Point(23, 101);
            label1.Name = "label1";
            label1.Size = new Size(177, 30);
            label1.TabIndex = 8;
            label1.Text = "TransNova RD";
            // 
            // lblusuario
            // 
            lblusuario.AutoSize = true;
            lblusuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblusuario.ForeColor = Color.White;
            lblusuario.Location = new Point(3, 144);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(54, 17);
            lblusuario.TabIndex = 7;
            lblusuario.Text = "Usuario:";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Century Gothic", 9F);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(23, 572);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(184, 23);
            btnCerrar.TabIndex = 6;
            btnCerrar.Text = "Cerrar Sesion";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.logop_removebg_preview;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // btnEncomiendas
            // 
            btnEncomiendas.BackColor = Color.FromArgb(255, 128, 255);
            btnEncomiendas.FlatStyle = FlatStyle.Flat;
            btnEncomiendas.Font = new Font("Century Gothic", 9F);
            btnEncomiendas.ForeColor = Color.White;
            btnEncomiendas.Location = new Point(23, 282);
            btnEncomiendas.Name = "btnEncomiendas";
            btnEncomiendas.Size = new Size(184, 23);
            btnEncomiendas.TabIndex = 3;
            btnEncomiendas.Text = "ENCOMIENDAS";
            btnEncomiendas.UseVisualStyleBackColor = false;
            btnEncomiendas.Click += btnEncomiendas_Click;
            // 
            // btneditar
            // 
            btneditar.BackColor = Color.FromArgb(192, 192, 255);
            btneditar.FlatStyle = FlatStyle.Flat;
            btneditar.Font = new Font("Century Gothic", 9F);
            btneditar.ForeColor = Color.White;
            btneditar.Location = new Point(23, 253);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(184, 23);
            btneditar.TabIndex = 2;
            btneditar.Text = "MODIFICAR";
            btneditar.UseVisualStyleBackColor = false;
            btneditar.Click += btneditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Century Gothic", 9F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(23, 221);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(184, 26);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(128, 128, 255);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Century Gothic", 9F);
            btnNuevo.ForeColor = SystemColors.ButtonHighlight;
            btnNuevo.Location = new Point(23, 192);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(184, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // cmbTipo
            // 
            cmbTipo.BackColor = Color.White;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.ForeColor = Color.Black;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(1281, 40);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 23);
            cmbTipo.TabIndex = 1;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged_1;
            // 
            // dgvTransportes
            // 
            dgvTransportes.AllowUserToAddRows = false;
            dgvTransportes.AllowUserToDeleteRows = false;
            dgvTransportes.BackgroundColor = Color.FromArgb(30, 30, 45);
            dgvTransportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransportes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTransportes.GridColor = SystemColors.WindowText;
            dgvTransportes.Location = new Point(242, 75);
            dgvTransportes.Name = "dgvTransportes";
            dgvTransportes.ReadOnly = true;
            dgvTransportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransportes.Size = new Size(1184, 492);
            dgvTransportes.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = SystemColors.ActiveCaption;
            txtBusqueda.Location = new Point(299, 46);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(412, 23);
            txtBusqueda.TabIndex = 2;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(228, 46);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(65, 21);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar:";
            // 
            // lblInformacionTransportes
            // 
            lblInformacionTransportes.AutoSize = true;
            lblInformacionTransportes.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInformacionTransportes.Location = new Point(1074, 42);
            lblInformacionTransportes.Name = "lblInformacionTransportes";
            lblInformacionTransportes.Size = new Size(201, 21);
            lblInformacionTransportes.TabIndex = 4;
            lblInformacionTransportes.Text = "Informacion Transportes:";
            // 
            // FormTransportePrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 607);
            Controls.Add(lblInformacionTransportes);
            Controls.Add(lblBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cmbTipo);
            Controls.Add(dgvTransportes);
            Controls.Add(panelMenuLateral);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormTransportePrincipal";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTransportePrincipal";
            Load += FormTransportePrincipal_Load;
            panelMenuLateral.ResumeLayout(false);
            panelMenuLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMenuLateral;
        private Button btnEncomiendas;
        private Button btneditar;
        private Button btnEliminar;
        private Button btnNuevo;
        private PictureBox pictureBox1;
        private DataGridView dgvTransportes;
        private ComboBox cmbTipo;
        private Button btnCerrar;
        private Label lblusuario;
        private TextBox txtBusqueda;
        private Label lblBuscar;
        private Label lblInformacionTransportes;
        private Label label1;
        private Button btnReportes;
        private Button btnUsuarios;
    }
}