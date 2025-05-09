using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DatabaseAccess
    {
        protected SqlConnection connection;

        private string connectionString = "Data Source=LAPTOP-83RLDC0J;Initial Catalog = HOTEL; Integrated Security = True;";

        protected void OpenConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        protected void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
