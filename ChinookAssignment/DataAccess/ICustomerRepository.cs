using ChinookAssignment.Models;
using System.Collections.Generic;

namespace ChinookAssignment
{
    /// <summary>
    /// Interface for a Customer Repository.
    /// </summary>
    public interface ICustomerRepository
    {
        public interface ICustomerRepository
        {
            /// <summary>
            /// Returns a single object of type ChinookAssignment/Models.Customer based on the best match of the name.
            /// </summary>
            /// <param name="name">The name of the customer to be found in the database.</param>
            /// <returns>A single object of the type Customer.</returns>
            public Customer GetCustomerByName(string name);
            /// <summary>
            /// Returns a single object of type ChinookAssignment/Models.Customer based on the given id.
            /// </summary>
            /// <param name="id">The id of the customer to be found in the database.</param>
            /// <returns>A single object of the type Customer.</returns>
            public Customer GetCustomer(string id);
            /// <summary>
            /// Returns a List containing all the customers in the database. 
            /// </summary>
            /// <returns>Returns a Generic.List containing all customers in the database of type Customer.</returns>
            public List<Customer> GetAllCustomers();
            /// <summary>
            /// Returns a List containing all the customers in the database limited by given offset an limit.
            /// </summary>
            /// <param name="limit">An int representing the amount of results the query should limit.</param>
            /// <param name="offset">An int representing the index the query should start at.</param>
            /// <returns>Returns a Generic.List containing all customers in the database of type Customer.</returns>
            public List<Customer> GetCustomersByLimitAndOffset(int limit, int offset);
            /// <summary>
            /// Find the amount of customers in each country from the database.
            /// </summary>
            /// <returns>A list containing CustomerCountry which has the information country and amount of entries. The list is sorted from high to low.</returns>
            public List<CustomerCountry> GetAllCustomerCountries();
            /// <summary>
            /// Adds a new customer to the database.
            /// </summary>
            /// <param name="customer">The Customer that should be added to the database.</param>
            /// <returns>A bool symbolizing whether or not the insert was succesfull.</returns>
            public bool AddNewCustomer(Customer customer);
            /// <summary>
            /// Updates a customer entry in the database.
            /// </summary>
            /// <param name="customer">Object of type Customer that will update all data in the database for this entry.</param>
            /// <returns>A bool symbolizing whether or not the insert was succesfull.</returns>
            public bool UpdateCustomer(Customer customer);
            /// <summary>
            /// Finds the total amount of money spent by each customer in the database. 
            /// </summary>
            /// <returns>Returns the requested data as an instance of the poco class CustomerSpender.</returns>
            public List<CustomerSpender> GetAllCustomersTotalAmountSpent();
            /// <summary>
            /// Finds a given customers most popular genre, or genres in case of a tie.
            /// </summary>
            /// <param name="id">The CustomerId of the customer the genres should be returned for.</param>
            /// <returns>Returns the requested data as an instance of the poco class CustomerGenre.</returns>
            public CustomerGenre GetCustomerMostPopularGenre(int id);
        }

    }
}
