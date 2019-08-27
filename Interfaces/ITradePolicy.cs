using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.Interfaces
{
    public interface ITradePolicy
    {
        void Up(Wagon wagon, IMerchandise merchandise);

        void Down(Wagon wagon, IMerchandise merchandise);
    }
}