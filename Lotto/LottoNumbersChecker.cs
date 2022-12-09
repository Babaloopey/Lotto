using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class LottoNumbersChecker
    {
        public int LottoLuckyNumber;
        public IReadOnlyList<int> LottoNumbers;

        public LottoNumbersChecker(int lottoLuckyNumber, IReadOnlyList<int> lottoNumbers)
        {
            LottoLuckyNumber = lottoLuckyNumber;
            LottoNumbers = lottoNumbers;
        }

        public bool CheckLuckyNumberCorrect(int playerLuckyNumber)
        {
            return playerLuckyNumber == LottoLuckyNumber ? true : false;
        }

        public int CheckNumberOfMatchingLottoNumbers(IEnumerable<int> playerLottoNumbers)
        {
            IEnumerable<int> matchingNumbers = playerLottoNumbers.Intersect(LottoNumbers);
            return matchingNumbers.Count();
        }
    }
}

