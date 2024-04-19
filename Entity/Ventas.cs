using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Venta
    {
        public string idVenta { get; set; }
        public string tipoProducto { get; set; }
        public double Total { get; set; }
        public int cantidadProducto { get; set; }
        public string fechaVenta { get; set; }
    }
}
