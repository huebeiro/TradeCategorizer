using System;
using TradeCategorizer.Models.Base;

namespace TradeCategorizer.Models
{
    public class HighRiskCategory : ICategory
    {
        public Func<ITrade, bool> CheckCondition =>
            trade => trade.Value > 1000000 && trade.ClientSector == "Private";

        public string Risk =>
            "HIGHRISK";
    }
}
