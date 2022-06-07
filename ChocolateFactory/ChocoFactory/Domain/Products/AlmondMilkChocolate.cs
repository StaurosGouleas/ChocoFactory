using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class AlmondMilkChocolate : IMilkChocolateModel
    {
        public DateTime ExpirationDate { get; set; }

        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime ProductionDate { get; set; }

        public decimal Price { get; set; }
    }
}