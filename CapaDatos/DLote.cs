using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DLote
    {
        public int idlote { get; set; }

        public string norte { get; set; }

        public string sur { get; set; }

        public string este { get; set; }

        public string oeste { get; set; }

        public string medidas { get; set; }

        public string ubicacion { get; set; }

        public byte[] imagen { get; set; }

        public string idParcela { get; set; }

        public string estatus { get; set; }


        public string Editar()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_Lote";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                new SqlParameter("@idlote", SqlDbType.Int, 4),
                new SqlParameter("@norte", SqlDbType.VarChar, 50),
                new SqlParameter("@sur", SqlDbType.VarChar, 50),
                new SqlParameter("@este", SqlDbType.VarChar, 50),
                new SqlParameter("@oeste", SqlDbType.VarChar, 50),
                new SqlParameter("@medidas", SqlDbType.VarChar, 50),
                new SqlParameter("@ubicacion", SqlDbType.VarChar, 300),
                new SqlParameter("@imagen", SqlDbType.Image, 16),
                new SqlParameter("@idParcela", SqlDbType.VarChar, 15),
                new SqlParameter("@estatus", SqlDbType.VarChar, 15)};

                parameters[0].Value = this.idlote;
                parameters[1].Value = this.norte;
                parameters[2].Value = this.sur;
                parameters[3].Value = this.este;
                parameters[4].Value = this.oeste;
                parameters[5].Value = this.medidas;
                parameters[6].Value = this.ubicacion;
                parameters[7].Value = this.imagen;
                parameters[8].Value = this.idParcela;
                parameters[9].Value = this.estatus;

                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro del Lote";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Insertar()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_Lote";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = { 
                new SqlParameter("@norte", SqlDbType.VarChar, 50),
                new SqlParameter("@sur", SqlDbType.VarChar, 50),
                new SqlParameter("@este", SqlDbType.VarChar, 50),
                new SqlParameter("@oeste", SqlDbType.VarChar, 50),
                new SqlParameter("@medidas", SqlDbType.VarChar, 50),
                new SqlParameter("@ubicacion", SqlDbType.VarChar, 300),
                new SqlParameter("@imagen", SqlDbType.Image, 16),
                new SqlParameter("@idParcela", SqlDbType.VarChar, 15),
                new SqlParameter("@estatus", SqlDbType.VarChar, 15)};
                 
                parameters[0].Value = this.norte;
                parameters[1].Value = this.sur;
                parameters[2].Value = this.este;
                parameters[3].Value = this.oeste;
                parameters[4].Value = this.medidas;
                parameters[5].Value = this.ubicacion;
                parameters[6].Value = this.imagen;
                parameters[7].Value = this.idParcela;
                parameters[8].Value = this.estatus;

                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro del Lote";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public DataTable Stock_Lotes()
        {
            DataTable DtResultado = new DataTable("lote");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_Lotes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("lote");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Lotes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public string Eliminar()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_Parcela";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                new SqlParameter("@idlote", SqlDbType.Int, 4) 
                };

                parameters[0].Value = this.idlote; 

                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se elimino el Registro del Lote";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


    }
}



