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

namespace CapaPresentacion
{
    public partial class FormTransportePrincipal : Form
    {
        private readonly GestorTransporte gestorTransporte;
        private readonly string usuario;

        public FormTransportePrincipal(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            gestorTransporte = new GestorTransporte();
        }

        private void FormTransportePrincipal_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("Bus");
            cmbTipo.Items.Add("Taxi");
            cmbTipo.Items.Add("Metro");
            CargarTransportes();
            lblusuario.Text = $"Usuario: {usuario}";
            dgvTransportes.CellFormatting += dgvTransportes_CellFormatting;
            EstilizarDataGridView();
        }

        private void dgvTransportes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransportes.Columns.Contains("Tipo") && e.RowIndex >= 0)
            {
                string tipo = dgvTransportes.Rows[e.RowIndex].Cells["Tipo"].Value?.ToString();

                if (!string.IsNullOrEmpty(tipo))
                {
                    DataGridViewRow fila = dgvTransportes.Rows[e.RowIndex];

                    switch (tipo)
                    {
                        case "Bus":
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Taxi":
                            fila.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Metro":
                            fila.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        default:
                            fila.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }
        }

        private void EstilizarDataGridView()
        {
            dgvTransportes.BackgroundColor = Color.White;
            dgvTransportes.DefaultCellStyle.ForeColor = Color.Black;
            dgvTransportes.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvTransportes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransportes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvTransportes.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvTransportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransportes.EnableHeadersVisualStyles = false;
        }

        private void CargarTransportes()
        {
            try
            {
                var transportes = gestorTransporte.ObtenerTransportes();
                dgvTransportes.DataSource = transportes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los transportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Transportes formnuevo = new Transportes();
            formnuevo.ShowDialog();
            CargarTransportes();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvTransportes.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvTransportes.SelectedRows[0].Cells[0].Value);
                    Transportes formNuevo = new Transportes(id);
                    formNuevo.ShowDialog();
                    CargarTransportes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un error al intentar editar el transporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un transporte para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTransportes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTransportes.SelectedRows[0].Cells[0].Value);
                var confirmResult = MessageBox.Show("¿Eliminar este transporte?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        gestorTransporte.EliminarTransporte(id);
                        CargarTransportes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar transporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un transporte para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem == null)
                return;

            string tipoSeleccionado = cmbTipo.SelectedItem.ToString();
            CargarTransportesPorTipo(tipoSeleccionado);
        }

        private void CargarTransportesPorTipo(string tipo)
        {
            try
            {
                var transportes = gestorTransporte.ObtenerTransportesPorTipo(tipo);

                if (!transportes.Columns.Contains("Descripcion"))
                    transportes.Columns.Add("Descripcion", typeof(string));

                foreach (DataRow row in transportes.Rows)
                {
                    string descripcion = "";

                    if (tipo == "Bus" || tipo == "Taxi")
                    {
                        descripcion = $"{tipo} - Ruta: {row["Ruta"]}, Desde: {row["LugarInicio"]} hasta {row["DestinoFin"]} - Placa: {row["Placa"]}, Conductor: {row["Conductor"]}";
                        row["Estaciones"] = DBNull.Value;
                        row["Vagones"] = DBNull.Value;
                        row["Linea"] = DBNull.Value;
                    }
                    else if (tipo == "Metro")
                    {
                        descripcion = $"Metro Línea {row["Linea"]} - {row["Estaciones"]} estaciones, Tarifa: RD${row["Tarifa"]}";
                        row["Placa"] = DBNull.Value;
                        row["Conductor"] = DBNull.Value;
                    }

                    row["Descripcion"] = descripcion;
                }

                dgvTransportes.DataSource = transportes;

                dgvTransportes.Columns["Placa"].Visible = (tipo != "Metro");
                dgvTransportes.Columns["Conductor"].Visible = (tipo != "Metro");
                dgvTransportes.Columns["Linea"].Visible = (tipo == "Metro");
                dgvTransportes.Columns["Estaciones"].Visible = (tipo == "Metro");
                dgvTransportes.Columns["Vagones"].Visible = (tipo == "Metro");

                if (dgvTransportes.Columns.Contains("Descripcion"))
                    dgvTransportes.Columns["Descripcion"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los transportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarTransportes(string texto)
        {
            try
            {
                DataTable transportes = gestorTransporte.ObtenerTransportes();

                if (!string.IsNullOrEmpty(texto))
                {
                    DataView dv = transportes.DefaultView;
                    dv.RowFilter = $"Tipo LIKE '%{texto}%' OR Ruta LIKE '%{texto}%' OR Placa LIKE '%{texto}%' OR Conductor LIKE '%{texto}%' OR LugarInicio LIKE '%{texto}%' OR DestinoFin LIKE '%{texto}%'";

                    dgvTransportes.DataSource = dv;
                }
                else
                {
                    dgvTransportes.DataSource = transportes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar transportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarTransportes(txtBusqueda.Text.Trim());
        }

        private void btnEncomiendas_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de encomiendas
            FormEncomiendas formEncomiendas = new FormEncomiendas();

            // Mostrar el formulario de encomiendas
            formEncomiendas.Show(); // Si prefieres mostrar el formulario de manera modal usa formEncomiendas.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            RegistroReportes formReportes = new RegistroReportes();
            formReportes.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.ShowDialog();
        }
    }
}
