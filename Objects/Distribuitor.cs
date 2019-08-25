using System.Collections.Generic;
using Metodologias1.Kingdom.Interfaces;

namespace Metodologias1.Kingdom.Objects
{
    public class Distribuitor
    {
        public string Name { get; set; }
        public List<IMerchandise> Supplies { get; set; }

        public Distribuitor(string name)
        {
            // Supplies Mocked
            this.Name = name;
            this.Supplies = new List<IMerchandise>()
            {
                new Package(){
                    Weight = 10
                },
                new Package() {
                    Weight = 25
                },
                new Package() {
                    Weight = 55
                },
                new Package() {
                    Weight = 35
                },
                new Package() {
                    Weight = 95
                }
            };
        }

        public Distribuitor(string name, List<IMerchandise> supplies)
        {
            this.Name = name;
            this.Supplies = supplies;
        }
    }
}
