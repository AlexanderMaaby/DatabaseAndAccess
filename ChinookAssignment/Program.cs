using ChinookAssignment.Models;
using System;

namespace ChinookAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustomerRepository repository = new CustomerRepository();
            Customer test = repository.GetCustomer(34);
            CustomerGenre testtest = repository.GetCustomerMostPopularGenre(12);

        }
    }
}
