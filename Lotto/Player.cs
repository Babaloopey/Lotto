namespace Lotto
{
    public class Player
    {
        public Player(string name, IEnumerable<int> lottoNumbers, int luckyNumber)
        {
            Name = name;
            LottoNumbers = lottoNumbers;
            LuckyNumber = luckyNumber;
        }

        public string Name { get; }
        public IEnumerable<int> LottoNumbers { get; }
        public int LuckyNumber { get; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
