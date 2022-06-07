using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{
    public class Factory : IActions
    {
        //properties
        public Company Company { get; set; }
        public Warehouse Warehouse { get; set; }
        public Production Production { get; set; }
        public Accounting Accounting { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public Factory(Company company, ISupplierService supplierService)
        {
            Company = company;
            Warehouse = new Warehouse(this);
            Production = new Production(this);
            Accounting = new Accounting(this,supplierService);
        }

        public void OpeningActions()
        {
            Accounting.ReceiveOffers();
            Accounting.SendOrder(Accounting.BestOffer);
            Warehouse.GetDailyProducts();
        }

        public void DailyActions(DateTime currentDate)
        {
            Warehouse.DailyActions(currentDate);
        }

        public void YearlyActions()
        {
            Warehouse.AddExperimentalProduct();
            Accounting.ReceiveOffers();
            Accounting.SendOrder(Accounting.BestOffer);
        }


    }
}
