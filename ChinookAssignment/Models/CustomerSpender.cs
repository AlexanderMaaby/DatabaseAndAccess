﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAssignment.Models
{
    /// <summary>
    /// A class that contains information about one specifics customer spent amount. POCO class. 
    /// </summary>
    public class CustomerSpender
    {
        public int CustomerId { get; set; }
        public decimal TotalSum { get; set; }
    }
}
