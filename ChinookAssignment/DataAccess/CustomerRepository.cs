using ChinookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ChinookAssignment
{
    /// <summary>
    /// Repository for Customer from the database Chinoook. Implementes interface ICustomerRepository.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Returns a single object of type ChinookAssignment/Models.Customer based on the best match of the name.
        /// </summary>
        /// <param name="name">The name of the customer to be found in the database.</param>
        /// <returns>A single object of the type Customer.</returns>
        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE FirstName LIKE @CustomerName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", "%" +name + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetInt32(0);
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customer;
        }
        /// <summary>
        /// Returns a single object of type ChinookAssignment/Models.Customer based on the given id.
        /// </summary>
        /// <param name="id">The id of the customer to be found in the database.</param>
        /// <returns>A single object of the type Customer.</returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE CustomerID = @CustomerID";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetInt32(0);
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = QuerySanitizer.SafeGetString(reader, 3);
                                customer.PostalCode = QuerySanitizer.SafeGetString(reader, 4);
                                customer.Phone = QuerySanitizer.SafeGetString(reader, 5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customer;
        }

        /// <summary>
        /// Returns a List containing all the customers in the database. 
        /// </summary>
        /// <returns>Returns a Generic.List containing all customers in the database of type Customer.</returns>
        public List <Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                  
                   
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                customer = new Customer();
                                customer.CustomerID = reader.GetInt32(0);
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = QuerySanitizer.SafeGetString(reader, 3);
                                customer.PostalCode = QuerySanitizer.SafeGetString(reader, 4);
                                customer.Phone = QuerySanitizer.SafeGetString(reader, 5);
                                customer.Email = reader.GetString(6);
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customers;
        }

        /// <summary>
        /// Returns a List containing all the customers in the database limited by given offset an limit.
        /// </summary>
        /// <param name="limit">An int representing the amount of results the query should limit.</param>
        /// <param name="offset">An int representing the index the query should start at.</param>
        /// <returns>Returns a Generic.List containing all customers in the database of type Customer.</returns>
        public List<Customer> GetCustomersByLimitAndOffset(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET "+ offset + " ROWS FETCH NEXT " + limit + " ROWS ONLY";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                customer = new Customer();
                                customer.CustomerID = reader.GetInt32(0);
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = QuerySanitizer.SafeGetString(reader, 3);
                                customer.PostalCode = QuerySanitizer.SafeGetString(reader, 4);
                                customer.Phone = QuerySanitizer.SafeGetString(reader, 5);
                                customer.Email = reader.GetString(6);
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customers;
        }

        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The Customer that should be added to the database.</param>
        /// <returns>A bool symbolizing whether or not the insert was succesfull.</returns>
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                "VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.CustomerFirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.CustomerSurename);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return success;
        }

        /// <summary>
        /// Updates a customer entry in the database.
        /// </summary>
        /// <param name="customer">Object of type Customer that will update all data in the database for this entry.</param>
        /// <returns>A bool symbolizing whether or not the insert was succesfull.</returns>
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, "
            + "PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.CustomerFirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.CustomerSurename);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return success;
        }

        /// <summary>
        /// Find the amount of customers in each country from the database.
        /// </summary>
        /// <returns>A list containing CustomerCountry which has the information country and amount of entries. The list is sorted from high to low.</returns>
        public List<CustomerCountry> GetAllCustomerCountries()
        {
            List<CustomerCountry> countries = new List<CustomerCountry>();
            CustomerCountry customerCountry = new CustomerCountry();
            string sql = "SELECT Country, count(*) as c FROM Customer GROUP BY Country ORDER BY c DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerCountry = new CustomerCountry();
                                customerCountry.Country = reader.GetString(0);
                                customerCountry.Count = reader.GetInt32(1);
                                countries.Add(customerCountry);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return countries;
        }

        /// <summary>
        /// Finds the total amount of money spent by each customer in the database. 
        /// </summary>
        /// <returns>Returns the requested data as an instance of the poco class CustomerSpender.</returns>
        public List<CustomerSpender> GetAllCustomersTotalAmountSpent()
        {
            List<CustomerSpender> customers = new List<CustomerSpender>();
            CustomerSpender customer = new CustomerSpender();
            string sql = "SELECT CustomerId, SUM(Total) AS 'Total sum per customer' From Invoice GROUP BY CustomerId ORDER BY SUM(Total) DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer = new CustomerSpender();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.TotalSum = reader.GetDecimal(1);
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customers;
        }

        /// <summary>
        /// Finds a given customers most popular genre, or genres in case of a tie.
        /// </summary>
        /// <param name="id">The CustomerId of the customer the genres should be returned for.</param>
        /// <returns>Returns the requested data as an instance of the poco class CustomerGenre.</returns>
        public CustomerGenre GetCustomerMostPopularGenre(int id)
        {
            CustomerGenre customerGenre = new CustomerGenre();
            string sql = "SELECT TOP 1 WITH TIES c.CustomerId, c.FirstName, g.Name as FavouriteGenre, Count(g.Name) AS Purchases "
            + "FROM Customer as c, Invoice as i, InvoiceLine as il, Track as t, Genre as g "
            + " WHERE c.CustomerId = @CustomerID AND c.CustomerId = i.CustomerId AND i.InvoiceId = il.InvoiceId AND il.TrackId = t.TrackId AND t.GenreId = g.GenreId "
            + " GROUP BY c.FirstName, c.CustomerId, g.Name ORDER BY Purchases DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerGenre.CustomerId = reader.GetInt32(0);
                                customerGenre.FirstName = reader.GetString(1);
                                customerGenre.Genre.Add(reader.GetString(2));
                                customerGenre.TotalTracks = reader.GetInt32(3);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customerGenre;
        }
    }
}
