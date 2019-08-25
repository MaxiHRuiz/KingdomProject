using System;
using System.Collections.Generic;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom
{
    class Kingdom
    {
        static void Main(string[] args)
        {
            var city = new City("Manchester");
            var distr = new Distribuitor("Distributor1");
            var distr2 = new Distribuitor("Distributor2", new List<IMerchandise>()
            {
                new Package(){
                    Weight = 10
                }
            });

            var wagon = new Wagon(500);
            var merchant = new Merchant(wagon);

            merchant.BuySupplies(distr);
            merchant.SellSupplies(distr2);
        }
    }
}