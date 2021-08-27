using System.Data.SqlClient;

namespace ChinookAssignment
{
    /// <summary>
    /// Class to help with getting data from the SqlDataReader in a safe way, while keeping the CustomerRepository clean.
    /// </summary>
    public static class QuerySanitizer
    {
        /// <summary>
        /// Get a string from a specific column in the SqlDataReader, or an empty string if it happens to be null.
        /// </summary>
        /// <param name="reader">The instance of SqlDataReader that contains the data.</param>
        /// <param name="colIndex">The index that should be retrieved.</param>
        /// <returns>The string from the index, or an empty string if the index returns null.</returns>
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
