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


        /// <summary>
        /// Computes and return a list of categories based on a provided portfolio
        /// </summary>
        /// <param name="portfolio">The portfolio to be computed</param>
        /// <returns>A List of string of the computed categories</returns>
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

        /// <summary>
        /// Finds the most fit category of a provided trade
        /// </summary>
        /// <param name="trade">The trade of the category to be found</param>
        /// <returns>A object of the category of the given trade, or null if no category is fit.</returns>
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
