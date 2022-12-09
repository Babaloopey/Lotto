using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Lotto
{
    public class WinCalculator
    {
        IEnumerable<Player> Players;

        public List<PlayerStatistics> PlayerStatisticsList = new List<PlayerStatistics>();
        LottoNumbersChecker LotteryNumbersChecker;
        TablePrinter TablePrinter = new TablePrinter();
        LottoNumbersValidator LottoNumbersValidator = new LottoNumbersValidator();

        public WinCalculator(IEnumerable<Player> players)
        {
            this.Players = players;
        }

        public void Calculate(LottoNumbersChecker realNumbers)
        {
            if (realNumbers != null)
            {
                LotteryNumbersChecker = realNumbers;
            }

            foreach (Player player in Players)
            {
                if (AreNumbersFromPlayerValid(player))
                { 
                    Profit profit = CalculateProfit(player);

                    CreateOrUpdatePlayerStatistic(player, profit);
                }
                else
                {
                    Console.WriteLine(player.Name + " hat einmal mit ungültigen Lottozahlen gespielt");
                }
            }

            PrintTableWithStatistics();
        }
        private bool AreNumbersFromPlayerValid(Player player)
        {
            return (LottoNumbersValidator.AreLottoNumbersValid(player.LottoNumbers) && LottoNumbersValidator.IsLuckyNumberValid(player.LuckyNumber));
        }
        private Profit CalculateProfit(Player player)
        {
            bool isLuckyNumberCorrect = LotteryNumbersChecker.CheckLuckyNumberCorrect(player.LuckyNumber);
            int correctLottoNumbers = LotteryNumbersChecker.CheckNumberOfMatchingLottoNumbers(player.LottoNumbers);

            return new Profit(correctLottoNumbers, isLuckyNumberCorrect);
        }

        private void CreateOrUpdatePlayerStatistic(Player player, Profit profit)
        {
            bool doesPlayerAlreadyExist = false;
            foreach (PlayerStatistics p in PlayerStatisticsList)
            {
                if (p.Name == player.Name)
                {
                    UpdatePlayerStatistic(p, player, profit);
                    doesPlayerAlreadyExist = true;
                }
            }

            if (doesPlayerAlreadyExist == false)
            {
                CreatePlayerStatistic(player, profit);
            }
        }

        public void UpdatePlayerStatistic(PlayerStatistics p, Player player, Profit profit)
        {
            p.AddProfit(profit);
            p.AddLuckyNumber(player.LuckyNumber);
            p.AddLottoNumbers(player.LottoNumbers);
        }

        public void CreatePlayerStatistic(Player player, Profit profit)
        {
            PlayerStatistics playerStatistics = new PlayerStatistics(player);
            playerStatistics.AddProfit(profit);
            PlayerStatisticsList.Add(playerStatistics);
        }

        private void PrintTableWithStatistics()
        {
            TablePrinter.SetPlayerStatisticsList(PlayerStatisticsList);
            TablePrinter.OrderEntries();
            Console.WriteLine(TablePrinter.PrintHeader());
            Console.WriteLine(TablePrinter.PrintTable());
        }
    }
}