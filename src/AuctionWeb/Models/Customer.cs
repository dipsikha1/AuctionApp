using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BidAmount { get; set; }
        public Item Item { get; set; }
    }
}
