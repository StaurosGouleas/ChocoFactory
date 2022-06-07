using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Supplier : IHuman
    {
        //properties
        public int ID { get; set; }// SupplierID

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public double Phone { get; set; }

        //methods
        public void SendSupplies(Order order)
        {
            Warehouse warehouseToSend = order.Factory.Warehouse;
            warehouseToSend.GetSupplies(order.Quantity);
        }

        public Offer SendOffer(decimal pricePerKilo, Quality quality, int suppliesKilos)
        {
            return new Offer(pricePerKilo, quality, suppliesKilos, this);
        }
    }
}