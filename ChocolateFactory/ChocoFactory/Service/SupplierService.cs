using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    public class SupplierService : ISupplierService
    {

        public List<Offer> Offers(Factory factory)
        {
            List<Offer> offers = new List<Offer>();

            for (int i = 0; i < factory.Company.CompanyPolicy.Factory.NumberOfOffers; i++)
            {
                Supplier supplier = new Supplier();

                Quality quality = DataGenerator.Quality();
                Offer offerNew = supplier.SendOffer(DataGenerator.PricePerKilo(quality), quality, DataGenerator.Quantity());

                offers.Add(offerNew);
            }

            return offers;
        }

    }
}
