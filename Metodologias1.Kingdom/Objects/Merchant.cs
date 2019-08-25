using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Strategies;

namespace Metodologias1.Kingdom.Objects
{
    public class Merchant
    {
        // Two states: Sell or Buy
        public TraderMode Mode { get; set; }
        public ITransport Transport { get; set; }
        public ITradePolicy TradePolicy { get; set; }

        public Merchant(ITransport transport, ITradePolicy tradePolicy = null)
        {
            this.Transport = transport;
            this.TradePolicy = tradePolicy ?? new NormalTrade();
        }

        public void BuySupplies(Distribuitor route)
        {
            this.TradePolicy.BuySupplies(route, this.Transport);
        }

        public void SellSupplies(Distribuitor route)
        {
            this.TradePolicy.SellSupplies(route, this.Transport);
        }
    }
}
