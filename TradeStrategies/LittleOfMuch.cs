using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class LittleOfMuch : ITradePolicy
    {
        public int PackageMaxWeight { get; set; }

        public bool IsOverweightPackage { get; set; }

        public LittleOfMuch(int maxWeightPackage)
        {
            this.PackageMaxWeight = maxWeightPackage;
        }

        public void Trade(City city, ITransport transport)
        {
            foreach (var merchandise in city.DemandList)
            {
                if (transport.HaveIt(merchandise))
                {
                    if (merchandise.GetWeight() >= this.PackageMaxWeight && this.IsOverweightPackage)
                    {
                        this.IsOverweightPackage = false;
                    }

                    transport.Down(merchandise);
                }
            }

            foreach (var merchandise in city.SupplyList)
            {
                if (merchandise.GetWeight() < this.PackageMaxWeight && transport.IsThereSpace(merchandise))
                {
                    transport.Up(merchandise);
                }
                else if (!this.IsOverweightPackage && transport.IsThereSpace(merchandise))
                {
                    this.IsOverweightPackage = true;
                    transport.Up(merchandise);
                }
            }
        }
    }
}
