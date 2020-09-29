using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DParcela
    {
        public string IdParcela { get; set; }

        public string Nombre { get; set; }

        public string Cp { get; set; }

        public string Colonia { get; set; }

        public string DelMunc { get; set; }

        public string Observaciones { get; set; }

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
                SqlCmd.CommandText = "spinsertar_Parcela";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                       new SqlParameter("@idParcela", SqlDbType.VarChar, 10),
                new SqlParameter("@nombre", SqlDbType.VarChar, 50),
                new SqlParameter("@cp", SqlDbType.VarChar, 13),
                new SqlParameter("@colonia", SqlDbType.VarChar, 10),
                new SqlParameter("@delMunc", SqlDbType.VarChar, 10),
                new SqlParameter("@observaciones", SqlDbType.VarChar, 200)};

                parameters[0].Value = this.IdParcela;
                parameters[1].Value = this.Nombre;
                parameters[2].Value = this.Cp;
                parameters[3].Value = this.Colonia;
                parameters[4].Value = this.DelMunc;
                parameters[5].Value = this.Observaciones;


                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando
                 
                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

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
                SqlCmd.CommandText = "speditar_Parcela";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                       new SqlParameter("@idParcela", SqlDbType.VarChar, 10),
                new SqlParameter("@nombre", SqlDbType.VarChar, 50),
                new SqlParameter("@cp", SqlDbType.VarChar, 13),
                new SqlParameter("@colonia", SqlDbType.VarChar, 10),
                new SqlParameter("@delMunc", SqlDbType.VarChar, 10),
                new SqlParameter("@observaciones", SqlDbType.VarChar, 200)};

                parameters[0].Value = this.IdParcela;
                parameters[1].Value = this.Nombre;
                parameters[2].Value = this.Cp;
                parameters[3].Value = this.Colonia;
                parameters[4].Value = this.DelMunc;
                parameters[5].Value = this.Observaciones;


                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

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
                        new SqlParameter("@idParcela", SqlDbType.VarChar, 10)
                          };


                parameters[0].Value = this.IdParcela;
                


                SqlCmd.Parameters.AddRange(parameters);

                //Ejecutamos nuestro comando 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Eliminó el Registro"; 
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

        public DataTable Stock_Parcelas()
        {
            DataTable DtResultado = new DataTable("parcela");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_parcelas";
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
            DataTable DtResultado = new DataTable("parcela");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_parcelas";
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

        public DataTable BuscarNombre(string  nombreParcela)
        {
            DataTable DtResultado = new DataTable("Parcela");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_parcela_Nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = nombreParcela;
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

    }
}