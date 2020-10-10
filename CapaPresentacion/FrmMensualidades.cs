using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMensualidades : Form
    {
        public float monto { get; set; }
        public int mens { get; set; }
        public FrmMensualidades()
        {
            InitializeComponent();
            monto = 0;
            mens = 0; 

            //txtMes.BindingContextChanged() +=this.Number_Validating;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string money = txtmonto.Text.Trim();
            int meses = 0;
            float f;
            if (float.TryParse(money, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-MX"), out f) && int.TryParse(txtMes.Text, out meses))
            {
                // valid
                dataListado.DataSource = NVenta.calculo_Mensualidades(f, meses, dtFecha.Value);
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            else
            {
                MessageBox.Show(txtmonto.Text + " debe ser numérico.");
            }
        }

      

        private void txtMes_Validated(object sender, EventArgs e)
        {
            int val;
            TextBox tb = sender as TextBox;
            if (!int.TryParse(tb.Text, out val))
            {
                MessageBox.Show(tb.Tag + " debe ser numérico.");
                tb.Undo();
                
            }
        }


        private void btnExporta_Click(object sender, EventArgs e)
        {
            
            string Archivo = "Mensualidades.xls";
            ultraGridExcelExporter1.Export(dataListado, Archivo);
            System.Diagnostics.Process.Start(Archivo);
        }

        private void FrmMensualidades_Load(object sender, EventArgs e)
        {
            txtMes.Text = mens.ToString();
            txtmonto.Text = monto.ToString();
        }
    }
}
