using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NLote
    {
        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(  string este, string idParcela, string medidas, string norte , string oeste, string sur, string ubicacion,string estatus)
        {
            DLote Obj = new DLote();
            
            Obj.este = este;
            Obj.idParcela= idParcela;
            Obj.medidas = medidas;
            Obj.norte = norte;
            Obj.oeste = oeste;
            Obj.sur = sur;
            Obj.ubicacion = ubicacion;
            Obj.estatus = estatus;
            return Obj.Insertar();
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idLote, string este, string idParcela, string medidas, string norte, string oeste, string sur, string ubicacion,string estatus)
        {
            DLote Obj = new DLote();
            Obj.este = este;
            Obj.idParcela = idParcela;
            Obj.medidas = medidas;
            Obj.norte = norte;
            Obj.oeste = oeste;
            Obj.sur = sur;
            Obj.ubicacion = ubicacion;
            Obj.idlote = idLote;
            Obj.estatus = estatus;
            return Obj.Editar();
        }

        //Método Eliminar que llama al método Eliminar de la clase DLote
        //de la CapaDatos
        public static string Eliminar(int idLote)
        {
            DLote Obj = new DLote();
            Obj.idlote = idLote;
            return Obj.Eliminar();
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DLote().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArticulo de la CapaDatos

        public static DataTable Stock_Lotes()
        {
            return new DLote().Stock_Lotes();
        }
    }
}
