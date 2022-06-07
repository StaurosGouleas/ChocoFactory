using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    interface IActions
    {
        void DailyActions(DateTime date);
        void YearlyActions();
    }
}
