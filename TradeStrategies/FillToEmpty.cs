using System.Linq;
using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class FillToEmpty : ITradePolicy
    {
        public TraderMode MerchantMode { get; set; }

        // The carriage will be fill to this percentage.
        public int PercentageToFill { get; set; }

        // The carriage will empty up to this percentage.
        public int PercentageToEmpty { get; set; }

        public int CurrentPercentage { get; set; }

        public int MaxTransportWeight { get; set; }

        public FillToEmpty(int percentageToFill, int percentageToEmpty, int maxWeight)
        {
            this.PercentageToFill = percentageToFill;
            this.PercentageToEmpty = percentageToEmpty;
            this.CurrentPercentage = 0;
            this.MaxTransportWeight = maxWeight;
            this.MerchantMode = TraderMode.Buy;
        }

        public void Trade(City city, ITransport transport)
        {
            foreach (var merchandise in city.DemandList)
            {
                if (this.MerchantMode.Equals(TraderMode.Sell))
                {
                    var percentageWithOutMerchandise = this.CurrentPercentage - (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                    if (transport.HaveIt(merchandise) && percentageWithOutMerchandise >= this.PercentageToEmpty)
                    {
                        this.CurrentPercentage = percentageWithOutMerchandise;
                        transport.Down(merchandise);
                    }
                    else if (merchandise != city.SupplyList.Last())
                    {
                        continue;
                    }
                    else
                    {
                        this.MerchantMode = TraderMode.Buy;
                    }
                }
            }

            foreach (var merchandise in city.SupplyList)
            {
                if (this.MerchantMode.Equals(TraderMode.Buy))
                {
                    var percentageWithMerchandise = this.CurrentPercentage + (merchandise.GetWeight() * 100 / this.MaxTransportWeight);
                    if (!transport.HaveIt(merchandise) && percentageWithMerchandise <= this.PercentageToFill)
                    {
                        this.CurrentPercentage = percentageWithMerchandise;
                        transport.Up(merchandise);
                    }
                    else if (merchandise != city.SupplyList.Last())
                    {
                        continue;
                    }
                    else
                    {
                        this.MerchantMode = TraderMode.Sell;
                    }
                }                
            }
        }
    }
}
