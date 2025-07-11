using CapaNegocios;
using CapaNegocios.Transportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Transportes : Form
    {
        private readonly GestorTransporte gestorTransporte;
        private readonly int transporteId = -1;

        public Transportes(int id = 0)
        {
            InitializeComponent();
            gestorTransporte = new GestorTransporte();
            this.transporteId = id;

            cmbTipo.Items.AddRange(new[] { "Bus", "Taxi", "Metro" });
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Load += FormNuevo_Load;

            // Eventos KeyPress
            txtRuta.KeyPress += SoloLetras;
            txtConductor.KeyPress += SoloLetras;
            txtLineaMetro.KeyPress += SoloLetras;

            txtCapacidad.KeyPress += SoloNumeros;
            txtEstacionesMetro.KeyPress += SoloNumeros;
            txtVagonesMetro.KeyPress += SoloNumeros;
            txtTarifa.KeyPress += SoloDecimal;
        }

        private void FormNuevo_Load(object sender, EventArgs e)
        {
            var lugares = new List<string>
            {
               "Azua", "Baní", "Barahona", "Boca Chica", "Cabo Rojo", "Cabarete", "Cotuí", "Comendador",
               "Constanza", "El Catey", "El Seibo", "Hato Mayor del Rey", "Higuey", "Jarabacoa",
               "Juan Dolio", "La Altagracia", "La Romana", "La Vega", "Las Galeras", "Las Terrenas",
               "Los Alcarrizos", "Los Cacaos", "La Otra Banda", "Moca", "Monte Cristi", "Pedernales",
               "Puerto Plata", "Pueblo Viejo", "Punta Cana", "Punta Rucia", "Río San Juan",
               "Sabana de la Mar", "Sabana Yegua", "Samana", "San Cristóbal", "San Francisco de Macorís",
               "San Juan de la Maguana", "San Pedro de Macorís", "Sánchez", "Santiago", "Santiago Rodríguez",
               "Santo Domingo", "Sosúa", "Tamayo", "Valverde Mao"
            };



            cmbLugarInicio.Items.AddRange(lugares.ToArray());
            cmbDestinoFinal.Items.AddRange(lugares.ToArray());

            cmbLugarInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestinoFinal.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbLugarInicio.SelectedIndex = 0;
            cmbDestinoFinal.SelectedIndex = 1;

            if (transporteId == 0)
            {
                cmbTipo.SelectedIndex = 0;
                cmbTipo_SelectedIndexChanged(cmbTipo, EventArgs.Empty);
            }
            else
            {
                CargarDatosTransporte(transporteId);
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

                if (cmbLugarInicio.SelectedItem.ToString() == cmbDestinoFinal.SelectedItem.ToString())
                {
                    MessageBox.Show("El lugar de inicio y destino no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Regex.IsMatch(txtRuta.Text, @"\d"))
                {
                    MessageBox.Show("La ruta no debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Regex.IsMatch(txtConductor.Text, @"\d"))
                {
                    MessageBox.Show("El nombre del conductor no debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tipo == "Metro" && Regex.IsMatch(txtLineaMetro.Text, @"\d"))
                {
                    MessageBox.Show("La línea del metro no debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtCapacidad.Text, out int capacidadIngresada))
                {
                    MessageBox.Show("Capacidad debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tarifaIngresada = 500;

                if (tipo == "Metro" && string.IsNullOrWhiteSpace(txtTarifa.Text))
                {
                    tarifaIngresada = 600.00m; // Tarifa más alta para Metro
                }
                else if (!decimal.TryParse(txtTarifa.Text, out tarifaIngresada))
                {
                    MessageBox.Show("Tarifa debe ser un número decimal válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Límite máximo permitido para tarifa
                decimal tarifaMaxima = 10000m;
                if (tarifaIngresada > tarifaMaxima)
                {
                    MessageBox.Show($"La tarifa no puede ser mayor a RD$ {tarifaMaxima}.", "Tarifa demasiado alta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int capacidadMinima = tipo == "Bus" ? 50 : tipo == "Taxi" ? 4 : 100;
                if (capacidadIngresada < capacidadMinima)
                {
                    MessageBox.Show($"La capacidad mínima para {tipo} es {capacidadMinima}.", "Capacidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal tarifaMinima = tipo == "Bus" ? 450 : tipo == "Taxi" ? 300 : 10;
                if (tarifaIngresada < tarifaMinima)
                {
                    MessageBox.Show($"La tarifa mínima para {tipo} es RD$ {tarifaMinima}.", "Tarifa insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Transporte transporte;

                if (tipo == "Metro")
                {
                    if (!int.TryParse(txtEstacionesMetro.Text, out int estaciones) ||
                        !int.TryParse(txtVagonesMetro.Text, out int vagones))
                    {
                        MessageBox.Show("Estaciones y Vagones deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    transporte = new Metro
                    {
                        Linea = txtLineaMetro.Text,
                        Estaciones = estaciones,
                        CapacidadVagones = vagones,
                        Tarifa = tarifaIngresada,  // Asegúrate de asignar tarifa calculada
                        Capacidad = capacidadIngresada
                    };
                }
                else if (tipo == "Bus" || tipo == "Taxi")
                {
                    if (string.IsNullOrWhiteSpace(txtPlaca.Text) || txtPlaca.Text.Length > 20 ||
                        string.IsNullOrWhiteSpace(txtConductor.Text) || txtConductor.Text.Length > 100)
                    {
                        MessageBox.Show("Verifique los campos de Placa y Conductor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validar formato de la placa
                    if (!ValidarPlaca(txtPlaca.Text))
                    {
                        MessageBox.Show("La placa debe tener entre 4 y 10 caracteres, solo letras, números o guiones.", "Placa inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    transporte = tipo == "Bus"
                        ? new Bus { Placa = txtPlaca.Text, Conductor = txtConductor.Text, Tarifa = tarifaIngresada, Capacidad = capacidadIngresada }
                        : new Taxi { Placa = txtPlaca.Text, Conductor = txtConductor.Text, Tarifa = tarifaIngresada, Capacidad = capacidadIngresada };
                }
                else
                {
                    MessageBox.Show("Tipo de transporte no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                transporte.Tipo = tipo;
                transporte.Ruta = txtRuta.Text;
                transporte.LugarInicio = cmbLugarInicio.SelectedItem.ToString();
                transporte.DestinoFin = cmbDestinoFinal.SelectedItem.ToString();
                transporte.HoraInicio = timePickerHoraInicio.Value.TimeOfDay;

                if (transporteId > 0)
                {
                    gestorTransporte.EditarTransporte(transporteId, transporte.Tipo,
                        transporte is Metro ? null : ((dynamic)transporte).Placa,
                        transporte is Metro ? null : ((dynamic)transporte).Conductor,
                        transporte.Capacidad, transporte.Ruta, transporte.LugarInicio,
                        transporte.DestinoFin, transporte.HoraInicio, transporte.Tarifa,
                        transporte is Metro ? ((Metro)transporte).Linea : null,
                        transporte is Metro ? ((Metro)transporte).Estaciones : null,
                        transporte is Metro ? ((Metro)transporte).CapacidadVagones : null);

                    MessageBox.Show("Transporte actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    gestorTransporte.InsertarTransporte(transporte.Tipo,
                        transporte is Metro ? null : ((dynamic)transporte).Placa,
                        transporte is Metro ? null : ((dynamic)transporte).Conductor,
                        transporte.Capacidad, transporte.Ruta, transporte.LugarInicio,
                        transporte.DestinoFin, transporte.HoraInicio, transporte.Tarifa,
                        transporte is Metro ? ((Metro)transporte).Linea : null,
                        transporte is Metro ? ((Metro)transporte).Estaciones : null,
                        transporte is Metro ? ((Metro)transporte).CapacidadVagones : null);

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

                    // Asegúrate de cargar la tarifa en el campo txtTarifa
                    txtTarifa.Text = fila["Tarifa"].ToString(); // Esta línea es clave

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

        

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números enteros.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SoloDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números o punto decimal.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private bool ValidarPlaca(string placa)
        {
            return Regex.IsMatch(placa, @"^[A-Z0-9\-]{4,10}$", RegexOptions.IgnoreCase);
        }
    }
}
