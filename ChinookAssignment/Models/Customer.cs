namespace ChinookAssignment
{
    /// <summary>
    /// A class that contains information about a specific customer. POCO class. 
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSurename { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone{ get; set; }
        public string Email { get; set; }

    }
}