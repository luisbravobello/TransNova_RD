namespace CapaPresentacion
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtusuario = new TextBox();
            txtcontraseña = new TextBox();
            btnlogin = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtusuario
            // 
            txtusuario.BackColor = Color.FromArgb(30, 30, 45);
            txtusuario.BorderStyle = BorderStyle.None;
            txtusuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusuario.ForeColor = Color.White;
            txtusuario.Location = new Point(290, 73);
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(357, 20);
            txtusuario.TabIndex = 1;
            txtusuario.Text = "USUARIO";
            txtusuario.MouseEnter += txtusuario_MouseEnter;
            txtusuario.MouseLeave += txtusuario_MouseLeave;
            // 
            // txtcontraseña
            // 
            txtcontraseña.BackColor = Color.FromArgb(30, 30, 45);
            txtcontraseña.BorderStyle = BorderStyle.None;
            txtcontraseña.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcontraseña.ForeColor = Color.White;
            txtcontraseña.Location = new Point(290, 132);
            txtcontraseña.Name = "txtcontraseña";
            txtcontraseña.Size = new Size(357, 20);
            txtcontraseña.TabIndex = 2;
            txtcontraseña.Text = "CONTRASEÑA";
            txtcontraseña.MouseEnter += txtcontraseña_MouseEnter;
            txtcontraseña.MouseLeave += txtcontraseña_MouseLeave;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.FromArgb(30, 30, 45);
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(290, 190);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(357, 30);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "ACCEDER";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.logop_removebg_preview;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 248);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(408, 19);
            label2.Name = "label2";
            label2.Size = new Size(107, 36);
            label2.TabIndex = 5;
            label2.Text = "LOGIN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(28, 190);
            label3.Name = "label3";
            label3.Size = new Size(194, 33);
            label3.TabIndex = 6;
            label3.Text = "TransNova RD";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(682, 248);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(btnlogin);
            Controls.Add(txtcontraseña);
            Controls.Add(txtusuario);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += Form1_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtusuario;
        private TextBox txtcontraseña;
        private Button btnlogin;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
    }
}
