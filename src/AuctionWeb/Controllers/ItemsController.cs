using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWeb.Services;
using AuctionWeb.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuctionWeb.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private ItemService _service;
        //private CustomerService _service;

        public ItemsController(ItemService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _service.ListItem();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _service.GetItemById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Item value)
        {
            _service.AddItem(value);
        }

       // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Item value)
        {
            _service.UpdateItem(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteItem(id);
        }
        [HttpPost("{id}")]
        public void Post(int id, [FromBody]Customer customer)
        {

            _service.AddCustomer(id, customer);
        }
    }
}
