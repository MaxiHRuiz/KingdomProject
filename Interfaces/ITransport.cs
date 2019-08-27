namespace Metodologias1.Kingdom.Interfaces
{
    public interface ITransport
    {
        void Up(IMerchandise merchandise);

        void Down(IMerchandise merchandise);

        bool HaveIt(IMerchandise merchandise);

        bool IsThereSpace(IMerchandise merchandise);
    }
}