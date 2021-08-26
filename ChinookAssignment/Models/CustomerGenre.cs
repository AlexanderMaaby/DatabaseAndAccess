using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAssignment.Models
{
    /// <summary>
    /// A class that contains information about a specific customers favourite genre. POCO class. 
    /// </summary>
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public List<string> Genre { get; set; } = new List<string>();
        public int TotalTracks { get; set; }
    }
}
