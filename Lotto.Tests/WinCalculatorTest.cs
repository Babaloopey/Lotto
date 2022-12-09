using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lotto.Tests
{
    public class WinCalculatorTest
    {
        [Fact]
        public void UpdatePlayerStatisticTest()
        {
            // arrange
            WinCalculator winCalculator = new WinCalculator(new List<Player>());

            Player player = new Player("Fritz", new List<int> { 3, 4, 12, 1, 6, 20 }, 3);
            PlayerStatistics playerStatistics = new PlayerStatistics(player);
            Profit profit = new Profit(4, true);

            // act
            winCalculator.UpdatePlayerStatistic(playerStatistics, player, profit);

            // assert
            Assert.Equal(150, playerStatistics.LotteryPayout);
            Assert.Equal(0, playerStatistics.GamesWithoutProfit);
            Assert.Equal(1, playerStatistics.GamesPlayed);
            Assert.Equal(1, playerStatistics.GamesWithProfit);
        }

        [Fact]
        public void CreatePlayerStatisticTest()
        {
            // arrange
            WinCalculator winCalculator = new WinCalculator(new List<Player>());

            Player player = new Player("Fritz", new List<int> { 3, 4, 12, 1, 6, 20 }, 3);
            Profit profit = new Profit(4, true);

            // act
            winCalculator.CreatePlayerStatistic(player, profit);

            // assert
            Assert.Single(winCalculator.PlayerStatisticsList);
            Assert.Equal(150, winCalculator.PlayerStatisticsList[0].LotteryPayout);
        }

        [Fact]
        public void WinCalculatorIntegrationTest()
        {
            // arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            string line1 = "                     Name      #Spiele ohne Gewinn       #Spiele mit Gewinn     Lottoauszahlung(CHF)              Gewinn(CHF)";
            string line2 = "--------------------------------------------------------------------------------------------------------------------------------------";
            string line3 = "                    Fritz                        0                        2                  5000075                  5000065";
            string line4 = "                    Franz                        0                        1                       25                       20";
            string line5 = "                    Frido                        1                        0                        0                       -5";
            string line6 = "Gesamte Gewinnausschuettung: 5000100 (CHF)";
            string line7 = "Reingewinn: -5000080 (CHF)";
            string expected = $"{line1}\n{line2}\r\n{line3}\n{line4}\n{line5}\n{line6}\n{line7}\r\n";
            IReadOnlyList<int> numbers = new List<int> { 3, 4, 12, 1, 6, 20 };
            LottoNumbersChecker lottoZahlen = new LottoNumbersChecker(3, numbers);

            Player fritz = new Player("Fritz", new List<int> { 3, 4, 12, 1, 6, 20 }, 3);
            Player fritz2 = new Player("Fritz", new List<int> { 1, 2, 3, 4, 5, 6 }, 5);
            Player frido = new Player("Frido", new List<int> { 14, 15, 16, 18, 17, 19 }, 4);
            Player franz = new Player("Franz", new List<int> { 2, 4, 5, 1, 7, 20 }, 3);
            IEnumerable<Player> players = new List<Player> { fritz, fritz2, frido, franz };

            // act
            WinCalculator winCalculator = new WinCalculator(players);
            winCalculator.Calculate(lottoZahlen);

            // assert
            Assert.Equal(expected, stringWriter.ToString());
        }
    }
}
