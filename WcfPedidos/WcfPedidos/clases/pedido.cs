using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfPedidos.clases
{
    public class pedido
    {

        conexion conec = new conexion();
        SqlConnection con;
        int salida;

        #region login
        public int ejecuta(object monto, object descripcion)
        {
            con = conec.getConexion();
            con.Open();

            try
            {

                SqlCommand command = new SqlCommand("sp_pedidos", con);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@pp_monto", SqlDbType.Decimal).Value = monto;
                command.Parameters.Add("@pp_descripcion", SqlDbType.VarChar).Value = descripcion;
                command.Parameters.Add("@pp_opcion", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@pp_salida", SqlDbType.Int).Direction = ParameterDirection.Output;
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