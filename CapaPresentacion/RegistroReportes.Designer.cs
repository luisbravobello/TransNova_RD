namespace CapaPresentacion
{
    partial class RegistroReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartReportes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvReportes = new DataGridView();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblEstado = new Label();
            lblReportes = new Label();
            pictureBox1 = new PictureBox();
            btnCancelar = new Button();
            cmbEstado = new ComboBox();
            btnGenerarReporte = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)chartReportes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // chartReportes
            // 
            chartArea1.Name = "ChartArea1";
            chartReportes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartReportes.Legends.Add(legend1);
            chartReportes.Location = new Point(544, 313);
            chartReportes.Name = "chartReportes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartReportes.Series.Add(series1);
            chartReportes.Size = new Size(543, 271);
            chartReportes.TabIndex = 0;
            chartReportes.Text = "chart1";
            // 
            // dgvReportes
            // 
            dgvReportes.BackgroundColor = Color.FromArgb(30, 30, 45);
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvReportes.GridColor = Color.White;
            dgvReportes.Location = new Point(424, 12);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.Size = new Size(833, 295);
            dgvReportes.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 45);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(lblReportes);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(cmbEstado);
            panel1.Controls.Add(btnGenerarReporte);
            panel1.Controls.Add(dtpHasta);
            panel1.Controls.Add(dtpDesde);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 614);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 383);
            label2.Name = "label2";
            label2.Size = new Size(87, 17);
            label2.TabIndex = 9;
            label2.Text = "Fechas final:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 349);
            label1.Name = "label1";
            label1.Size = new Size(115, 17);
            label1.TabIndex = 8;
            label1.Text = "Fechas de inicio:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.White;
            lblEstado.Location = new Point(12, 320);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(164, 17);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "Estado de encomienda:";
            // 
            // lblReportes
            // 
            lblReportes.AutoSize = true;
            lblReportes.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportes.ForeColor = SystemColors.ButtonHighlight;
            lblReportes.Location = new Point(102, 274);
            lblReportes.Name = "lblReportes";
            lblReportes.Size = new Size(190, 24);
            lblReportes.TabIndex = 6;
            lblReportes.Text = "Registro Reportes:";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.mujer_corporativa_empresaria_sosteniendo_portapapeles_con_documentos_en_la_oficina_sonriendo_la_camara_fondo_blanco;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(388, 261);
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
            btnCancelar.Location = new Point(182, 451);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(182, 320);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 3;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.CadetBlue;
            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Location = new Point(21, 451);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(137, 23);
            btnGenerarReporte.TabIndex = 2;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(182, 378);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(182, 349);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 0;
            // 
            // RegistroReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 614);
            Controls.Add(panel1);
            Controls.Add(dgvReportes);
            Controls.Add(chartReportes);
            Name = "RegistroReportes";
            Text = "REGISTRO REPORTES";
            Load += FormReportes_Load;
            ((System.ComponentModel.ISupportInitialize)chartReportes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartReportes;
        private DataGridView dgvReportes;
        private Panel panel1;
        private ComboBox cmbEstado;
        private Button btnGenerarReporte;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private Label lblReportes;
        private Label label1;
        private Label lblEstado;
        private Label label2;
    }
}