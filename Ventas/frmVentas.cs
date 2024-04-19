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
            if (txtCodigoVenta.Text != "" || cboxTipoProducto.Text != "" || txtCantidadProducto.Text != "" || txtTotalVenta.Text != "")
            {
                Venta venta = new Venta
                {
                    idVenta = txtCodigoVenta.Text,
                    tipoProducto = cboxTipoProducto.Text,
                    cantidadProducto = Convert.ToInt32(txtCantidadProducto.Text),
                    Total = Convert.ToInt32(txtTotalVenta.Text),
                    fechaVenta = Convert.ToString(dtpFechaVenta.Value.ToString("d"))
                };
                
                ModificarBD(venta);
                cargarGrillaVentas(ventaService.ConsultarVenta());
            }
            else
            {
                MessageBox.Show("Faltan datos por ingresar!", "Gestion de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (txtCodigoVenta.Text != "" || cboxTipoProducto.Text != "" || txtCantidadProducto.Text != "" || txtTotalVenta.Text != "")
            {
                Venta venta = new Venta
                {
                    idVenta = txtCodigoVenta.Text,
                    tipoProducto = cboxTipoProducto.Text,
                    cantidadProducto = Convert.ToInt32(txtCantidadProducto.Text),
                    Total = Convert.ToInt32(txtTotalVenta.Text),
                    fechaVenta = Convert.ToString(dtpFechaVenta.Value.ToString("d"))
                };
                EliminarBD(venta);
                cargarGrillaVentas(ventaService.ConsultarVenta());
            }
            else
            {
                MessageBox.Show("Faltan datos por ingresar!", "Gestion de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtCodigoVenta.Text = dgvVentas.Rows[index].Cells["dgvIdVenta"].Value.ToString();
                cboxTipoProducto.Text = dgvVentas.Rows[index].Cells["dgvtipoProducto"].Value.ToString();
                txtCantidadProducto.Text = dgvVentas.Rows[index].Cells["dgvcantidadProducto"].Value.ToString();
                txtTotalVenta.Text = dgvVentas.Rows[index].Cells["dgvTotal"].Value.ToString();
                dtpFechaVenta.Text = dgvVentas.Rows[index].Cells["dgvfechaVenta"].Value.ToString();
            }
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarGrillaVentas(ventaService.ConsultarVenta());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVentasFiltro();
        }
        private void CargarVentasFiltro()
        {
            var filtro = txtBuscar.Text;
            var list = ventaService.BuscarFiltradoVenta(filtro);
            cargarGrillaVentas(list);
        }
        private void ModificarBD(Venta venta)
        {
            var msg = ventaService.ModificarVenta(venta);
            MessageBox.Show(msg);
        }
        void EliminarBD(Venta venta)
        {
            var msg = ventaService.EliminarVenta(venta);
            MessageBox.Show(msg);
        }
    }
}
