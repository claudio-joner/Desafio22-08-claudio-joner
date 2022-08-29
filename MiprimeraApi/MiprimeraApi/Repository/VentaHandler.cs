using MiprimeraApi.Controllers.DTOS;
using MiprimeraApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiprimeraApi.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString = "Server=DESKTOP-6KIGGOG\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";
        

        public static bool CargarVenta(List<ProductoVendido> listaDeProductos)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                     
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.Connection.Open();
                    
                    string lista = Convert.ToString(listaDeProductos);
                    sqlCommand.CommandText = "INSERT INTO Venta (Comentarios) VALUES ( @comentarios );";
                    SqlParameter comentariosParameter = new SqlParameter("comentarios", SqlDbType.VarChar) { Value = lista };
                    int recordsAffected = sqlCommand.ExecuteNonQuery();

                    foreach(var productoVendido in listaDeProductos)
                    {
                        ProductoVendidoHandler.CrearProductoVendido(productoVendido);
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

        public static bool CrearVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.Connection.Open();
                 
                    sqlCommand.CommandText = "INSERT INTO Venta (Comentarios) VALUES ( @comentarios );";
                    SqlParameter comentariosParameter = new SqlParameter("comentarios", SqlDbType.VarChar) { Value = venta.Comentarios };
                    int recordsAffected = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Connection.Close();
                    
                    if (recordsAffected != 1)
                    {
                        return resultado = false ;
                    }

                    else
                    {
                        return resultado = true;
                    }
                }

                sqlConnection.Close();
            }
        }

        public static bool EliminarVenta(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queydelete = "DELETE FROM Venta WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queydelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();

                return resultado;
            }

            
    }

        public static bool ModificarVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE Venta SET Comentarios = @comentario ";

                SqlParameter comentarioParameter = new SqlParameter("comentario", SqlDbType.VarChar) { Value = venta.Comentarios };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {

                    sqlCommand.Parameters.Add(comentarioParameter);


                    int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta la sentencia sql

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();
            }

            return resultado;
        }

    }
}

    
     
    
