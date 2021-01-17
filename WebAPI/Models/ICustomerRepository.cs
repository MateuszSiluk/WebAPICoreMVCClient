﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int Id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
