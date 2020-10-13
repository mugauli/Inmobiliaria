using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPago
    {
        /// <summary>
        /// Obtener pagos pendientes por venta
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="idParcela"></param>
        /// <param name="idLote"></param>
        /// <returns></returns>
        public static DataTable BurcarPendiente(int idVenta)
        {
            DPago Obj = new DPago();

            return Obj.BuscarPendientesVenta(idVenta);

        }

        /// <summary>
        /// Obtener pagos pendientes por parcela y lote
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="idParcela"></param>
        /// <param name="idLote"></param>
        /// <returns></returns>
        public static DataTable BurcarPendiente(string idParcela, int idLote)
        {
            DPago Obj = new DPago();


            return Obj.BuscarPendientesVenta(idParcela, idLote);
        }
    }
}
