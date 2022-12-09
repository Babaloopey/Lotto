using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lotto.Tests
{
    public class TablePrinterTest
    {
        [Fact]
        public void PrintHeaderTest()
        {
            // arrange
            TablePrinter tablePrinter = new TablePrinter();
            string expectedHeader = String.Format("{0,25}{1,25}{2,25}{3,25}{4,25}", "Name", "#Spiele ohne Gewinn",
                "#Spiele mit Gewinn", "Lottoauszahlung(CHF)",
                "Gewinn(CHF)") +
                "\n--------------------------------------------------------------------------------------------------------------------------------------";
            
            // act
            string actualHeader = tablePrinter.PrintHeader();
            
            // assert
            Assert.Equal(expectedHeader, actualHeader);
        }

        [Fact]
        public void PrintTableTest()
        {
            // arrange
            TablePrinter tablePrinter = new TablePrinter();
            IEnumerable<int> testLottoNumbers = new[] {2, 18, 6, 5, 11, 3};
            Player testPlayer = new Player("Luis Gjokaj", testLottoNumbers, 2);
            PlayerStatistics testPlayerStatistics = new PlayerStatistics(testPlayer);

            testPlayerStatistics.GamesPlayed = 2;
            testPlayerStatistics.GamesWithoutProfit = 1;
            testPlayerStatistics.GamesWithProfit = 1;
            testPlayerStatistics.LotteryPayout = 2;
            List<PlayerStatistics> testList = new List<PlayerStatistics>();

            testList.Add(testPlayerStatistics);
            string expectedTable = String.Format("{0,25}{1,25}{2,25}{3,25}{4,25}", "Luis Gjokaj",
                "1", "1",
                "2", "-8") + "\n" + "Gesamte Gewinnausschuettung: " + 2 + " (CHF)\n" + "Reingewinn: " + 8 + " (CHF)";
            
            // act
            tablePrinter.SetPlayerStatisticsList(testList);
            string actualTable = tablePrinter.PrintTable();
            
            // assert
            Assert.Equal(expectedTable, actualTable);
        }
    }
}
