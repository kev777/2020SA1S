using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfRepartidor.clases
{
    public class repartidor
    {

        conexion conec = new conexion();
        SqlConnection con;
        string salida;

        #region ejecutar

        public string ejecuta()
        {
            con = conec.getConexion();
            con.Open();

            try
            {

                SqlCommand command = new SqlCommand("sp_cliente", con);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@pp_tipo", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@pp_usuario", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@pp_pass", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@pp_opcion", SqlDbType.Int).Value = 2;
                command.Parameters.Add("@pp_salida", SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@pp_codigo", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                salida = Convert.ToString(command.Parameters["@pp_codigo"].Value);

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                con.Close();
            }

            return salida;

        }

        #endregion

    }
}