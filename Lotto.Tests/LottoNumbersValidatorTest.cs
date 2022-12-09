using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lotto.Tests
{
    public class LottoNumbersValidatorTest
    {
        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(6, true)]
        [InlineData(7, false)]
        public void IsLuckyNumberValidTest(int luckyNumber, bool expected)
        {
            // arrange
            LottoNumbersValidator lottoNumbersValidator = new LottoNumbersValidator();

            // act
            bool actual = lottoNumbersValidator.IsLuckyNumberValid(luckyNumber);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6, true)]
        [InlineData(0, 1, 2, 3, 4, 5, false)]
        [InlineData(22, 21, 20, 19, 18, 17, true)]
        [InlineData(23, 22, 21, 20, 19, 18, false)]
        [InlineData(1, 1, 1, 1, 1, 1, false)]
        [InlineData(1, 2, 3, 4, 5, 5, false)]
        [InlineData(1, 1, 3, 4, 5, 5, false)]
        public void AreLottoNumbersValidTest(int a, int b, int c, int d, int e, int f, bool expected)
        {
            // arrange
            LottoNumbersValidator lottoNumbersValidator = new LottoNumbersValidator();
            List<int> list = new List<int>() { a, b, c, d, e, f };

            // act
            bool actual = lottoNumbersValidator.AreLottoNumbersValid(list);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
