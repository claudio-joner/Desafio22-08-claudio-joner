using MiprimeraApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiprimeraApi.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString = "Server=DESKTOP-6KIGGOG\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";
        

        public static bool CargarVenta(List<ProductoVendido> listaProductoVendidos, int id)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                     
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.Connection.Open();

                    Venta venta = new Venta();
                    int largo = listaProductoVendidos.Count;
                 
                    sqlCommand.CommandText = "INSERT INTO Venta (Comentarios) VALUES ( @comentarios );";
                    SqlParameter comentariosParameter = new SqlParameter("comentarios", SqlDbType.VarChar) { Value = Convert.ToString(listaProductoVendidos) };
                    int recordsAffected = sqlCommand.ExecuteNonQuery();

                    foreach (ProductoVendido elemento in listaProductoVendidos)
                    {
                        ProductoVendidoHandler.AgregarProductoVendido(elemento);
                    }

                    


                    sqlCommand.Connection.Close();
                    if (recordsAffected != 1)

                    {

                        return false;

                    }

                    else

                    {

                        return true;

                    }
                }

                sqlConnection.Close();
            }

            
        }

    }
}
