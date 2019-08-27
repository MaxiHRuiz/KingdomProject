using System;
using System.Collections.Generic;
using System.Linq;
using Metodologias1.Kingdom.Enum;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.TradeStrategies;

namespace Metodologias1.Kingdom.Objects
{
    public class Wagon : ITransport
    {
        public int TotalWeight { get; set; }

        // The current weight taken in the wagon.
        public int WeightCarried { get; set; }

        public List<IMerchandise> Merchandise { get; set; }

        public ITradePolicy TradePolicy { get; set; }

        public Wagon(int weight, TradeStrategyMode? strategyMode = null)
        {
            this.TotalWeight = weight;
            this.Merchandise = new List<IMerchandise>();
            ChangeTradePolicy(strategyMode);
        }

        public void Up(IMerchandise merchandise)
        {
            TradePolicy.Up(this, merchandise);
        }

        public void Down(IMerchandise merchandise)
        {
            TradePolicy.Down(this, merchandise);
        }

        public bool HaveIt(IMerchandise merchandise)
        {
            return this.Merchandise.Any(x => x.GetWeight() == merchandise.GetWeight());
        }

        public bool IsThereSpace(IMerchandise merchandise)
        {
            return ((WeightCarried + merchandise.GetWeight()) < TotalWeight);
        }

        public void ChangeTradePolicy(TradeStrategyMode? strategyMode)
        {
            switch (strategyMode)
            {
                case TradeStrategyMode.Normal:
                    this.TradePolicy = new NormalTrade();
                    break;
                case TradeStrategyMode.FillToEmpty:
                    this.TradePolicy = new FillToEmpty();
                    break;
                case TradeStrategyMode.LitteOfMuch:
                    this.TradePolicy = new LittleOfMuch();
                    break;
                default:
                    this.TradePolicy = new NormalTrade();
                    break;
            }
        }
    }
}