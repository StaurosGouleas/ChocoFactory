using System;

namespace ChocoFactory.Domain
{
    public interface IProduct
    {
        //properties
        int ID { get; }
        string Description { get; }
        DateTime ProductionDate { get; }
        decimal Price { get; }

        //methods
    }
}