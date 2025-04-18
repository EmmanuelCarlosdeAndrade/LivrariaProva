using Microsoft.Data.SqlClient;

namespace BibliotecaConsoleApp.DAO
{
    public class Database
    {
        // Aqui vai sua string de conexão com o SQL Server
        private const string connectionString = @"Server=localhost\SQLServer2022;Database=BibliotecaDB;Trusted_Connection=True;";

        // Método para obter a conexão com o banco
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
