using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        public string Usuarios { get; set; }
        public string Contraseña { get; set; }

        public Usuario(){

        }

        public Usuario(string usuarios, string contraseña)
        {
            Usuarios = usuarios;
            Contraseña = contraseña;
        }
    }
}
