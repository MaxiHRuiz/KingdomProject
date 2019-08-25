using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.Interfaces
{
    public interface ITradePolicy
    {
        void Trade(City place, ITransport transport);
    }
}
