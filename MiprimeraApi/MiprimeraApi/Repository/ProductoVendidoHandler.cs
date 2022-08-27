using MiprimeraApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiprimeraApi.Repository
{
   
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=DESKTOP-6KIGGOG\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";


        public static bool AgregarProductoVendido(ProductoVendido productoVendido)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO ProductoVendido " +
                    "(Stock, IdProducto , IdVenta) VALUES " +
                    "(@stock, @idproducto , @idventa );";

                SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.Int) { Value = productoVendido.Stock };
                SqlParameter IdProductoParameter = new SqlParameter("idproducto", SqlDbType.Int) { Value = productoVendido.IdProducto };
                SqlParameter idVentaParameter = new SqlParameter("idventa", SqlDbType.Int) { Value = productoVendido.IdVenta};

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(IdProductoParameter);
                    sqlCommand.Parameters.Add(idVentaParameter);
                    

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
