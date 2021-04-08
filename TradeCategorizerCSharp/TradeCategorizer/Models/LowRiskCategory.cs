using System;
using TradeCategorizer.Models.Base;

namespace TradeCategorizer.Models
{
    public class LowRiskCategory : ICategory
    {
        public Func<ITrade, bool> CheckCondition =>
            trade => trade.Value < 1000000 && trade.ClientSector == "Public";

        public string Risk =>
            "LOWRISK";
    }
}
