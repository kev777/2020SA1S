using System.Data.SqlClient;
/*
 *Clase que se encarga de la conexión hacia la base de datos.
 * Contiene un método que realiza la conexión y una función que retorna el objeto SqlConnection.
 * */
namespace WcfPedidos.clases
{
    public class conexion
    {
        SqlConnection con;

        public conexion()
        {
            con = new SqlConnection();
            //con.ConnectionString = "Data Source=.;Initial Catalog=CONTRATACION;Integrated Security=True";
            con.ConnectionString = "Data Source=DELEON0;Initial Catalog=software;Integrated Security=True";
        }

        public SqlConnection getConexion()
        {
            return con;
        }

    }
}