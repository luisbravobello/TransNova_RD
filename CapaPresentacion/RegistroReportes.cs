using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class RegistroReportes : Form
    {

        private GestorEncomienda gestorEncomienda;
        public RegistroReportes()
        {
            InitializeComponent();
            gestorEncomienda = new GestorEncomienda();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Crear una nueva área de gráfico
            chartReportes.ChartAreas.Clear();  // Elimina las áreas existentes
            chartReportes.ChartAreas.Add(new ChartArea("Area"));

            // Configurar la leyenda (si la necesitas)
            chartReportes.Legends.Clear();  // Elimina las leyendas existentes
            chartReportes.Legends.Add(new Legend("Legend"));

            // Crear una serie para los datos
            chartReportes.Series.Clear();  // Elimina las series existentes
            chartReportes.Series.Add(new Series("Estado"));
            chartReportes.Series["Estado"].ChartType = SeriesChartType.Bar; // O usa otro tipo si necesitas (ej. SeriesChartType.Pie, SeriesChartType.Line)

            // Cargar los estados en el ComboBox (filtro)
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("En tránsito");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = 0; // Por defecto selecciona el primer estado
            EstilizarDataGridView();
        }
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener las fechas seleccionadas
                DateTime fechaDesde = dtpDesde.Value;
                DateTime fechaHasta = dtpHasta.Value;

                // Verificar que las fechas sean correctas
                if (fechaDesde > fechaHasta)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los datos de las encomiendas filtradas por estado y fecha
                DataTable encomiendas = gestorEncomienda.MostrarEncomiendasPorEstadoYFecha(cmbEstado.SelectedItem.ToString(), fechaDesde, fechaHasta);

                if (encomiendas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay encomiendas disponibles para las fechas y estado seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar los datos en el DataGridView
                dgvReportes.DataSource = encomiendas;

                // Limpiar las series del gráfico
                chartReportes.Series["Estado"].Points.Clear();

                // Obtener los datos de las encomiendas por estado (para el gráfico)
                DataTable estadoEncomiendas = gestorEncomienda.ContarEncomiendasPorEstado(fechaDesde, fechaHasta);

                if (estadoEncomiendas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos disponibles para el gráfico. Verifique las fechas o el estado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Llenar el gráfico con los datos
                foreach (DataRow row in estadoEncomiendas.Rows)
                {
                    string estado = row["Estado"].ToString();
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    chartReportes.Series["Estado"].Points.AddXY(estado, cantidad); // Agregar los puntos al gráfico
                }
            }
            catch (FormatException ex)
            {
                // Capturar errores de formato, como fechas inválidas o datos mal formateados
                MessageBox.Show("Error de formato: " + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Capturar otros errores
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EstilizarDataGridView()
        {
            dgvReportes.BackgroundColor = Color.White;
            dgvReportes.DefaultCellStyle.ForeColor = Color.Black;
            dgvReportes.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvReportes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReportes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportes.EnableHeadersVisualStyles = false;
        }


        private void LimpiarCampos()
        {
            cmbEstado.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();  // Limpiar todos los campos
            this.Close();
        }
    }
}

