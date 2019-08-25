using System;
using System.Collections.Generic;
using System.Linq;
using Metodologias1.Kingdom.Interfaces;

namespace Metodologias1.Kingdom.Objects
{
    public class Wagon : ITransport
    {
        public int TotalWeight { get; set; }

        // The current weight taken in the wagon.
        public int WeightCarried { get; set; }

        public List<IMerchandise> Merchandise { get; set; }

        public Wagon(int weight)
        {
            this.TotalWeight = weight;
            this.Merchandise = new List<IMerchandise>();
        }

        public void Up(IMerchandise merchandise)
        {
            Merchandise.Add(merchandise);
            WeightCarried += merchandise.GetWeight();
        }

        public void Down(IMerchandise merchandise)
        {
            //this.Merchandise.RemoveAt(this.Merchandise.FindIndex(x => x.GetWeight() == merchandise.GetWeight()));
            foreach (var merch in Merchandise)
            {
                if (merch.GetWeight() == merchandise.GetWeight())
                {
                    Merchandise.Remove(merch);
                    WeightCarried -= merch.GetWeight();
                    break;
                }
            }
        }

        public bool HaveIt(IMerchandise merchandise)
        {
            return this.Merchandise.Any(x => x.GetWeight() == merchandise.GetWeight());
        }

        public bool IsThereSpace(IMerchandise merchandise)
        {
            return ((WeightCarried + merchandise.GetWeight()) < TotalWeight);
        }
    }
}
