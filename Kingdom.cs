using System.Collections.Generic;
using Metodologias1.Kingdom.MockData;
using Metodologias1.Kingdom.Objects;
using Metodologias1.Kingdom.TradeStrategies;

namespace Metodologias1.Kingdom
{
    public class Kingdom
    {
        public static void Main(string[] args)
        {
            var citiesRoute = new List<City>();

            var city = new City("Manchester");
            city.SupplyList = PackageListMock.GetPackage1();
            city.DemandList = PackageListMock.GetPackage2();
            citiesRoute.Add(city);

            // var merchant = new Merchant(wagon); Example using the normal trade strategy
            // var merchant = new Merchant(wagon, new LittleOfMuch(50)); Example using the Little of much trade strategy
            var wagon = new Wagon(500);
            var merchant = new Merchant(wagon, new FillToEmpty(50, 10, wagon.TotalWeight, Enum.TraderMode.Buy));

            var route = new Route(citiesRoute, merchant);
            route.Trade();
        }
    }
}