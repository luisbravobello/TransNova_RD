using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
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
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
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
                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un nuevo usuario
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                // Verificación adicional: Evitar que el nombre de usuario ya esté en uso
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
                    gestorUsuarios.EliminarUsuario(id);
                    MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarUsuarios(); // Actualizar la lista de usuarios
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
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;
        }
    }
}
