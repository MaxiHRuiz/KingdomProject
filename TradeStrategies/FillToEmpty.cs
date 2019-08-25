using System.Linq;
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

        public FillToEmpty(int maxTransportWeight)
        {
            this.PercentageToFill = DefaultPercentageToFill;
            this.PercentageToEmpty = DefaultPercentageToEmpty;
            this.CurrentPercentage = 0;
            this.MaxTransportWeight = maxTransportWeight;
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

        public void Trade(City city, ITransport transport)
        {
            if (this.MerchantMode.Equals(TraderMode.Sell))
            {
                foreach (var merchandise in city.DemandList)
                {
                    var percentageWithOutMerchandise = this.CurrentPercentage - (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                    if (transport.HaveIt(merchandise) && percentageWithOutMerchandise >= this.PercentageToEmpty)
                    {
                        this.CurrentPercentage = percentageWithOutMerchandise;
                        transport.Down(merchandise);
                    }
                }
            }

            if (this.MerchantMode.Equals(TraderMode.Buy))
            {
                foreach (var merchandise in city.SupplyList)
                {
                    var percentageWithMerchandise = this.CurrentPercentage + (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                    if (!transport.HaveIt(merchandise) && percentageWithMerchandise <= this.PercentageToFill)
                    {
                        this.CurrentPercentage = percentageWithMerchandise;
                        transport.Up(merchandise);
                    }
                }
            }
        }
    }
}
