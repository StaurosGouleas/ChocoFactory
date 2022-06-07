using ChocoFactory.Domain;
using System.Collections.Generic;

namespace ChocoFactory.Services
{
    public interface ISupplierService
    {
        List<Offer> Offers(Factory factory);
    }
}