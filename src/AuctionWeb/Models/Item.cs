using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWeb.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumOfBids { get; set; }
        public int MinBid { get; set; }
        public int BuyItNowPrice { get; set; }
        public ICollection<Customer>Customers { get; set; }
    }
}
