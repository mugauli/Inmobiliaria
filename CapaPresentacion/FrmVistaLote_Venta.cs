using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FrmVistaLote_Venta : Form
    {
        public FrmVistaLote_Venta()
        {
            InitializeComponent();
        }


        //Método para ocultar columnas
        private void OcultarColumnas()
        {
           // this.dataListado.Columns[0].Visible = false;
           // this.dataListado.Columns[1].Visible = false;
        }

        //Método BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = NLote.LotesxParcela(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            this.MostrarArticulo_Venta_Codigo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             
                this.MostrarArticulo_Venta_Codigo();
             
                //this.MostrarArticulo_Venta_Nombre();
             
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            string idParcela, NombreParcela, idLote, medidas, ubicacion;

            idParcela = Convert.ToString(this.dataListado.CurrentRow.Cells["idParcela"].Value);
            NombreParcela = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreParcela"].Value);
            idLote = Convert.ToString(this.dataListado.CurrentRow.Cells["idLote"].Value);
            medidas = Convert.ToString(this.dataListado.CurrentRow.Cells["medidas"].Value);
            ubicacion = Convert.ToString(this.dataListado.CurrentRow.Cells["ubicacion"].Value);
             form.setLote(idParcela, NombreParcela, idLote, medidas, ubicacion);
            this.Hide();
        }
    }
}
