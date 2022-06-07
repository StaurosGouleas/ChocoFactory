using ChocoFactory.Policy;

namespace ChocoFactory.Services
{
    public class CompanyPolicy
    {
        //properties
        public FactoryPolicy Factory { get; private set; }

        public ProductionPolicy Production { get; private set; }

        public PricePolicy Pricing { get; private set; }
        public ShopPolicy Shop { get; private set; }

        //constructor
        public CompanyPolicy()
        {
            Factory = new FactoryPolicy();
            Production = new ProductionPolicy();
            Pricing = new PricePolicy();
            Shop = new ShopPolicy(Factory.DailyProducts);
        }
    }
}