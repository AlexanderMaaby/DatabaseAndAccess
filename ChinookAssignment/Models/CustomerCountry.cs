using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAssignment.Models
{
    /// <summary>
    /// A class that contains information about how many customers exist in the database for each existing country. POCO class. 
    /// </summary>
    public class CustomerCountry
    {
        public string Country { get; set; }
        public int Count { get; set; }
    }
}
