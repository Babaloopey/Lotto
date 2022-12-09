using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class TablePrinter
    {
        List<PlayerStatistics> PlayerStatisticsList = new List<PlayerStatistics>();

        public TablePrinter() { }

        public void SetPlayerStatisticsList(List<PlayerStatistics> playerStatisticsList)
        {
            PlayerStatisticsList = playerStatisticsList;
        }

        public string PrintHeader()
        {
            return String.Format("{0,25}{1,25}{2,25}{3,25}{4,25}",
                    "Name", "#Spiele ohne Gewinn", "#Spiele mit Gewinn", "Lottoauszahlung(CHF)", "Gewinn(CHF)") +
                    "\n--------------------------------------------------------------------------------------------------------------------------------------";
        }

        public string PrintTable()
        {
            int totalWinnings = 0;
            int netProfit = 0;

            string printedTable = "";

            foreach (PlayerStatistics playerStatistics in PlayerStatisticsList)
            {
                printedTable += String.Format("{0,25}{1,25}{2,25}{3,25}{4,25}", playerStatistics.Name,
                       playerStatistics.GamesWithoutProfit, playerStatistics.GamesWithProfit,
                       playerStatistics.LotteryPayout, playerStatistics.GetTotalWinnings()) + "\n";

                totalWinnings += playerStatistics.LotteryPayout;
                netProfit -= playerStatistics.GetTotalWinnings();
            }
            printedTable += "Gesamte Gewinnausschuettung: " + totalWinnings + " (CHF)\n";
            printedTable += "Reingewinn: " + netProfit + " (CHF)";
            return printedTable;
        }

        public void OrderEntries()
        {
            PlayerStatisticsList = PlayerStatisticsList.OrderBy(p => -p.GetTotalWinnings()).ToList();
        }
    }
}
