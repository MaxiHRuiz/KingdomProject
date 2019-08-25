using System;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.Strategies
{
    public class NormalTrade : ITradePolicy
    {
        public void BuySupplies(Distribuitor route, ITransport transport)
        {
            foreach (var supply in route.Supplies)
            {
                if (transport.IsThereSpace(supply))
                {
                    transport.Up(supply);
                }
            }
        }

        public void SellSupplies(Distribuitor distribuitor, ITransport transport)
        {
            foreach (var supply in distribuitor.Supplies)
            {
                if (transport.HaveIt(supply))
                {
                    transport.Down(supply);
                }
            }
        }
    }
}
