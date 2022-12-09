using Lotto;

public class PlayerStatistics
{
    private const int PRICEPERGAME = 5;
    public PlayerStatistics(Player player)
    {
        Name = player.Name;
        LottoNumbers.Add(player.LottoNumbers);
        LuckyNumber.Add(player.LuckyNumber);
    }

    public string Name { get; }
    private List<IEnumerable<int>> LottoNumbers { get; } = new List<IEnumerable<int>>();
    private List<int> LuckyNumber { get; } = new List<int>();

    public int GamesWithoutProfit { get; set; }
    public int GamesWithProfit { get; set; }
    public int GamesPlayed { get; set; }
    public int LotteryPayout { get; set; }

    public override string ToString()
    {
        return $"{this.Name}";
    }

    public void AddProfit(Profit profit)
    {
        if (profit.GetValue() != 0)
        {
            LotteryPayout += profit.GetValue();
            PlayedGameWithProfit();
        }
        else
        {
            PlayedGameWithoutProfit();
        }
    }

    private void PlayedGameWithProfit()
    {
        GamesWithProfit++;
        GamesPlayed++;
    }

    private void PlayedGameWithoutProfit()
    {
        GamesWithoutProfit++;
        GamesPlayed++;
    }

    public int GetTotalWinnings()
    {
        return (LotteryPayout - GamesPlayed * PRICEPERGAME);
    }

    public void AddLottoNumbers(IEnumerable<int> lottoNumbers)
    {
        LottoNumbers.Add(lottoNumbers);
        
    }

    public void AddLuckyNumber(int luckyNumber)
    {
        LuckyNumber.Add(luckyNumber);
    }
}