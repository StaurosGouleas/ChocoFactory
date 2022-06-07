namespace ChocoFactory.Services
{
    public class ProductionPolicy
    {
        //properties
        public int BlackChocolateSupplies { get; private set; }

        public int WhiteChocolateSupplies { get; private set; }
        public int MilkChocolateSupplies { get; private set; }
        public int AlmondMilkChocolateSupplies { get; private set; }
        public int HazelnutMilkChocolateSupplies { get; private set; }
        public int ExperimentalChocolateSupplies { get; private set; }

        public double BlackChocolatePercent { get; private set; }
        public double WhiteChocolatePercent { get; private set; }
        public double MilkChocolatePercent { get; private set; }
        public double AlmondMilkChocolatePercent { get; private set; }
        public double HazelnutMilkChocolatePercent { get; private set; }
        public double ExperimentalPercent { get; private set; }

        //constuctor
        public ProductionPolicy()
        {
            BlackChocolateSupplies = 1;
            WhiteChocolateSupplies = 1;
            MilkChocolateSupplies = 1;
            AlmondMilkChocolateSupplies = 1;
            HazelnutMilkChocolateSupplies = 1;
            ExperimentalChocolateSupplies = 1;
            BlackChocolatePercent = 0.50;
            WhiteChocolatePercent = 0.20;
            MilkChocolatePercent = 0.10;
            AlmondMilkChocolatePercent = 0.10;
            HazelnutMilkChocolatePercent = 0.10;
            ExperimentalPercent = 0.05;
        }
    }
}