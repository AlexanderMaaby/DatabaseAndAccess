using ChinookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChinookAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustomerRepository repository = new CustomerRepository();
            Customer test = repository.GetCustomer("33");
            List<Customer> listemedudes = repository.GetCustomersByLimitAndOffset(10, 10);
            Customer testtest = repository.GetCustomerByName("Ell");
            Console.WriteLine(testtest.CustomerFirstName + " " +  testtest.CustomerSurename);
            int x = 0;
            List<CustomerSpender> listetrist = repository.GetAllCustomersTotalAmountSpent();
            foreach (CustomerSpender te in listetrist)
            {
                Console.WriteLine(te.CustomerId + "    -    " + te.TotalSum);
            }

        }
    }
}
