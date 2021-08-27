using System.Data.SqlClient;

namespace ChinookAssignment
{
    public class ConnectionHelper
    {
        /// <summary>
        /// Method that builds a connection string for connecting to the database.
        /// </summary>
        /// <returns>A connection string.</returns>
        public static string GetConnectionstring()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "ND-5CG91961SW\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
