using System.Linq;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class LittleOfMuch : ITradePolicy
    {
        public int PackageMaxWeight { get; set; }

        public bool IsOverweightPackage { get; set; }

        public LittleOfMuch(int maxWeightPackage = 40)
        {
            this.PackageMaxWeight = maxWeightPackage;
        }

        public void Up(Wagon wagon, IMerchandise merchandise)
        {
            if (merchandise.GetWeight() < this.PackageMaxWeight)
            {
                wagon.Merchandise.Add(merchandise);
            }
            else if (!this.IsOverweightPackage)
            {
                this.IsOverweightPackage = true;
                wagon.Merchandise.Add(merchandise);
            }
        }

        public void Down(Wagon wagon, IMerchandise merchandise)
        {
            if (this.IsOverweightPackage)
            {
                this.IsOverweightPackage = false;
            }

            wagon.Merchandise.RemoveAt(wagon.Merchandise.FindIndex(x => x.GetWeight() == merchandise.GetWeight()));
        }
    }
}