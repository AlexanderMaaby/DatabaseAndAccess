using ChinookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookAssignment
{
    public interface ICustomerRepository
    {
        public interface ICustomerRepository
        {
            public Customer GetCustomerByName(string name);
            public Customer GetCustomer(string id);
            public List<Customer> GetAllCustomers();
            public List<Customer> GetCustomersByLimitAndOffset(int limit, int offset);
            public List<CustomerCountry> GetAllCustomerCountries();
            public bool AddNewCustomer(Customer customer);
            public bool UpdateCustomer(Customer customer);
            public List<CustomerSpender> GetAllCustomersTotalAmountSpent();
            public CustomerGenre GetCustomerMostPopularGenre(int id);
        }

    }
}
