using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        public int Iddetalle_venta { get; set; }

        public int Idventa { get; set; }

        public string IdParcela { get; set; }

        public int IdLote { get; set; }

        public string Medidas { get; set; }

        public string Ubicacion { get; set; }

        public float Precio_venta { get; set; }

        public float Enganche { get; set; }

        public float Anticipo { get; set; }

        public float Saldo { get; set; }

        public DateTime Fecharegistro { get; set; }

        public int NumMens { get; set; }

        //Constructores
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int iddetalle_venta, int idventa, String idParcela, int idLote, String medidas, String ubicacion, float precio_venta, float enganche, float anticipo, float saldo, DateTime fecharegistro, int numMens)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = Idventa;
            this.IdParcela = idParcela;
            this.IdLote = idLote;
            this.Medidas = medidas;
            this.Ubicacion = ubicacion;
            this.Precio_venta = precio_venta;
            this.Enganche = enganche;
            this.Anticipo = anticipo;
            this.Saldo = saldo;
            this.Fecharegistro = fecharegistro;
            this.NumMens = numMens;

        }

        //Método Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Venta = new SqlParameter();
                ParIddetalle_Venta.ParameterName = "@iddetalle_venta";
                ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Venta);

                SqlParameter[] parameters = {
                new SqlParameter("@idventa", SqlDbType.Int, 4),
                new SqlParameter("@idParcela", SqlDbType.VarChar, 10),
                new SqlParameter("@idLote", SqlDbType.Int, 4),
                new SqlParameter("@medidas", SqlDbType.VarChar, 50),
                new SqlParameter("@ubicacion", SqlDbType.VarChar, 300),
                new SqlParameter("@precio_venta", SqlDbType.Money, 8),
                new SqlParameter("@enganche", SqlDbType.Money, 8),
                new SqlParameter("@anticipo", SqlDbType.Money, 8),
                new SqlParameter("@saldo", SqlDbType.Money, 8),
                new SqlParameter("@fecharegistro", SqlDbType.DateTime, 8),
                new SqlParameter("@numMens", SqlDbType.Int, 4)};

                
                parameters[0].Value = Idventa;
                parameters[1].Value = IdParcela;
                parameters[2].Value = IdLote;
                parameters[3].Value = Medidas;
                parameters[4].Value = Ubicacion;
                parameters[5].Value = Precio_venta;
                parameters[6].Value = Enganche;
                parameters[7].Value = Anticipo;
                parameters[8].Value = Saldo;
                parameters[9].Value = Fecharegistro;
                parameters[10].Value = NumMens;

                SqlCmd.Parameters.AddRange(parameters);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }

        public string InsertarMensualidades(DDetalle_Venta Detalle_Venta,
           ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_Mensualidades";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                new SqlParameter("@idventa", SqlDbType.Int, 4),
                new SqlParameter("@idParcela", SqlDbType.VarChar, 10),
                new SqlParameter("@idLote", SqlDbType.Int, 4),
                new SqlParameter("@monto", SqlDbType.Money, 8),
                new SqlParameter("@fecha", SqlDbType.DateTime, 8),
                new SqlParameter("@numMens", SqlDbType.Int, 4)};


                parameters[0].Value = Idventa;
                parameters[1].Value = IdParcela;
                parameters[2].Value = IdLote;
                parameters[3].Value = Saldo;
                parameters[4].Value = Fecharegistro;
                parameters[5].Value = NumMens;

                SqlCmd.Parameters.AddRange(parameters);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }

    }
}
