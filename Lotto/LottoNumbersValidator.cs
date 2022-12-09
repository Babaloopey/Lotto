using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class LottoNumbersValidator
    {
        public LottoNumbersValidator() { }

        public bool AreLottoNumbersValid(IEnumerable<int> lottoNumbers)
        {
            foreach (int lottoNumber in lottoNumbers)
            {
               if(IsLottoNumberInRange(lottoNumber))
                {
                    return false;
                }
            }

            IEnumerable<int> duplicates = GetDuplicateNumbers(lottoNumbers);

            if (duplicates.Any())
            {
                return false;
            }

            return true;
        }

        private bool IsLottoNumberInRange(int lottoNumber)
        {
            return (lottoNumber < 1 || lottoNumber > 22);
        }

        private IEnumerable<int> GetDuplicateNumbers(IEnumerable<int> lottoNumbers)
        {
            HashSet<int> hashSet = new HashSet<int>();
            return lottoNumbers.Where(e => !hashSet.Add(e));
        }

        public bool IsLuckyNumberValid(int luckyNumber)
        {
            return IsLuckyNumberInRange(luckyNumber) ? true : false;
        }

        private bool IsLuckyNumberInRange(int luckyNumber)
        {
            return (luckyNumber >=  1 && luckyNumber <= 6);
        }
    }
}
