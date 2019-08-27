using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class NormalTrade : ITradePolicy
    {
        public void Up(Wagon wagon, IMerchandise merchandise)
        {
            wagon.WeightCarried += merchandise.GetWeight();
            wagon.Merchandise.Add(merchandise);
        }

        void ITradePolicy.Down(Wagon wagon, IMerchandise merchandise)
        {
            wagon.WeightCarried -= merchandise.GetWeight();
            wagon.Merchandise.Remove(merchandise);
        }
    }
}