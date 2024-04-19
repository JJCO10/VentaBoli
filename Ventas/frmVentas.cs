using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Ventas
{
    public partial class frmVentas : Form
    {
        VentaService ventaService = new VentaService();
        public frmVentas()
        {
            InitializeComponent();
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if (txtCodigoVenta.Text == "" || cboxTipoProducto.Text == "" || txtCantidadProducto.Text == "" || txtTotalVenta.Text == "")
            {
                MessageBox.Show("Por favor, Llene todas las casillas");
            }
            else
            {
                Venta venta = new Venta
                {
                    idVenta = txtCodigoVenta.Text,
                    tipoProducto = cboxTipoProducto.Text,
                    cantidadProducto = Convert.ToInt32(txtCantidadProducto.Text),
                    Total = Convert.ToInt32(txtTotalVenta.Text),
                    fechaVenta = Convert.ToString(dtpFechaVenta.Value.ToString("d"))
                };
                InsertarVenta(venta);
                cargarGrillaVentas(ventaService.ConsultarVenta());
            }
        }

        private void btnModificarVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {

        }
        private void InsertarVenta(Venta venta)
        {
            var msg = ventaService.RegistrarVenta(venta);
            MessageBox.Show(msg);
        }
        private void cargarGrillaVentas(List<Venta> ventas)
        {
            dgvVentas.Rows.Clear();

            if (ventas != null)
            {
                foreach (var venta in ventas)
                {
                    int index = dgvVentas.Rows.Add();
                    DataGridViewRow row = dgvVentas.Rows[index];
                    row.Cells["dgvIdVenta"].Value = venta.idVenta;
                    row.Cells["dgvtipoProducto"].Value = venta.tipoProducto;
                    row.Cells["dgvcantidadProducto"].Value = venta.cantidadProducto;
                    row.Cells["dgvTotal"].Value = venta.Total;
                    row.Cells["dgvfechaVenta"].Value = venta.fechaVenta;
                }
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
