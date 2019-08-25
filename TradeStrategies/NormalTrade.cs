using System;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.TradeStrategies
{
    public class NormalTrade : ITradePolicy
    {
        public void Trade(City city, ITransport transport)
        {
            foreach (var merchandise in city.DemandList)
            {
                if (transport.HaveIt(merchandise))
                {
                    transport.Down(merchandise);
                }
            }

            foreach (var merchandise in city.SupplyList)
            {
                if (transport.IsThereSpace(merchandise))
                {
                    transport.Up(merchandise);
                }
            }
        }
    }
}
