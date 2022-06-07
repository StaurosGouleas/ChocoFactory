using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Order : Offer
    {
        public Factory Factory { get; set; }
        
        public Order(Offer offer, Factory factory)
        {
            this.PricePerKilo = offer.PricePerKilo; 
            this.Quality = offer.Quality;
            this.Quantity = offer.Quantity;
            this.Supplier = offer.Supplier;
            Factory = factory;
        }
    }
}
