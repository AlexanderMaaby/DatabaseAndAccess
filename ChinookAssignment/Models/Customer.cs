using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAssignment
{
    /// <summary>
    /// A class that contains information about a specific customer. POCO class. 
    /// </summary>
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSurename { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone{ get; set; }
        public string Email { get; set; }

    }
}