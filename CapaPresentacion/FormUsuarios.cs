using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormUsuarios : Form
    {
        private GestorUsuarios gestorUsuarios;

        public FormUsuarios()
        {
            InitializeComponent();
            gestorUsuarios = new GestorUsuarios();
            EstilizarDataGridView();
            txtUsuario.KeyPress += SoloLetras;
            dgvUsuarios.CellValueChanged += dgvUsuarios_CellValueChanged;
            txtUsuario.TextChanged += ValidarCampos;
            txtContraseña.TextChanged += ValidarCampos;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                // Configurar el campo de contraseña para que los caracteres se muestren como asteriscos
                txtContraseña.PasswordChar = '*';

                MostrarUsuarios(); // Mostrar los usuarios al cargar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string contraseña = txtContraseña.Text.Trim();

                // Verificar si el nombre de usuario o la contraseña están vacíos
                if (string.IsNullOrEmpty(usuario))
                {
                    MessageBox.Show("Por favor, ingrese un nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, ingrese una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el nombre de usuario contenga solo letras
                if (!Regex.IsMatch(usuario, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("El nombre de usuario solo debe contener letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la contraseña tenga al menos 6 caracteres
                if (contraseña.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si el nombre de usuario es válido y la contraseña tiene la longitud requerida
                if (gestorUsuarios.ComprobarUsuarioExistente(usuario))
                {
                    MessageBox.Show("El usuario ya existe. Por favor, elija otro nombre de usuario.", "Usuario ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar el usuario en la base de datos
                gestorUsuarios.Insertar(usuario, contraseña);
                MessageBox.Show("Usuario registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                MostrarUsuarios(); // Actualizar la lista de usuarios
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void MostrarUsuarios()
        {
            try
            {
                // Obtener los usuarios desde la base de datos
                DataTable usuarios = gestorUsuarios.ObtenerUsuarios();

                if (usuarios.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron usuarios registrados.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Asignar los datos al DataGridView
                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.Columns["Id"].HeaderText = "ID";
                dgvUsuarios.Columns["Clave"].HeaderText = "Usuario";
                dgvUsuarios.Columns["Contraseña"].HeaderText = "Contraseña";

                // Configuración de las columnas
                dgvUsuarios.Columns["Clave"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUsuarios.Columns["Contraseña"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        // Método para eliminar un usuario
        private bool alertaMostrada = false; // Bandera para mostrar la alerta solo una vez

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    // Obtener el ID del usuario seleccionado
                    int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);

                    // Eliminar el usuario de la base de datos
                    gestorUsuarios.EliminarUsuario(id);

                    // Solo mostrar la alerta una vez
                    if (!alertaMostrada)
                    {
                        MessageBox.Show("Si dejas el nombre de usuario o la contraseña vacíos, no podrás acceder al sistema.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                        // Establecer la bandera para que no se muestre de nuevo
                        alertaMostrada = true;
                    }

                    // Actualizar el DataGridView después de la eliminación
                    MostrarUsuarios(); // Actualizar la lista de usuarios

                    MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un usuario para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario
        }

        private void EstilizarDataGridView()
        {
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;
        }


        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y espacio en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  // Bloquear el carácter ingresado
                MessageBox.Show("Solo se permiten letras.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            // Deshabilitar el botón de "Guardar" si alguno de los campos está vacío
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }

        private void dgvUsuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar si hay filas y si la columna "Clave" (usuario) está siendo editada
                if (dgvUsuarios.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    // Verificar si la columna "Clave" (usuario) está siendo editada
                    if (e.ColumnIndex == dgvUsuarios.Columns["Clave"].Index)
                    {
                        string usuario = dgvUsuarios.Rows[e.RowIndex].Cells["Clave"].Value.ToString();

                        // Verificar si el campo de usuario está vacío
                        if (string.IsNullOrEmpty(usuario))
                        {
                            // Mostrar un mensaje de advertencia si el usuario está vacío
                            MessageBox.Show("Debes ingresar un nombre de usuario. Si dejas el campo vacío no podrás acceder nuevamente al sistema.",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
