using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPago : Form
    {
        public frmPago()
        {
            InitializeComponent();
        }


        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtIdventa.Text, out int idVenta_int))
                this.dataListadoPagoPendiente.DataSource = NPago.BurcarPendiente(idVenta_int);
            else MessageBox.Show("Error: Cambo venta no debe estar vacio");
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscarParcelaLote_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtlote.Text, out int idLote_int) && !string.IsNullOrEmpty(txtIdParcela.Text))
                this.dataListadoPagoPendiente.DataSource = NPago.BurcarPendiente(txtIdParcela.Text, idLote_int);
            else MessageBox.Show("Error: Cambo Parcela y Lote no deben estar vacios");
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListadoPagoPendiente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pendiente_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
