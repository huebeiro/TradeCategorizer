using System;
using System.Collections.Generic;
using TradeCategorizer.Models;
using TradeCategorizer.Models.Base;

namespace TradeCategorizer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Trade Categorizer\nCategorizing sample portfolio:");

            //Initializing categorizer
            Categorizer categorizer = new(
                new List<ICategory>()
                {
                    new LowRiskCategory(),
                    new MediumRiskCategory(),
                    new HighRiskCategory()
                }
            );

            //Sample input
            var categories = categorizer.GetTradeCategories(new List<ITrade>()
                {
                    new Trade(2000000, "Private"),
                    new Trade(400000, "Public"),
                    new Trade(500000, "Public"),
                    new Trade(3000000, "Public")
                });

            //Displaying output
            Console.WriteLine($"Portfolio categories: [{string.Join(", ", categories)}]");
        }
    }
}
