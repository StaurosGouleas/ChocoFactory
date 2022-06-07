using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public interface IEmployee : IHuman
    {
        int ID { get; }
        int DeparmentId { get; }
        int ManagerId { get; }
        decimal Salary { get; }

        string Email { get; }
    }
}