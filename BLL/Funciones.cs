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
        string RegistrarVenta(Venta venta);
        string ModificarVenta(Venta Venta);
        string EliminarVenta(Venta venta);
        List<Venta> ConsultarVenta();
    }
}
