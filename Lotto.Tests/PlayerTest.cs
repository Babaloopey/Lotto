using Xunit;

namespace Lotto.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void ToString_MustReturnName()
        {
            var name = "Peter Pan";
            var numbers = new[] { 1, 2, 3 };
            var luckyNumber = 2;

            var player = new Player(name, numbers, luckyNumber);

            Assert.Equal("Peter Pan", player.ToString());
        }
    }
}