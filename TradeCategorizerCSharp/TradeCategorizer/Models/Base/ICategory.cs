using System;

namespace TradeCategorizer.Models.Base
{
    /// <summary>
    /// An interface that represents a Trade Category
    /// </summary>
    public interface ICategory
    {
        public Func<ITrade, bool> CheckCondition { get; }
        public string Risk { get; }
    }
}
