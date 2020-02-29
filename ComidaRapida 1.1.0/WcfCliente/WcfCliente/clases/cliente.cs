using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfCliente.clases
{
    public class cliente
    {
        conexion conec = new conexion();
        SqlConnection con;
        int salida;

        #region login
        public int ejecuta(object usuario, object pass)
        {
            con = conec.getConexion();
            con.Open();

            try
            {

                SqlCommand command = new SqlCommand("sp_cliente", con);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@pp_tipo", SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@pp_usuario", SqlDbType.VarChar).Value = usuario;
                command.Parameters.Add("@pp_pass", SqlDbType.VarChar).Value = pass;
                command.Parameters.Add("@pp_opcion", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@pp_salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.Add("@pp_codigo", SqlDbType.VarChar).Value = DBNull.Value;
                command.ExecuteNonQuery();
                salida = Convert.ToInt32(command.Parameters["@pp_salida"].Value);

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