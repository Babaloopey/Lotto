using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class Profit
    {
        private int Value;

        private enum Winnings
        {
            SixWithLuckyNumber = 5000000,
            SixWithoutLuckyNumber = 1000000,
            FiveWithLuckyNumber = 10000,
            FiveWithoutLuckyNumber = 1000,
            FourWithLuckyNumber = 150,
            FourWithoutLuckyNumber = 75,
            ThreeWithLuckyNumber = 25,
            ThreeWithoutLuckyNumber = 10,
            TwoWithLuckyNumber = 5,
            TwoWithoutLuckyNumber = 2
        }

        public Profit(int correctLottoNumbers, bool isLuckyNumberCorrect)
        {

            if(correctLottoNumbers > 1)
            {
                switch (correctLottoNumbers)
                {
                    case 2:
                        Value = TwoNumbersCorrect(isLuckyNumberCorrect);
                        break;
                    case 3:
                        Value = ThreeNumbersCorrect(isLuckyNumberCorrect);
                        break;
                    case 4:
                        Value = FourNumbersCorrect(isLuckyNumberCorrect);
                        break;
                    case 5:
                        Value = FiveNumbersCorrect(isLuckyNumberCorrect);
                        break;
                    case 6:
                        Value = SixNumbersCorrect(isLuckyNumberCorrect);
                        break;
                }
            } else
            {
                Value = 0;
            }   
        }
        private int TwoNumbersCorrect(bool isLuckyNumberCorrect)
        {
            return isLuckyNumberCorrect ? ((int)Winnings.TwoWithLuckyNumber) : ((int)Winnings.TwoWithoutLuckyNumber);
        }

        private int ThreeNumbersCorrect(bool isLuckyNumberCorrect)
        {
            return isLuckyNumberCorrect ? ((int)Winnings.ThreeWithLuckyNumber) : ((int)Winnings.ThreeWithoutLuckyNumber);
        }
        private int FourNumbersCorrect(bool isLuckyNumberCorrect)
        {
            return isLuckyNumberCorrect ? ((int)Winnings.FourWithLuckyNumber) : ((int)Winnings.FourWithoutLuckyNumber);
        }
        private int FiveNumbersCorrect(bool isLuckyNumberCorrect)
        {
            return isLuckyNumberCorrect ? ((int)Winnings.FiveWithLuckyNumber) : ((int)Winnings.FiveWithoutLuckyNumber);
        }
        private int SixNumbersCorrect(bool isLuckyNumberCorrect)
        {
            return isLuckyNumberCorrect ? ((int)Winnings.SixWithLuckyNumber) : ((int)Winnings.SixWithoutLuckyNumber);
        }

        public int GetValue()
        {
            return Value;
        }
    }
}
