using System;
using CapaDatos; // Para acceder a la clase CD_Usuario

namespace CapaNegocios
{
    public class GestorUsuario
    {
        private readonly CD_Usuario cdUsuario;

        public GestorUsuario()
        {
            cdUsuario = new CD_Usuario();  // Instancia de la capa de datos
        }

        public bool Login(string clave, string contraseña)
        {
            // Validación de credenciales utilizando la clase CD_Usuario
            try
            {
                return cdUsuario.VerificarLogin(clave, contraseña);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al intentar iniciar sesión: " + ex.Message);
            }
        }
    }
}
