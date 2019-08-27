using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class FillToEmpty : ITradePolicy
    {
        public const int DefaultPercentageToEmpty = 5;
        public const int DefaultPercentageToFill = 95;

        public TraderMode MerchantMode { get; set; }

        // The carriage will be fill to this percentage.
        public int PercentageToFill { get; set; }

        // The carriage will empty up to this percentage.
        public int PercentageToEmpty { get; set; }

        public int CurrentPercentage { get; set; }

        public int MaxTransportWeight { get; set; }

        public FillToEmpty(int maxTransportWeight = 500)
        {
            this.MaxTransportWeight = maxTransportWeight;
            this.PercentageToFill = DefaultPercentageToFill;
            this.PercentageToEmpty = DefaultPercentageToEmpty;
            this.CurrentPercentage = 0;
            this.MerchantMode = TraderMode.Buy;
        }

        public FillToEmpty(int percentageToFill, int percentageToEmpty, int maxTransportWeight, TraderMode mode)
        {
            this.PercentageToFill = percentageToFill;
            this.PercentageToEmpty = percentageToEmpty;
            this.CurrentPercentage = 0;
            this.MaxTransportWeight = maxTransportWeight;
            this.MerchantMode = mode;
        }

        public void Up(Wagon wagon, IMerchandise merchandise)
        {
            if (this.MerchantMode.Equals(TraderMode.Buy))
            {
                var percentageWithMerchandise = this.CurrentPercentage + (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                if (percentageWithMerchandise <= this.PercentageToFill)
                {
                    this.CurrentPercentage = percentageWithMerchandise;
                    wagon.Merchandise.Add(merchandise);
                }
            }
        }

        public void Down(Wagon wagon, IMerchandise merchandise)
        {
            if (this.MerchantMode.Equals(TraderMode.Sell))
            {
                var percentageWithOutMerchandise = this.CurrentPercentage - (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                if (percentageWithOutMerchandise >= this.PercentageToEmpty)
                {
                    this.CurrentPercentage = percentageWithOutMerchandise;
                    wagon.Merchandise.Remove(merchandise);
                }
            }
        }
    }
}