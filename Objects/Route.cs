using System.Collections.Generic;

namespace Metodologias1.Kingdom.Objects
{
    public class Route
    {
        public List<City> CityList { get; set; }
        public Merchant Merchant { get; set; }

        public Route(List<City> cityList, Merchant merchant)
        {
            this.CityList = cityList;
            this.Merchant = merchant;
        }

        public void Trade()
        {
            foreach (var city in CityList)
            {
                Merchant.TradePolicy.Trade(city, Merchant.Transport);
            }
        }
    }
}
