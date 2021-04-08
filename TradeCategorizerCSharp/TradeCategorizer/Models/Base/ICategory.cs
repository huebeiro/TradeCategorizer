using System;

namespace TradeCategorizer.Models.Base
{
    public interface ICategory
    {
        public Func<ITrade, bool> CheckCondition { get; }
        public string Risk { get; }
    }
}
