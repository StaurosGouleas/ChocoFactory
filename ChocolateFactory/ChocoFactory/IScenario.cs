using System;
using System.Globalization;

namespace ChocoFactory
{
    internal interface IScenario
    {
        Calendar Calendar { get; }
        DateTime CurrentDate { get; }
        DateTime EndingDate { get; set; }
        DateTime StartingDate { get; set; }

        void AdvanceTime();
        void Start();
    }
}