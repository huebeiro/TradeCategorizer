using System.Collections.Generic;
using TradeCategorizer.Models;
using TradeCategorizer.Models.Base;
using Xunit;

namespace TradeCategorizerTest
{
    public class CategorizerTest
    {
        private Categorizer Categorizer;
        public CategorizerTest()
        {
            //TODO Inject categorizer
        }

        [Theory]
        [InlineData(2000000, "Private", "HIGHRISK")]
        [InlineData(400000, "Public", "LOWRISK")]
        [InlineData(500000, "Public", "LOWRISK")]
        [InlineData(3000000, "Public", "MEDIUMRISK")]
        public void SampleIndividualTradeTheory(double value, string clientSector, string resultRisk)
        {
            //TODO Implement test
            Assert.Equal(
                resultRisk,
                Categorizer.FindTradeCategory(new Trade(value, clientSector)).Risk
            );
        }

        [Fact]
        public void SamplePortfolioTest()
        {
            Assert.Equal(
                new List<string>
                {
                    "HIGHRISK", "LOWRISK", "LOWRISK", "MEDIUMRISK"
                },
                Categorizer.GetTradeCategories(new List<ITrade>()
                {
                    new Trade(2000000, "Private"),
                    new Trade(400000, "Public"),
                    new Trade(500000, "Public"),
                    new Trade(3000000, "Public")
                })
            );
        }
    }
}
