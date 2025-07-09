namespace CapaPresentacion
{
    partial class FormUsuarios
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
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvUsuarios = new DataGridView();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            panelDatos = new Panel();
            lblContraseña = new Label();
            lblUsuario = new Label();
            lblRegistro = new Label();
            pictureBox1 = new PictureBox();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(128, 128, 255);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(12, 380);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(105, 380);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.BackgroundColor = Color.FromArgb(30, 30, 45);
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(314, 51);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(576, 336);
            dgvUsuarios.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(116, 308);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(116, 337);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 4;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.FromArgb(30, 30, 45);
            panelDatos.Controls.Add(btnCancelar);
            panelDatos.Controls.Add(lblContraseña);
            panelDatos.Controls.Add(lblUsuario);
            panelDatos.Controls.Add(lblRegistro);
            panelDatos.Controls.Add(pictureBox1);
            panelDatos.Controls.Add(txtContraseña);
            panelDatos.Controls.Add(btnEliminar);
            panelDatos.Controls.Add(txtUsuario);
            panelDatos.Controls.Add(btnGuardar);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 0);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(296, 427);
            panelDatos.TabIndex = 5;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.ForeColor = Color.White;
            lblContraseña.Location = new Point(20, 345);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(70, 15);
            lblContraseña.TabIndex = 8;
            lblContraseña.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(20, 316);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Usuario:";
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegistro.ForeColor = Color.White;
            lblRegistro.Location = new Point(51, 242);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(196, 22);
            lblRegistro.TabIndex = 6;
            lblRegistro.Text = "REGISTRO USUARIOS";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.persona_trabajando_html_en_computadora;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(296, 219);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.CornflowerBlue;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(197, 380);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(91, 23);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 427);
            Controls.Add(panelDatos);
            Controls.Add(dgvUsuarios);
            Name = "FormUsuarios";
            Text = "Usuarios";
            Load += FormUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dgvUsuarios;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Panel panelDatos;
        private PictureBox pictureBox1;
        private Label lblContraseña;
        private Label lblUsuario;
        private Label lblRegistro;
        private Button btnCancelar;
    }
}