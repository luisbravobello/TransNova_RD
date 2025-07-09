using CapaNegocios;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        
        private readonly GestorUsuario gestor = new GestorUsuario();
        public FormLogin()
        {
            InitializeComponent();
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void btnlogin_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text.Trim();
            string contrasena = txtcontrase�a.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe ingresar usuario y contrase�a.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool accesoPermitido = gestor.Login(usuario, contrasena);

                if (accesoPermitido)
                {
                    // Mensaje de bienvenida personalizado
                    MessageBox.Show($"Bienvenido al sistema, {usuario}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre el formulario principal y pasa el nombre de usuario
                    FormTransportePrincipal frm = new FormTransportePrincipal(usuario);  // Pasamos el usuario al formulario principal
                    frm.Show();
                    this.Hide(); // Ocultar el formulario de login
                }
                else
                {
                    MessageBox.Show("Usuario o contrase�a incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el inicio de sesi�n:\n" + ex.Message, "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcontrase�a_MouseEnter(object sender, EventArgs e)
        {
            // Si el campo tiene el texto por defecto, lo eliminamos y configuramos para que sea oculto
            if (txtcontrase�a.Text == "CONTRASE�A")
            {
                txtcontrase�a.Text = "";
                txtcontrase�a.ForeColor = Color.White;  // Cambiar color del texto a blanco
                txtcontrase�a.UseSystemPasswordChar = true;  // Ocultar la contrase�a (asteriscos)
            }
        }

        private void txtcontrase�a_MouseLeave(object sender, EventArgs e)
        {
            // Si el campo est� vac�o, ponemos el texto por defecto
            if (txtcontrase�a.Text == "")
            {
                txtcontrase�a.Text = "CONTRASE�A";
                txtcontrase�a.ForeColor = Color.LightGray;  // Color de texto por defecto
                txtcontrase�a.UseSystemPasswordChar = false; // No ocultar la contrase�a
            }
        }



        private void txtusuario_MouseEnter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.LightGray;
            }
        }

        private void txtusuario_MouseLeave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
    }
}
