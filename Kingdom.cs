using System.Collections.Generic;
using Metodologias1.Kingdom.MockData;
using Metodologias1.Kingdom.Objects;
using Metodologias1.Kingdom.TradeStrategies;

namespace Metodologias1.Kingdom
{
    class Kingdom
    {
        static void Main(string[] args)
        {
            var routeOfCities = new List<City>();

            var city = new City("Manchester");
            city.SupplyList = PackageListMock.GetPackage1();
            city.DemandList = PackageListMock.GetPackage2();
            routeOfCities.Add(city);

            var wagon = new Wagon(500);
            var merchant = new Merchant(wagon, new LittleOfMuch(40));

            var route = new Route(routeOfCities, merchant);
            route.Trade();
        }
    }
}