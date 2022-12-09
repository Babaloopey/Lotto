using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lotto.Tests
{
    public class ProfitTest
    {
        [Theory]
        [InlineData(6, true, 5000000)]
        [InlineData(6, false, 1000000)]
        [InlineData(5, true, 10000)]
        [InlineData(5, false, 1000)]
        [InlineData(4, true, 150)]
        [InlineData(4, false, 75)]
        [InlineData(3, true, 25)]
        [InlineData(3, false, 10)]
        [InlineData(2, true, 5)]
        [InlineData(2, false, 2)]
        [InlineData(1, true, 0)]
        [InlineData(1, false, 0)]
        [InlineData(0, true, 0)]
        [InlineData(0, false, 0)]
        public void ProfitWhenAmountOfLottoNumbersCorrect(int correctLottoNumbers, bool luckyNumber, int expected)
        {
            // arrange && act
            var profit = new Profit(correctLottoNumbers, luckyNumber);

            // assert
            Assert.Equal(expected, profit.GetValue());
        }
    }
}
