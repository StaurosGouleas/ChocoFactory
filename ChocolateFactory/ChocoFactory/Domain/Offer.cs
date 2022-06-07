using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Offer
    {
        //properties
        public decimal PricePerKilo { get; set; }
        public Quality Quality { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost 
        {
            get { return PricePerKilo * Quantity; } 
        }
        public Supplier Supplier { get; set; }

        public Offer()
        {

        }

        public Offer(decimal pricePerKilo, Quality quality, int quantity, Supplier supplier)
        {
            PricePerKilo = pricePerKilo;
            Quality = quality;
            Quantity = quantity;
            Supplier = supplier;
        }

    }
}
