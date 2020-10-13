using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPago
    {
        public int _IdVenta{ get; set; }
        public int _NumeroPago{ get; set; }
        public int _IdLote{ get; set; }
        public string _idParcela{ get; set; }
        public DateTime _Fecha_Pago{ get; set; }
        public float _Monto_Pago{ get; set; }
        public float _Monto_Mora{ get; set; }


              
        public DataTable BuscarPendientesVenta(int idVenta)
        {
            DataTable DtResultado = new DataTable("Pagos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_pago_pendiente_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@id_venta";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = idVenta;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable BuscarPendientesVenta(string idParcela, int idLote)
        {
            throw new NotImplementedException();
        }
    }
}
