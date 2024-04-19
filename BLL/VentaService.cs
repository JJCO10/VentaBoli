using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class VentaService : Funciones
    {
        VentaRepository repository = new VentaRepository();

        public string RegistrarVenta(Venta venta)
        {
            var msg = repository.RegistrarVenta(venta);
            return msg;
        }

        public string ModificarVenta(Venta Venta)
        {
            return repository.ModifcarVenta(Venta);
        }

        public string EliminarVenta(Venta venta)
        {
            return repository.EliminarVenta(venta);
        }

        public List<Venta> ConsultarVenta()
        {
            var msg = repository.ConsultarVenta();
            return msg;
        }

        public List<Venta> BuscarFiltradoVenta(string x)
        {
            return ConsultarVenta().Where(
                item => item.idVenta == x ||
                item.tipoProducto.Contains(x) ||
                item.fechaVenta.Contains(x)).ToList();
        }

    }
}
