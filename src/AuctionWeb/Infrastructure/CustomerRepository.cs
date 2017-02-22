using AuctionWeb.Data;
using AuctionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Infrastructure
{
    public class CustomerRepository: GenericRepository<Customer>
    {

        public CustomerRepository(ApplicationDbContext db) : base(db) { }


        public ICollection<Customer> GetCustomers()
        {
            return _db.Customers.ToList();
        }


        public Customer GetCustomerById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}

