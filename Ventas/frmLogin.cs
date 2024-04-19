using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void labelContraseña_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarsesion_Click(object sender, EventArgs e)
        {
            Ingresar();
        }
        public void Ingresar()
        {
            if (txtUsuario.Text != "")
            {
                if (txtContraseña.Text != "")
                {
                    List<Usuario> TEST = new UsuarioService().ConsultarUsuario();
                    Usuario usuario = new UsuarioService().LoginUser(txtUsuario.Text, txtContraseña.Text).FirstOrDefault();
                    if (usuario != null)
                    {
                        frmVentas Venta = new frmVentas();
                        Venta.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña no válido", "login");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña válida", "login");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario válido", "login");
            }
        }
    }
}
