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
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace CapaPresentacion
{
    public partial class frmLotes : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmLotes _Instancia;


        public void setParcela(string idcategoria, string nombre)
        {
            this.txtIdParcela.Text = idcategoria;
            this.txtParcela.Text = nombre;
        }
        public frmLotes()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdLote, "Ingrese el Código del Lote");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Imagen del Lote");
            this.ttMensaje.SetToolTip(this.txtParcela, "Seleccione la Parcela del Lote");
            this.ttMensaje.SetToolTip(this.cbIdestatus, "Seleccione el estatus del Lote");

            this.txtIdParcela.Visible = false;
            this.txtParcela.ReadOnly = true;
            this.LlenarComboPresentacion();


        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Inmobiliario", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Inmobiliario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNorte.Text = string.Empty;
            this.txtmedidas.Text = string.Empty;
            this.txtUbicacion.Text = string.Empty;
            this.txtIdParcela.Text = string.Empty;
            this.txtParcela.Text = string.Empty;
            this.txtIdLote.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
            this.txtOeste.Text = string.Empty;
            this.txtSur.Text = string.Empty;
            this.txtEste.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNorte.ReadOnly = !valor;
            this.txtmedidas.ReadOnly = !valor;
            this.txtUbicacion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdestatus.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdLote.ReadOnly = !valor;
            this.txtOeste.ReadOnly = !valor;
            this.txtSur.ReadOnly = !valor;
            this.txtEste.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
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
            //this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.ultraGrid1.DataSource = NLote.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            //this.dataListado.DataSource = NLote.Mostrar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboPresentacion()
        {
            //cbIdestatus.DataSource = NPresentacion.Mostrar();
            //cbIdestatus.ValueMember = "idestatus";
            //cbIdestatus.DisplayMember = "nombre";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
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
            //this.txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtSur.Text == string.Empty ||
                    this.txtEste.Text == string.Empty ||
                    this.txtOeste.Text == string.Empty ||
                    this.txtNorte.Text == string.Empty ||
                    this.txtParcela.Text == string.Empty ||
                    this.txtmedidas.Text == string.Empty ||
                     this.txtUbicacion.Text == string.Empty
                    )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtSur, "Ingrese un Valor");
                    errorIcono.SetError(txtEste, "Ingrese un Valor");
                    errorIcono.SetError(txtOeste, "Ingrese un Valor");
                    errorIcono.SetError(txtNorte, "Ingrese un Valor");
                    errorIcono.SetError(txtParcela, "Ingrese un Valor");
                    errorIcono.SetError(txtmedidas, "Ingrese un Valor");
                    errorIcono.SetError(txtUbicacion, "Ingrese un Valor");
                }
                else
                {
                    if (this.pxImagen.Image != null)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        byte[] imagen = ms.GetBuffer();
                    }


                    if (this.IsNuevo)
                    {
                        rpta = NLote.Insertar(
                            this.txtEste.Text.Trim(),
                             this.txtIdParcela.Text.Trim(),
                            this.txtmedidas.Text.Trim(),
                             this.txtNorte.Text.Trim(),
                             this.txtOeste.Text.Trim(),
                             this.txtSur.Text.Trim(),
                            this.txtUbicacion.Text.Trim(), this.cbIdestatus.Text);
                    }
                    else
                    {
                        rpta = NLote.Editar(Convert.ToInt32(this.txtIdLote.Text.Trim()),
                             this.txtEste.Text.Trim(),
                            this.txtIdParcela.Text.Trim(),
                            this.txtmedidas.Text.Trim(),
                             this.txtNorte.Text.Trim(),
                             this.txtOeste.Text.Trim(),
                             this.txtSur.Text.Trim(),
                            this.txtUbicacion.Text.Trim(), this.cbIdestatus.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
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

                    this.IsNuevo = false;
                    this.IsEditar = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdLote.Text.Equals(""))
            {
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdLote.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdLote"].Value);
            this.txtNorte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["norte"].Value);
            this.txtSur.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sur"].Value);
            this.txtEste.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["este"].Value);
            this.txtOeste.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["oeste"].Value);
            this.txtmedidas.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["medidas"].Value);
            this.txtUbicacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ubicacion"].Value);
            this.txtIdParcela.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idParcela"].Value);
            this.txtParcela.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreParcela"].Value);

            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdParcela.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idParcela"].Value);
            this.txtParcela.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Parcela"].Value);
            this.cbIdestatus.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["estatus"].Value);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema Inmobiliario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string IdParcela;
                    string Rpta = "";


                    UltraGridRow activeRow = this.ultraGrid1.ActiveRow;

                    if (activeRow is UltraGridGroupByRow)
                        // The activeRow can be a group-by row
                        MessageBox.Show("Agrupado Activado, debe desagrupar para realizar la operación.", "Sistema Inmobiliario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Console.WriteLine("Group by row activated. Description: " + activeRow.Description);
                    else
                    {


                        foreach (UltraGridRow row in this.ultraGrid1.Selected.Rows)
                        {

                            IdParcela = Convert.ToString(row.Cells["IdLote"].Value);
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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaParcela_Lote form = new frmVistaParcela_Lote();
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //FrmReporteArticulos frm = new FrmReporteArticulos();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
            UltraGridExcelExporter ultraGridExcelExporter1 = new UltraGridExcelExporter();
            string Archivo = "Lotes.xls";
            ultraGridExcelExporter1.Export(ultraGrid1, Archivo);
            System.Diagnostics.Process.Start(Archivo);
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            UltraGridRow activeRow = this.ultraGrid1.ActiveRow;

            if (activeRow is UltraGridGroupByRow)
                // The activeRow can be a group-by row
                Console.WriteLine("Group by row activated. Description: " + activeRow.Description);
            else
            {
                this.txtIdLote.Text = Convert.ToString(activeRow.Cells["IdLote"].Value);
                this.txtNorte.Text = Convert.ToString(activeRow.Cells["norte"].Value);
                this.txtSur.Text = Convert.ToString(activeRow.Cells["sur"].Value);
                this.txtEste.Text = Convert.ToString(activeRow.Cells["este"].Value);
                this.txtOeste.Text = Convert.ToString(activeRow.Cells["oeste"].Value);
                this.txtmedidas.Text = Convert.ToString(activeRow.Cells["medidas"].Value);
                this.txtUbicacion.Text = Convert.ToString(activeRow.Cells["ubicacion"].Value);
                this.txtIdParcela.Text = Convert.ToString(activeRow.Cells["idParcela"].Value);
                this.txtParcela.Text = Convert.ToString(activeRow.Cells["NombreParcela"].Value);

                if (!String.IsNullOrEmpty(activeRow.Cells["imagen"].Value.ToString()))
                {
                    byte[] imagenBuffer = (byte[])activeRow.Cells["imagen"].Value;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

                    this.pxImagen.Image = Image.FromStream(ms);
                    this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                }
               this.cbIdestatus.SelectedValue = Convert.ToString(activeRow.Cells["estatus"].Value);

                //estatus falta
                this.tabControl1.SelectedIndex = 1;
            }
        }

        public static frmLotes GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmLotes();
            }
            return _Instancia;
        }

    }
}
