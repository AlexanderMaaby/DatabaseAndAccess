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
            foreach (Customer dudedude in listemedudes)
            {
                x++;
                Console.WriteLine(x + " " + dudedude.CustomerFirstName);
            }
            List<CustomerCountry> besttest = repository.GetAllCustomerCountries();
            foreach (CustomerCountry west in besttest)
            {
                Console.WriteLine(west.Country + " - " + west.Count);
            }

        }
    }
}
