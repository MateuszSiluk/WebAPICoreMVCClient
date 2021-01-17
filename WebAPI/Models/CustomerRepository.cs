using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        public IConfiguration Configuration { get; set; }
        public string connectionString;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(IConfiguration configuration, 
            ILogger<CustomerRepository> logger)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            _logger = logger;
        }
        

        

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectCustomer]", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(rdr["Id"]);
                        customer.Name = rdr["Name"].ToString();
                        customer.Address = rdr["Address"].ToString();
                        customer.Telephone = rdr["Telephone"].ToString();
                        customer.Email = rdr["Email"].ToString();
                        customers.Add(customer);

                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Error at getAllCustomers() : ");
                    customers = null;

                }
            }
            return customers;
        }

        public Customer GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
