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
using CapaPresentacion.Reportes;

namespace CapaPresentacion
{
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;
        private float totalSaldo = 0; 

        private float totalPagado = 0;

        private static FrmVenta _instancia;

        public static FrmVenta GetInstancia()
        {
            if (_instancia==null)
            {
                _instancia = new FrmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idcliente,string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setLote (string idParcela,string NombreParcela,string idLote,string medidas,string ubicacion)
        {
            this.txtIdParcela.Text = idParcela;
            this.txtParcela.Text = NombreParcela;
            this.txtlote.Text = idLote;
            this.txtmedidas.Text = medidas;
            this.txtUbicacion.Text = ubicacion;
            //this.txtStock_Actual.Text = ubicacion;
            //this.dtFecha_Vencimiento.Value = fecha_vencimiento;
        }

        public FrmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente,"Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese una serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese un número del comprobante");
            this.ttMensaje.SetToolTip(this.txtParcela, "Ingrese la Cantidad del Artículo a Vender");
            this.ttMensaje.SetToolTip(this.txtlote, "Seleccione un Artículo");
            this.txtIdcliente.Visible = false;
            //this.txtIdarticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtlote.ReadOnly = true;
            this.dtFecha_Vencimiento.Enabled = false;
            this.txtPrecioVenta.ReadOnly = true;
            //this.txtStock_Actual.ReadOnly = true;
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.lblTotal_Saldo.Text = "0,0";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtUbicacion.Text = string.Empty;
            this.txtlote.Text = string.Empty;
            this.txtmedidas.Text = string.Empty;
            this.txtParcela.Text = string.Empty;
            this.txtIdParcela.Text = string.Empty;
            this.txtPrecioVenta.Text = "0.00";
            this.txtEnganche.Text = "0.00";
            this.txtAnticipo.Text = "0.00";
            this.txtMens.Text = "0";
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            //this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtParcela.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtEnganche.ReadOnly = !valor;
            //this.txtStock_Actual.ReadOnly = !valor;
            this.txtAnticipo.ReadOnly = !valor;
            this.dtFecha_Vencimiento.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
           // this.dataListado.Columns[0].Visible = false;
           // this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdventa.Text);

        }
        private void crearTabla()
        {// idParcela, NombreParcela, idLote, medidas, ubicacion
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("IdParcela", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("NombreParcela", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("IdLote", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Medidas", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Ubicacion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Enganche", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Anticipo", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Saldo", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("fecharegistro", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("NumMens", System.Type.GetType("System.Int32"));
            
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
            

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Venta vista = new FrmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaLote_Venta vista = new FrmVistaLote_Venta();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente la venta");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            //this.lblTotal_Saldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["saldo"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtSerie.Text == string.Empty
                    || this.txtCorrelativo.Text == string.Empty )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    //errorIcono.SetError(txtIgv, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdcliente.Text),Idtrabajador,
                            dtFecha.Value, cbTipo_Comprobante.Text, txtSerie.Text, txtCorrelativo.Text,
                            0, dtDetalle);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.txtlote.Text == string.Empty 
                    || this.txtParcela.Text == string.Empty
                    || this.txtAnticipo.Text == string.Empty
                    || this.txtEnganche.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtlote, "Ingrese un Valor");
                    errorIcono.SetError(txtParcela, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                    errorIcono.SetError(txtAnticipo, "Ingrese un Valor");
                    errorIcono.SetError(txtEnganche, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idLote"])==Convert.ToInt32(this.txtlote.Text) && row["IdParcela"].ToString() == this.txtIdParcela.Text.Trim())
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el lote registrado en el detalle.");
                        }
                    }

                    if (registrar)
                    {
                        //float subTotal=float.Parse(this.txtPrecioVenta.Text)-float.Parse(this.txtAnticipo.Text);
                        float PrecioVenta = float.Parse(txtPrecioVenta.Text.Trim());
                        float Enganche  = float.Parse(txtEnganche.Text.Trim());
                        float Anticipo = float.Parse(txtAnticipo.Text.Trim());
                        float Saldo = PrecioVenta - Enganche - Anticipo;
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdParcela"] = txtIdParcela.Text.Trim();
                        row["NombreParcela"] = txtParcela.Text.Trim();
                        row["IdLote"] = txtlote.Text.Trim();
                        row["Medidas"] = txtmedidas.Text.Trim();
                        row["Ubicacion"] = txtUbicacion.Text.Trim();
                        row["PrecioVenta"] = PrecioVenta;
                        row["Enganche"] = Enganche;
                        row["Anticipo"] = Anticipo;
                        row["Saldo"] = Saldo;
                        row["fecharegistro"] = dtFecha_Vencimiento.Value;
                        row["NumMens"] = txtMens.Text.Trim();
                        //row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                        totalPagado = totalPagado + Enganche + Anticipo;
                        totalSaldo = totalSaldo + Saldo;
                        lblTotal_Pagado.Text=totalPagado.ToString("0,0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTotal_Saldo.Text = totalSaldo.ToString("0,0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                 
                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.totalPagado = this.totalPagado - float.Parse(row["Enganche"].ToString())-float.Parse(row["Anticipo"].ToString());
                this.totalSaldo = this.totalSaldo - float.Parse(row["Saldo"].ToString());
                //this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                lblTotal_Pagado.Text = totalPagado.ToString("0,0.00", System.Globalization.CultureInfo.InvariantCulture);
                lblTotal_Saldo.Text = totalSaldo.ToString("0,0.00", System.Globalization.CultureInfo.InvariantCulture);
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            
            FrmReporteParcelas frm = new FrmReporteParcelas();
            //frm.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteVentas frm = new Reportes.FrmReporteVentas();
            frm.Texto = Convert.ToString(dtFecha1.Value);
            frm.Texto2 = Convert.ToString(dtFecha2.Value);
            frm.ShowDialog();
        }

        private void btnMensualidades_Click(object sender, EventArgs e)
        {
            float PrecioVenta = float.Parse(txtPrecioVenta.Text.Trim());
            float Enganche = float.Parse(txtEnganche.Text.Trim());
            float Anticipo = float.Parse(txtAnticipo.Text.Trim());
            FrmMensualidades frm = new FrmMensualidades();
            frm.monto = PrecioVenta - Enganche - Anticipo;
            frm.mens = int.Parse(txtMens.Text.Trim());
            frm.ShowDialog();
        }

      
        private void txtAnticipo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
