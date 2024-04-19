using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public interface Funciones
    {
        string RegistrarVenta(Ventas venta);
        string ModificarVenta(Ventas Venta);
        string EliminarVenta(Ventas venta);
        List<Ventas> ConsultarVenta();
    }
}
