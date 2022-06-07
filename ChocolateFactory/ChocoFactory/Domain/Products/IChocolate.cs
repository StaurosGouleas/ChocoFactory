using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public interface IChocolate : IProduct
    {
        DateTime ExpirationDate { get; }
    }
}
