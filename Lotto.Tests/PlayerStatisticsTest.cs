using Lotto;
using Xunit;

namespace Lotto.Tests;
public class PlayerStatisticsTest
{
    [Fact]
    public void AmountOfGamesTest()
    {
        // arrange
        Player playerTest = new Player("Peter Pan", new[] { 1, 2, 3, 4, 5, 6 }, 4);

        Profit profit = new Profit(0, true);
        Profit profit2 = new Profit(5, false);

        var expectedGamesWithProfit = 1;
        var expectedGamesWithoutProfit = 1;
        var expectedTotalGamesPlayed = 2;

        // act
        var player = new PlayerStatistics(playerTest);
        player.AddProfit(profit);
        player.AddProfit(profit2);

        // assert
        Assert.Equal(expectedGamesWithProfit, player.GamesWithProfit);
        Assert.Equal(expectedGamesWithoutProfit, player.GamesWithoutProfit);
        Assert.Equal(expectedTotalGamesPlayed, player.GamesPlayed);
    }

    [Fact]
    public void WinningsTest()
    {
        // arrange
        Player playerTest = new Player("Peter Pan", new[] { 1, 2, 3, 4, 5, 6 }, 4);

        Profit profit = new Profit(0, true);
        Profit profit2 = new Profit(5, false);

        var expectedTotalWinnings = 990;
        var expectedLotteryPayout = 1000;

        // act
        var player = new PlayerStatistics(playerTest);
        player.AddProfit(profit);
        player.AddProfit(profit2);

        // assert
        Assert.Equal(expectedTotalWinnings, player.GetTotalWinnings());
        Assert.Equal(expectedLotteryPayout, player.LotteryPayout);
    }
}