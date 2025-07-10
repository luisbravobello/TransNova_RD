using CapaNegocios;
using CapaDatos;
using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FormEncomiendas : Form
    {
        private GestorEncomienda gestorEncomienda;


        public FormEncomiendas()
        {
            InitializeComponent();
            gestorEncomienda = new GestorEncomienda(); // Instanciamos el GestorEncomienda

        }

        private void FormEncomiendas_Load(object sender, EventArgs e)
        {
            // Cargar los tipos de transporte en el ComboBox
            cmbTipoTransporte.Items.Add("Bus");
            cmbTipoTransporte.Items.Add("Taxi");
            cmbTipoTransporte.Items.Add("Metro");
            cmbTipoTransporte.SelectedIndex = 0; // Seleccionar el primer tipo por defecto


            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("En tránsito");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = 0;

            cmbNuevoEstado.Items.Add("Pendiente");
            cmbNuevoEstado.Items.Add("En tránsito");
            cmbNuevoEstado.Items.Add("Entregado");
            cmbNuevoEstado.SelectedIndex = 0; // Seleccionar el primer estado por defecto

            // Cargar las placas en el ComboBox según el tipo seleccionado
            CargarPlacas();
            EstilizarDataGridView(); // Aplicar estilo al DataGridView
            AplicarColorEstado();
        }

        // Llamamos a este método cuando el tipo de transporte cambie
        private void cmbTipoTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlacas();  // Cargar las placas correspondientes al tipo de transporte seleccionado
        }

        // Cargar las placas correspondientes al tipo de transporte seleccionado
        private void CargarPlacas()
        {
            string tipoTransporte = cmbTipoTransporte.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tipoTransporte))
            {
                // Obtener las placas desde la capa de negocios
                DataTable transportes = gestorEncomienda.ObtenerPlacasPorTipo(tipoTransporte);

                // Limpiar el ComboBox de placas
                cmbPlaca.Items.Clear();

                // Poblar el ComboBox con las placas obtenidas de la base de datos
                foreach (DataRow row in transportes.Rows)
                {
                    cmbPlaca.Items.Add(row["Placa"].ToString());  // Agregar la placa al ComboBox
                }

                // Seleccionar la primera placa por defecto
                if (cmbPlaca.Items.Count > 0)
                    cmbPlaca.SelectedIndex = 0;
            }
        }

        // Guardar la encomienda
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los ComboBoxes y campos de texto estén completos
            if (string.IsNullOrEmpty(txtCodigoSeguimiento.Text) ||
                cmbTipoTransporte.SelectedItem == null ||  // Verifica que haya un tipo de transporte seleccionado
                cmbPlaca.SelectedItem == null ||           // Verifica que haya una placa seleccionada
                string.IsNullOrEmpty(txtRemitente.Text) ||
                string.IsNullOrEmpty(txtDestinatario.Text) ||
                string.IsNullOrEmpty(txtDireccionEntrega.Text) ||
                numPeso.Value == 0 ||                     // Verifica que el peso no sea 0
                cmbEstado.SelectedItem == null)           // Verifica que haya un estado seleccionado
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear el objeto Encomienda con los datos del formulario
                Encomienda encomienda = new Encomienda
                {
                    CodigoSeguimiento = txtCodigoSeguimiento.Text,
                    TipoTransporte = cmbTipoTransporte.SelectedItem.ToString(),
                    Placa = cmbPlaca.SelectedItem?.ToString(),
                    Remitente = txtRemitente.Text,
                    Destinatario = txtDestinatario.Text,
                    DireccionEntrega = txtDireccionEntrega.Text,
                    Peso = numPeso.Value,
                    FechaEstimadaEntrega = dateTimePickerFechaEstimada.Value,
                    Estado = cmbEstado.SelectedItem.ToString()  // Estado de la encomienda
                };

                // Llamar al método Insertar del GestorEncomienda
                gestorEncomienda.Insertar(encomienda);
                MessageBox.Show("Encomienda guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                MostrarEncomiendas();  // Actualizar la lista de encomiendas en el DataGridView
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de error en caso de que ocurra un problema
                MessageBox.Show("Error al guardar la encomienda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Mostrar todas las encomiendas en el DataGridView
        private void btnMostrarEncomiendas_Click(object sender, EventArgs e)
        {
            try
            {
                // Llamamos al método MostrarEncomiendas del GestorEncomienda
                DataTable encomiendas = gestorEncomienda.MostrarEncomiendas(); // Sin pasar parámetro

                // Asignamos los resultados al DataGridView
                dgvEncomiendas.DataSource = encomiendas;

                // Configuración de las columnas del DataGridView para mejor visualización
                dgvEncomiendas.Columns["Id"].HeaderText = "ID";
                dgvEncomiendas.Columns["CodigoSeguimiento"].HeaderText = "Código de Seguimiento";
                dgvEncomiendas.Columns["TipoTransporte"].HeaderText = "Tipo de Transporte";
                dgvEncomiendas.Columns["Placa"].HeaderText = "Placa";
                dgvEncomiendas.Columns["Remitente"].HeaderText = "Remitente";
                dgvEncomiendas.Columns["Destinatario"].HeaderText = "Destinatario";
                dgvEncomiendas.Columns["FechaEstimadaEntrega"].HeaderText = "Fecha Estimada de Entrega";
                dgvEncomiendas.Columns["Peso"].HeaderText = "Peso";
                dgvEncomiendas.Columns["Estado"].HeaderText = "Estado";

                // Configurar el tamaño de las columnas
                dgvEncomiendas.Columns["Placa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvEncomiendas.Columns["FechaEstimadaEntrega"].DefaultCellStyle.Format = "d"; // Formato corto de fecha
                dgvEncomiendas.Columns["Peso"].DefaultCellStyle.Format = "C2"; // Formato de moneda (RD$)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las encomiendas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para actualizar el DataGridView con las encomiendas
        private void MostrarEncomiendas()
        {
            try
            {
                // Llamamos al método MostrarEncomiendas del GestorEncomienda para obtener todas las encomiendas
                DataTable encomiendas = gestorEncomienda.MostrarEncomiendas();  // Obtener todas las encomiendas

                // Asignamos los resultados al DataGridView
                dgvEncomiendas.DataSource = encomiendas;

                // Configuración de las columnas del DataGridView para mejor visualización
                dgvEncomiendas.Columns["Id"].HeaderText = "ID";
                dgvEncomiendas.Columns["CodigoSeguimiento"].HeaderText = "Código de Seguimiento";
                dgvEncomiendas.Columns["TipoTransporte"].HeaderText = "Tipo de Transporte";
                dgvEncomiendas.Columns["Placa"].HeaderText = "Placa";
                dgvEncomiendas.Columns["Remitente"].HeaderText = "Remitente";
                dgvEncomiendas.Columns["Destinatario"].HeaderText = "Destinatario";
                dgvEncomiendas.Columns["FechaEstimadaEntrega"].HeaderText = "Fecha Estimada de Entrega";
                dgvEncomiendas.Columns["Peso"].HeaderText = "Peso";
                dgvEncomiendas.Columns["Estado"].HeaderText = "Estado";

                // Configurar el tamaño de las columnas
                dgvEncomiendas.Columns["Placa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvEncomiendas.Columns["FechaEstimadaEntrega"].DefaultCellStyle.Format = "d"; // Formato corto de fecha
                dgvEncomiendas.Columns["Peso"].DefaultCellStyle.Format = "C2"; // Formato de moneda (RD$)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las encomiendas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtCodigoSeguimiento.Clear();
            txtRemitente.Clear();
            txtDestinatario.Clear();
            txtDireccionEntrega.Clear();
            numPeso.Value = 0;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario de encomiendas
        }

        private void AplicarColorEstado()
        {
            foreach (DataGridViewRow row in dgvEncomiendas.Rows)
            {
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();

                    switch (estado)
                    {
                        case "Pendiente":
                            row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            break;
                        case "En tránsito":
                            row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            break;
                        case "Entregado":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }
        }


        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado una encomienda y un estado
            if (dgvEncomiendas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una encomienda para actualizar su estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un nuevo estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la encomienda seleccionada
            int idEncomienda = Convert.ToInt32(dgvEncomiendas.SelectedRows[0].Cells["Id"].Value);
            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();

            try
            {
                // Llamar al método para actualizar el estado
                gestorEncomienda.ActualizarEstadoEncomienda(idEncomienda, nuevoEstado);

                MessageBox.Show("Estado de la encomienda actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la vista de las encomiendas
                MostrarEncomiendas(); // Llamar al método para actualizar la lista de encomiendas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado de la encomienda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarDataGridView()
        {
            dgvEncomiendas.BackgroundColor = Color.White;
            dgvEncomiendas.DefaultCellStyle.ForeColor = Color.Black;
            dgvEncomiendas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvEncomiendas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEncomiendas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvEncomiendas.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvEncomiendas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEncomiendas.EnableHeadersVisualStyles = false;
        }

        private void dgvEncomiendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEncomiendas.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                if (estado == "Pendiente")
                {
                    e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estado == "En tránsito")
                {
                    e.CellStyle.BackColor = Color.Orange;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (estado == "Entregado")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

    }
}
