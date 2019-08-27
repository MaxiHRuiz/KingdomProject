using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.Interfaces;

namespace Metodologias1.Kingdom.Objects
{
    public class Merchant
    {
        // Two states: Sell or Buy
        public TraderMode Mode { get; set; }

        public ITransport Transport { get; set; }

        public Merchant(ITransport transport)
        {
            this.Transport = transport;
        }
    }
}