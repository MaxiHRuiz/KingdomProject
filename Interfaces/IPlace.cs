namespace Metodologias1.Kingdom.Interfaces
{
    public interface IPlace
    {
        void Trade(ITransport transport);

        void Bid(IMerchandise merchandise);

        void Demand(IMerchandise merchandise);

        string GetName();
    }
}