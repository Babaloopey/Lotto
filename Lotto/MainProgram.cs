using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            WinCalculator winCalculator = new WinCalculator(ReadPlayers(args[0]));
            Console.Write("Filepath der Lottozahlen: ");
            winCalculator.Calculate(ReadGivenNumbers(Console.ReadLine()));
        }
        private static IEnumerable<Player> ReadPlayers(string jsonPath)
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();

                IEnumerable<Player> players = JsonConvert.DeserializeObject<IEnumerable<Player>>(json);

                return players;
            }
        }

        private static LottoNumbersChecker ReadGivenNumbers(string numberPath)
        {
            try
            {
                using (StreamReader r = new StreamReader(numberPath))
                {
                    string json = r.ReadToEnd();

                    LottoNumbersChecker numbers = JsonConvert.DeserializeObject<LottoNumbersChecker>(json);

                    return numbers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Fahre mit standardmässigen Lottozahlen fort");
                LottoNumbersChecker lotteryNumbersChecker = new LottoNumbersChecker(3, new List<int> { 3, 4, 12, 1, 6, 20 });
                return lotteryNumbersChecker;
            }
        }
    }
}
