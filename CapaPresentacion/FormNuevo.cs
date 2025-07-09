using CapaNegocios;
using CapaNegocios.Transportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormNuevo : Form
    {
        private readonly GestorTransporte gestorTransporte;
        private readonly int transporteId = -1;

        public FormNuevo(int id = 0)
        {
            InitializeComponent();
            gestorTransporte = new GestorTransporte();
            this.transporteId = id;

            cmbTipo.Items.Add("Bus");
            cmbTipo.Items.Add("Taxi");
            cmbTipo.Items.Add("Metro");

            CargarDatosTransporte(id);
        }

        private void FormNuevo_Load(object sender, EventArgs e)
        {
            var lugares = new List<string>
            {
                "Santo Domingo", "Santiago", "Punta Cana", "Puerto Plata", "La Romana", "Moca",
                "San Francisco de Macorís", "San Cristóbal", "Barahona", "La Vega", "Boca Chica",
                "Higuey", "Samaná", "Jarabacoa", "Juan Dolio", "Constanza", "Las Terrenas", "Bani",
                "Monte Cristi", "Pedernales", "El Seibo", "Azua", "San Juan de la Maguana",
                "San Pedro de Macorís", "Cotuí", "Hato Mayor del Rey", "Cabo Rojo",
                "Las Galeras", "Sabana de la Mar", "Santiago Rodríguez", "Valverde Mao",
                "Comendador", "Sánchez", "Tamayo", "Sabana Yegua", "Los Alcarrizos", "Los Cacaos",
                "Sosúa", "Cabarete", "Río San Juan", "El Catey", "Punta Rucia", "Pueblo Viejo"
            };

            cmbLugarInicio.Items.AddRange(lugares.ToArray());
            cmbDestinoFinal.Items.AddRange(lugares.ToArray());

            cmbLugarInicio.SelectedIndex = 0;
            cmbDestinoFinal.SelectedIndex = 0;

            if (transporteId == 0)
            {
                cmbTipo.SelectedIndex = 0;
                cmbTipo_SelectedIndexChanged(cmbTipo, EventArgs.Empty);
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem == null) return;

            string tipoSeleccionado = cmbTipo.SelectedItem.ToString();

            grpMetro.Visible = (tipoSeleccionado == "Metro");
            grpTaxiBus.Visible = (tipoSeleccionado == "Bus" || tipoSeleccionado == "Taxi");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cmbTipo.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(tipo) ||
                    string.IsNullOrEmpty(txtCapacidad.Text) ||
                    string.IsNullOrEmpty(txtRuta.Text) ||
                    cmbLugarInicio.SelectedItem == null ||
                    cmbDestinoFinal.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Transporte transporte;

                if (tipo == "Metro")
                {
                    if (string.IsNullOrEmpty(txtLineaMetro.Text) ||
                        string.IsNullOrEmpty(txtEstacionesMetro.Text) ||
                        string.IsNullOrEmpty(txtVagonesMetro.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos de Metro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    transporte = new Metro
                    {
                        Linea = txtLineaMetro.Text,
                        Estaciones = Convert.ToInt32(txtEstacionesMetro.Text),
                        CapacidadVagones = Convert.ToInt32(txtVagonesMetro.Text)
                    };
                }
                else if (tipo == "Bus" || tipo == "Taxi")
                {
                    if (string.IsNullOrEmpty(txtPlaca.Text) || string.IsNullOrEmpty(txtConductor.Text))
                    {
                        MessageBox.Show("Por favor, complete los campos de Placa y Conductor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    transporte = tipo == "Bus"
                        ? new Bus { Placa = txtPlaca.Text, Conductor = txtConductor.Text }
                        : new Taxi { Placa = txtPlaca.Text, Conductor = txtConductor.Text };
                }
                else
                {
                    MessageBox.Show("Tipo de transporte no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar propiedades comunes
                transporte.Tipo = tipo;
                transporte.Capacidad = Convert.ToInt32(txtCapacidad.Text);
                transporte.Ruta = txtRuta.Text;
                transporte.LugarInicio = cmbLugarInicio.SelectedItem.ToString();  // Ruta de inicio
                transporte.DestinoFin = cmbDestinoFinal.SelectedItem.ToString();  // Ruta de destino
                transporte.HoraInicio = timePickerHoraInicio.Value.TimeOfDay;

                // Calcular tarifa automáticamente usando el método abstracto
                transporte.Tarifa = transporte.CalcularTarifa();
                txtTarifa.Text = transporte.Tarifa.ToString("F2");

                // Mostrar mensaje con la tarifa calculada
                MessageBox.Show($"Tarifa calculada automáticamente: RD${transporte.Tarifa:F2}", "Tarifa Calculada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Insertar o actualizar
                if (transporteId > 0)
                {
                    gestorTransporte.EditarTransporte(transporteId, transporte.Tipo,
                        transporte is Metro ? null : (transporte as dynamic).Placa,
                        transporte is Metro ? null : (transporte as dynamic).Conductor,
                        transporte.Capacidad, transporte.Ruta, transporte.LugarInicio,
                        transporte.DestinoFin, transporte.HoraInicio, transporte.Tarifa,
                        transporte is Metro ? (transporte as Metro).Linea : null,
                        transporte is Metro ? (transporte as Metro).Estaciones : null,
                        transporte is Metro ? (transporte as Metro).CapacidadVagones : null);

                    MessageBox.Show("Transporte actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    gestorTransporte.InsertarTransporte(transporte.Tipo,
                        transporte is Metro ? null : (transporte as dynamic).Placa,
                        transporte is Metro ? null : (transporte as dynamic).Conductor,
                        transporte.Capacidad, transporte.Ruta, transporte.LugarInicio,
                        transporte.DestinoFin, transporte.HoraInicio, transporte.Tarifa,
                        transporte is Metro ? (transporte as Metro).Linea : null,
                        transporte is Metro ? (transporte as Metro).Estaciones : null,
                        transporte is Metro ? (transporte as Metro).CapacidadVagones : null);

                    MessageBox.Show("Transporte guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el transporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosTransporte(int id)
        {
            if (id <= 0) return;

            try
            {
                DataTable dt = gestorTransporte.ObtenerTransportePorId(id);

                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];

                    string tipo = fila["Tipo"].ToString();

                    if (cmbTipo.Items.Contains(tipo))
                        cmbTipo.SelectedItem = tipo;

                    txtPlaca.Text = fila["Placa"].ToString();
                    txtConductor.Text = fila["Conductor"].ToString();
                    txtCapacidad.Text = fila["Capacidad"].ToString();
                    txtRuta.Text = fila["Ruta"].ToString();
                    cmbLugarInicio.SelectedItem = fila["LugarInicio"].ToString();
                    cmbDestinoFinal.SelectedItem = fila["DestinoFin"].ToString();
                    timePickerHoraInicio.Value = DateTime.Today.Add(TimeSpan.Parse(fila["HoraInicio"].ToString()));
                    txtTarifa.Text = fila["Tarifa"].ToString();

                    if (tipo == "Metro")
                    {
                        txtLineaMetro.Text = fila["Linea"].ToString();
                        txtEstacionesMetro.Text = fila["Estaciones"].ToString();
                        txtVagonesMetro.Text = fila["Vagones"].ToString();
                    }

                    cmbTipo_SelectedIndexChanged(cmbTipo, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del transporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
