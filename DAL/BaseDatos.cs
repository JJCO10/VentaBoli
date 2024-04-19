using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDatos
    {
        protected SqlConnection conexion;
        protected string cadenaConexion = "Data Source=holamundodev.eastus2.cloudapp.azure.com; Initial Catalog=juanDB; user id=juancarmona; password=Holamundo123*";
        public BaseDatos() 
        { 
            conexion = new SqlConnection(cadenaConexion);
        }
        public string AbrirConexion()
        {
            conexion.Open();
            return conexion.State.ToString();
        }
        public string CerrarConexion()
        {
            conexion.Close();
            return conexion.State.ToString();
        }
    }
}
