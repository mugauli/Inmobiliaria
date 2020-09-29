using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NParcela
    {
        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string idParcela, string nombre, string colonia, string cp, string delMunc,string observaciones)
        {
            DParcela Obj = new DParcela();
            Obj.IdParcela = idParcela;
            Obj.Nombre = nombre;
            Obj.Colonia = colonia;
            Obj.Cp = cp;
            Obj.DelMunc = delMunc;
            Obj.Observaciones = observaciones;
           

            return Obj.Insertar();
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(string   IdParcela, string nombre, string descripcion, string cp, string delMunc, string observaciones)
        {
            DParcela Obj = new DParcela();
            Obj.IdParcela = IdParcela;
            Obj.Nombre = nombre;
            Obj.Colonia = descripcion;
            Obj.Cp = cp;
            Obj.DelMunc = delMunc;
            Obj.Observaciones = observaciones;
            Obj.IdParcela = IdParcela;
            return Obj.Editar();
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(string idParcela)
        {
            DParcela Obj = new DParcela();
            Obj.IdParcela = idParcela;
            return Obj.Eliminar();
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DParcela().Mostrar();
        }

        public static DataTable Stock_Parcelas()
        {
            return new DParcela().Stock_Parcelas();
        }

        public static object BuscarNombre(string text)
        {
            DParcela Obj = new DParcela();
            
            return Obj.BuscarNombre(text);
        }
    }
}
