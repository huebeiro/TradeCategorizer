using System.Collections.Generic;
using TradeCategorizer.Models.Base;

namespace TradeCategorizer.Models
{
    public class Categorizer
    {
        private readonly List<ICategory> _availableCategories;

        public Categorizer(List<ICategory> availableCategories)
        {
            _availableCategories = availableCategories;
        }


        public List<string> GetTradeCategories(List<ITrade> portfolio)
        {
            List<string> tradeCategories = new();

            foreach (ITrade trade in portfolio)
            {
                ICategory category = FindTradeCategory(trade);
                tradeCategories.Add(category != null ? category.Risk : null);
            }

            return tradeCategories;
        }

        public ICategory FindTradeCategory(ITrade trade)
        {
            foreach (ICategory category in _availableCategories)
            {
                if (category.CheckCondition(trade))
                {
                    return category;
                }
            }
            return null;
        }
    }
}
