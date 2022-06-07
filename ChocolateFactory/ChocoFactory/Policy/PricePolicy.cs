namespace ChocoFactory.Policy
{
    public class PricePolicy
    {
        //propepties
        public decimal BlackChocolatePrice { get; private set; }

        public decimal WhiteChocolatePrice { get; private set; }
        public decimal MilkChocolatePrice { get; private set; }
        public decimal AlmondMilkChocolatePrice { get; private set; }
        public decimal HazelnutMilkChocolatePrice { get; private set; }
        public decimal ExperimentalChocolatePrice { get; private set; }

        //constructor
        public PricePolicy()
        {
            BlackChocolatePrice = 10;
            WhiteChocolatePrice = 12;
            MilkChocolatePrice = 10;
            AlmondMilkChocolatePrice = 16;
            HazelnutMilkChocolatePrice = 16;
            ExperimentalChocolatePrice = 0;
        }
    }
}