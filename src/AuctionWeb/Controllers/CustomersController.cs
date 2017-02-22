using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWeb.Models;
using AuctionWeb.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuctionWeb.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private CustomerService _service;
        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> GetCustomer(int id)
        {
            return _service.GetCustomer(id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _service.GetCustomerById(id);
        }

        // POST api/values
        [HttpPost("{id}")]
        public void Post([FromBody]Customer customer)
        {
            _service.AddCustomer(customer);
        }
      

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer value)
        {

            _service.UpdateCustomer(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteCustomer(id);
        }
    }
}
