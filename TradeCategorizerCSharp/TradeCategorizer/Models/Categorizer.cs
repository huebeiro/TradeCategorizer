using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategorizer.Models.Base;

namespace TradeCategorizer.Models
{
    public class Categorizer
    {
        private List<ICategory> AvailableCategories;

        public Categorizer(List<ICategory> availableCategories)
        {
            AvailableCategories = availableCategories;
        }


        public List<string> GetTradeCategories(List<ITrade> portfolio)
        {
            List<string> tradeCategories = new();

            foreach(ITrade trade in portfolio)
            {
                ICategory category = FindTradeCategory(trade);
                tradeCategories.Add(category != null ? category.Risk : null);
            }

            return tradeCategories;
        }

        public ICategory FindTradeCategory(ITrade trade)
        {
            foreach (ICategory category in AvailableCategories)
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
