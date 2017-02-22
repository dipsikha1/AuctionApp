using AuctionWeb.Infrastructure;
using AuctionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Services
{
    public class ItemService
    {
        private CustomerRepository _customerRepo;
       private ItemRepository _repo;
        public ItemService(ItemRepository repo, CustomerRepository customerRepo)
        {
            _repo = repo;
            _customerRepo = customerRepo;
        }
        public IList<Item> ListItem()
        {
            return (from i in _repo.List()
                    select new Item
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                        BuyItNowPrice = i.BuyItNowPrice,
                        MinBid = i.MinBid,
                        NumOfBids = i.NumOfBids,
                        Customers = (from c in i.Customers
                                     select new Customer
                                     {
                                         Id = c.Id,
                                         Name = c.Name,
                                         BidAmount = c.BidAmount
                                     }).ToList()
                    }).ToList();

        }
        public Item GetItemById(int id)
        {
            var item = _repo.List().Where(i => i.Id == id).Select(i => new Item
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                BuyItNowPrice = i.BuyItNowPrice,
                MinBid = i.MinBid,
                NumOfBids = i.NumOfBids,
                Customers = (from c in i.Customers
                             select new Customer
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 BidAmount = c.BidAmount
                             }).ToList()
            }).FirstOrDefault();
            return item;
        }

        public void UpdateItem(Item item)
        {
            var orig = _repo.GetItemById(item.Id);
            orig.Name = item.Name;
            orig.Description = item.Description;
            orig.BuyItNowPrice = item.BuyItNowPrice;
            orig.MinBid = item.MinBid;
            orig.NumOfBids = item.NumOfBids;
            _repo.SaveChanges();
        }

        public void AddItem(Item item)
        {
            _repo.Add(item);
            _repo.SaveChanges();
        }


        public void DeleteItem(int id)
        {
            var orig = _repo.GetItemById(id);
            _repo.Delete(orig);
            _repo.SaveChanges();
        }

        public void AddCustomer(int id, Customer customer)
        {
            _customerRepo.Add(customer);
            var item = _repo.GetItemById(id);
            if (item.Customers == null)
            {
                item.Customers = new List<Customer>();
                item.Customers.Add(customer);
                _repo.SaveChanges();
            }

        }
    }
}
  