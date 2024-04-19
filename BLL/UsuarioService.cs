using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class UsuarioService
    {
        UsuarioRepository repository = new UsuarioRepository();

        public List<Usuario> ConsultarUsuario()
        {
            var msg = repository.ConsultarUsuario();
            return msg;
        }

        public List<Usuario> LoginUser(string usuarios, string contraseña)
        {
            return ConsultarUsuario().Where(x => x.Usuarios == usuarios && x.Contraseña == contraseña).ToList();
        }
    }
}
