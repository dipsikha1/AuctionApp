using AuctionWeb.Infrastructure;
using AuctionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Services
{
    public class CustomerService
    {
        private CustomerRepository _repo;
        public CustomerService(CustomerRepository repo)
        {
            _repo = repo;
        }

        public IList<Customer> GetCustomer(int id)
        {
            var customer = _repo.List().Where(c => c.Id == id).Select(c => new Customer
            {
                Id = c.Id,
                BidAmount = c.BidAmount,
                Name = c.Name
            }).ToList();
            return customer;

        }



        public Customer GetCustomerById(int id)
        {
            var customer = _repo.List().Where(c => c.Id == id).Select(c => new Customer
            {
                Id = c.Id,
                BidAmount = c.BidAmount,
                Name = c.Name,
            }).FirstOrDefault();
            return customer;


        }

        public void UpdateCustomer(Customer customer)
        {
            var orig = _repo.GetCustomerById(customer.Id);
            orig.BidAmount = customer.BidAmount;
            orig.Name = customer.Name;
            _repo.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {

            var cus = new Customer
            {
               Name = customer.Name,
               BidAmount = customer.BidAmount
            };

            _repo.Add(customer);
            _repo.SaveChanges();
        }


        public void DeleteCustomer(int id)
        {
            var orig = _repo.GetCustomerById(id);
            _repo.Delete(orig);
            _repo.SaveChanges();
        }
    }
}
