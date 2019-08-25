using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.Interfaces
{
    public interface ITradePolicy
    {
        void BuySupplies(Distribuitor distribuitor, ITransport transport);
        void SellSupplies(Distribuitor distribuitor, ITransport transport);
    }
}
