using System.Data.SqlClient;

namespace ChinookAssignment
{
    public class ConnectionHelper
    {
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
