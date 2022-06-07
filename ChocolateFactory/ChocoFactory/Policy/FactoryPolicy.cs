namespace ChocoFactory.Policy
{
    public class FactoryPolicy
    {
        //properties
        public int DailyProducts { get; private set; }

        public double LowSuppliesThresholdPercent { get; private set; }
        public double MinimumRevenueToInvest { get; private set; }
        public double RevenueYearlyGoal { get; private set; }
        public int NumberOfOffers { get; private set; }

        //constructor
        public FactoryPolicy()
        {
            DailyProducts = 500;
            LowSuppliesThresholdPercent = 0.10;
            MinimumRevenueToInvest = 0.10;
            RevenueYearlyGoal = 0.15;
            RevenueYearlyGoal = 0.15;
            NumberOfOffers = 3;
        }
    }
}