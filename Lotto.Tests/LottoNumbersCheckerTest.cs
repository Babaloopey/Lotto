using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lotto.Tests
{
    public class LottoNumbersCheckerTest
    {
        [Theory]
        [InlineData(6, 5, false)]
        [InlineData(0, 0, true)]
        [InlineData(-6, 6, false)]
        public void CheckLuckyNumberTest(int lottoLuckyNumber, int playerLuckyNumber, bool expected)
        {
            // arrange
            IReadOnlyList<int> lottoNumbers = new List<int> { 3, 4, 12, 1, 6, 20 };

            LottoNumbersChecker lotteryNumbersChecker = new LottoNumbersChecker(lottoLuckyNumber, lottoNumbers);

            // act
            bool actual = lotteryNumbersChecker.CheckLuckyNumberCorrect(playerLuckyNumber);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 1, 2, 3, 4, 5, 4)]
        [InlineData(19, 18, 17, 16, 15, 14, 0)]
        [InlineData(-3, -4, -12, -1, -6, -20, 0)]
        [InlineData(20, 3, 4, 12, 1, 6, 6)]
        public void CheckMatchingLottoNumbersTest(int a, int b, int c, int d, int e, int f, int expected)
        {
            // arrange
            IReadOnlyList<int> lottoNumbers = new List<int> { 3, 4, 12, 1, 6, 20 };
            int lottoLuckyNumber = 3;

            IEnumerable<int> playerLottoNumbers = new List<int> { a, b, c, d, e, f };

            LottoNumbersChecker lotteryNumbersChecker = new LottoNumbersChecker(lottoLuckyNumber, lottoNumbers);

            // act
            int actual = lotteryNumbersChecker.CheckNumberOfMatchingLottoNumbers(playerLottoNumbers);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}

