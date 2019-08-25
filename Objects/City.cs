using System.Collections.Generic;
using Metodologias1.Kingdom.Interfaces;

namespace Metodologias1.Kingdom.Objects
{
    public class City : IPlace
    {
        public string Name { get; set; }

        public List<IMerchandise> DemandList { get; set; }

        public List<IMerchandise> SupplyList { get; set; }

        public City(string name)
        {
            this.Name = name;
            this.DemandList = new List<IMerchandise>();
            this.SupplyList = new List<IMerchandise>();
        }

        public string GetName()
        {
            return this.Name;
        }

        public void Bid(IMerchandise merchandise)
        {
            SupplyList.Add(merchandise);
        }

        public void Demand(IMerchandise merchandise)
        {
            DemandList.Add(merchandise);
        }

        public void Trade(ITransport transport)
        {
            foreach (var merchandise in this.DemandList)
            {
                if (transport.HaveIt(merchandise))
                {
                    transport.Down(merchandise);
                }
            }

            foreach (var merchandise in this.SupplyList)
            {
                if (transport.IsThereSpace(merchandise))
                {
                    transport.Up(merchandise);
                }
            }
        }
    }
}
