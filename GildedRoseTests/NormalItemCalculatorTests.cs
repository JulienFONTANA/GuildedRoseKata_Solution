using GildedRoseKata;
using NFluent;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class NormalItemCalculatorTests
    {
        private ICalculator Calculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            Calculator = new NormalItemCalculator();
        }

        [Test]
        public void Should_Decrease_Quality_Of_Normal_Item_When_Update_Quality_Is_Called()
        {
            var iteam = GetNormalItem();
            Calculator.UpdateQuality(iteam);
            Check.That(iteam.Quality).IsEqualTo(19);
        }

        [Test]
        public void Should_Decrease_Quality_Of_Normal_Item_Twice_When_Update_Quality_Is_Called_And_Sellin_Is_Passed()
        {
            var iteam = GetNormalItem(sellin:-2);
            Calculator.UpdateQuality(iteam);
            Check.That(iteam.Quality).IsEqualTo(18);
        }

        public Item GetNormalItem(int sellin = 10, int quality = 20)
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellin, Quality = quality };
        }
    }
}
