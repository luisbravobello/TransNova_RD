using CapaNegocios;
using CapaDatos;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormEncomiendas : Form
    {
        private GestorEncomienda gestorEncomienda;


        public FormEncomiendas()
        {
            InitializeComponent();

            // Asociamos los eventos a los controles
            txtCodigoSeguimiento.KeyPress += txtCodigoSeguimiento_KeyPress;
            txtRemitente.KeyPress += txtRemitente_KeyPress;
            txtDestinatario.KeyPress += txtDestinatario_KeyPress;
            txtDireccionEntrega.KeyPress += txtDireccionEntrega_KeyPress;
            numPeso.Validating += numPeso_Validating; // Para el control de peso
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

        // Validaciones de caracteres permitidos en los campos
        private void txtCodigoSeguimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y números en el Código de Seguimiento
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Bloquear el carácter ingresado
            }
        }

        private void txtRemitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y espacio en blanco para el Remitente
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y espacio en blanco para el Destinatario
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDireccionEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, y algunos caracteres especiales como guiones, comas y puntos
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,.-/ ";
            if (!caracteresPermitidos.Contains(e.KeyChar.ToString()) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("La dirección solo puede contener letras, números y algunos caracteres especiales como comas, puntos y guiones.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numPeso_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Validar que el peso sea mayor que 0
            if (numPeso.Value <= 0)
            {
                MessageBox.Show("El peso debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Evitar que el formulario se cierre si el peso es 0 o menor
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

        // Método para aplicar el estilo al DataGridView
        private void EstilizarDataGridView()
        {
            // Configuración de estilo general para el DataGridView
            dgvEncomiendas.BackgroundColor = Color.White;
            dgvEncomiendas.DefaultCellStyle.ForeColor = Color.Black;
            dgvEncomiendas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvEncomiendas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEncomiendas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvEncomiendas.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvEncomiendas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEncomiendas.EnableHeadersVisualStyles = false;
        }

        // Método para aplicar colores de fondo según el estado de la encomienda
        private void AplicarColorEstado()
        {
            // Recorremos todas las filas del DataGridView para aplicar el color correspondiente
            foreach (DataGridViewRow row in dgvEncomiendas.Rows)
            {
                // Aseguramos que la celda de "Estado" no sea nula
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();

                    // Cambiar el color de fondo de acuerdo al estado de la encomienda
                    switch (estado)
                    {
                        case "Pendiente":
                            row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow; // Color amarillo claro
                            break;
                        case "En tránsito":
                            row.DefaultCellStyle.BackColor = Color.LightSalmon; // Color naranja claro
                            break;
                        case "Entregado":
                            row.DefaultCellStyle.BackColor = Color.LightGreen; // Color verde claro
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White; // Si no es ninguno de los anteriores, color blanco
                            break;
                    }
                }
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
    }
}
