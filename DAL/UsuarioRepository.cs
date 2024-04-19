using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class UsuarioRepository : BaseDatos
    {
        public List<Usuario> ConsultarUsuario()
        {
            List<Usuario> list = new List<Usuario>();
            string ssql = "select * from Usuarios";

            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(MapearUsuario(rdr));
            }
            rdr.Close();
            CerrarConexion();

            return list;

        }

        private Usuario MapearUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();

            usuario.Usuarios = Convert.ToString(reader["Vendedor"]);
            usuario.Contraseña = Convert.ToString(reader["Clave"]);

            return usuario;
        }
    }
}
