using AuctionWeb.Data;
using AuctionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Infrastructure
{
    public class ItemRepository : GenericRepository<Item>
    {
        public ItemRepository(ApplicationDbContext db) : base(db) { }


        public ICollection<Item> GetItems()
        {
            return _db.Items.ToList();
        }


        public Item GetItemById(int id)
        {
            return _db.Items.FirstOrDefault(i => i.Id == id);
        }
    }
}


       
