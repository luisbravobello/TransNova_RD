using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class GestorUsuarios
    {
        private readonly CD_Usuarios cdUsuarios;

        public GestorUsuarios()
        {
            cdUsuarios = new CD_Usuarios(); // Instanciamos la capa de datos
        }

        // Método para insertar un usuario
        public void Insertar(string usuario, string contraseña)
        {
            try
            {
                cdUsuarios.InsertarUsuario(usuario, contraseña);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
        }

        // Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            try
            {
                return cdUsuarios.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message);
            }
        }

        public bool ComprobarUsuarioExistente(string usuario)
        {
            try
            {
                // Llamamos al método de la capa de datos que consulta si el usuario existe
                return cdUsuarios.ComprobarUsuarioExistente(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al comprobar si el usuario existe: " + ex.Message);
            }
        }


        // Método para eliminar un usuario
        public void EliminarUsuario(int id)
        {
            try
            {
                cdUsuarios.EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }
    }
}
