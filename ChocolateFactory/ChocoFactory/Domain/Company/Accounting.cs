using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{
    public class Accounting : IDepartment
    {
        // fields
        private readonly ISupplierService _supplierService;
        private Offer bestOffer;

        // Properties
        public int DepartmentID { get; }

        public string Description { get; }
        public Factory Factory { get; set; }
        public List<IEmployee> Employees { get; set; } = new List<IEmployee>();//list of possible employees of this deparment.
        public List<Offer> AvailableOffers { get; set; } = new List<Offer>();// list of available offers of possible suppliers
        public Offer BestOffer
        {
            get
            {
                double bestValue = 0;

                foreach (Offer offer in AvailableOffers)
                {
                    double value = OfferValue(offer);

                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestOffer = offer;
                    }
                }
                return bestOffer;
            }
        }
        public Supplier LastSupplier { get; set; }// the last supplier that send us offer
        public Order LastOrder { get; set; }



        // Constructor
        public Accounting(Factory factory,ISupplierService supplierService)
        {
            Factory = factory;
            _supplierService = supplierService;
        }

        //methods
        public void ReceiveOffers()
        {
            AvailableOffers = new List<Offer>(_supplierService.Offers(Factory));
            Console.WriteLine("The offers from Suppliers are delivered.");
        }

        public Order SendOrder(Offer offer)
        {
            Order order = new Order(offer, Factory);
            
            order.Supplier.SendSupplies(order);

            Factory.Company.Revenue -= order.TotalCost;

            LastOrder = order;
            LastSupplier = order.Supplier;

            Console.WriteLine("[Send order!!!]");
            return order;
        }

        private double OfferValue(Offer offer)
        {
            int quality = (int)offer.Quality;
            double pricePerKilo = (double)offer.PricePerKilo;

            if (pricePerKilo == 0 && offer.Quantity !=0)
                return double.MaxValue;
            else
                return quality / pricePerKilo;
        }
    }
}
