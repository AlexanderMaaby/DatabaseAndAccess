using ChinookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                customer.CustomerID = reader.GetValue(0).ToString();
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
        public Customer GetCustomer(string id)
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
                                customer.CustomerID = reader.GetValue(0).ToString();
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
                                customer.CustomerID = reader.GetValue(0).ToString();
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = reader.GetString(3);
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
                                customer.CustomerID = reader.GetValue(0).ToString();
                                customer.CustomerFirstName = reader.GetString(1);
                                customer.CustomerSurename = reader.GetString(2);
                                customer.Country = reader.GetString(3);
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
    }
}
