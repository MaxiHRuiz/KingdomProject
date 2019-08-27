using System.Collections.Generic;
using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.MockData;
using Metodologias1.Kingdom.Objects;

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

            // The strategy is optional in the creation. The default strategy: Normal
            var wagon = new Wagon(500);
            var merchant = new Merchant(wagon);

            var route = new Route(citiesRoute, merchant);
            route.Trade();

            wagon.ChangeTradePolicy(TradeStrategyMode.LitteOfMuch);
            route.Trade();
        }
    }
}