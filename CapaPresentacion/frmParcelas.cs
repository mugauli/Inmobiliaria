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
using Infragistics.Win.UltraWinGrid;

namespace CapaPresentacion
{
    public partial class frmParcelas : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        private static frmParcelas _Instancia;

        public frmParcelas()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Parcela");

        }
        public static frmParcelas GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmParcelas();
            }
            return _Instancia;
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistema Inmobiliario",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Inmobiliario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtObservaciones.Text = string.Empty;
            this.txtIdParcela.Text = string.Empty;
            this.txtDelMunc.Text = string.Empty;
            this.txtCP.Text = string.Empty;
            this.txtColonia.Text = string.Empty;
            this.txtIdParcela.Text = string.Empty;
            
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        { 
            this.txtNombre.ReadOnly = !valor;  
            this.txtObservaciones.ReadOnly = !valor;
            
            this.txtDelMunc.ReadOnly = !valor;
            this.txtCP.ReadOnly = !valor;
            this.txtColonia.ReadOnly = !valor; 
            
        }
        
        //Habilitar los botones
        private void Botones()
        {
            if(this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
           // this.dataListado.DataSource = NParcela.Mostrar();
            this.ultraGrid1.DataSource = NParcela.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            //this.dataListado.DataSource = NParcela.BuscarNombre(this.txtBuscar.Text);
            this.ultraGrid1.DataSource = NParcela.BuscarNombre(this.txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        


        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.txtIdParcela.ReadOnly = true;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtIdParcela.Focus();
            this.txtIdParcela.ReadOnly = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta="";
                if (this.txtNombre.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre,"Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta=NParcela.Insertar(this.txtIdParcela.Text.Trim(),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtColonia.Text.Trim(), 
                            this.txtCP.Text.Trim(),
                            this.txtDelMunc.Text.Trim(),
                            this.txtObservaciones.Text.Trim());

                    }
                    else
                    {
                        rpta= NParcela.Editar(this.txtIdParcela.Text.Trim(),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtColonia.Text.Trim(),
                            this.txtCP.Text.Trim(),
                            this.txtDelMunc.Text.Trim(),
                            this.txtObservaciones.Text.Trim());
                    }
                    
                    if(rpta.Equals("OK"))
                    {
                        if(this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo=false;
                    this.IsEditar=false;
                    this.Botones();
                    this.Limpiar();
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
            UltraGridRow activeRow = this.ultraGrid1.ActiveRow;

            if (activeRow is UltraGridGroupByRow)
                // The activeRow can be a group-by row
                Console.WriteLine("Group by row activated. Description: " + activeRow.Description);
            else
            {
                this.txtIdParcela.Text = Convert.ToString(activeRow.Cells["IdParcela"].Value);
                this.txtNombre.Text = Convert.ToString(activeRow.Cells["Nombre"].Value);
                this.txtColonia.Text = Convert.ToString(activeRow.Cells["Colonia"].Value);
                this.txtCP.Text = Convert.ToString(activeRow.Cells["CP"].Value);
                this.txtDelMunc.Text = Convert.ToString(activeRow.Cells["DelMunc"].Value);
                this.txtObservaciones.Text = Convert.ToString(activeRow.Cells["Observaciones"].Value);
                //estatus falta
                this.tabControl1.SelectedIndex = 1;
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtIdParcela.Text.Equals(""))
            {
                this.txtIdParcela.ReadOnly = true;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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
            if(e.ColumnIndex==dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros","Sistema Inmobiliario",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                 
                if (Opcion == DialogResult.OK)
                {
                    string IdParcela;
                    string Rpta = "";


                    UltraGridRow activeRow = this.ultraGrid1.ActiveRow;

                    if (activeRow is UltraGridGroupByRow)
                        // The activeRow can be a group-by row
                        MessageBox.Show("Agrupado Activado, debe desagrupar para realizar la operación.", "Sistema Inmobiliario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {


                        foreach (UltraGridRow row in this.ultraGrid1.Selected.Rows)
                        {

                            IdParcela = Convert.ToString(row.Cells["IdParcela"].Value);
                            Rpta = NParcela.Eliminar(IdParcela);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }


                        }
                        this.Mostrar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Reportes.FrmReporteParcelas frm = new Reportes.FrmReporteParcelas();
            ////frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
            string Archivo = "Parcelas.xls";
            ultraGridExcelExporter1.Export(ultraGrid1, Archivo);
            System.Diagnostics.Process.Start(Archivo);
        }

        private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            UltraGridRow activeRow = this.ultraGrid1.ActiveRow;

            if (activeRow is UltraGridGroupByRow)
                // The activeRow can be a group-by row
                Console.WriteLine("Group by row activated. Description: " + activeRow.Description);
            else
            {
                this.txtIdParcela.Text = Convert.ToString(activeRow.Cells["IdParcela"].Value);
                this.txtNombre.Text = Convert.ToString(activeRow.Cells["Nombre"].Value);
                this.txtColonia.Text = Convert.ToString(activeRow.Cells["Colonia"].Value);
                this.txtCP.Text = Convert.ToString(activeRow.Cells["CP"].Value);
                this.txtDelMunc.Text = Convert.ToString(activeRow.Cells["DelMunc"].Value);
                this.txtObservaciones.Text = Convert.ToString(activeRow.Cells["Observaciones"].Value);
                //estatus falta
                this.tabControl1.SelectedIndex = 1;
            }
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
    }
}
