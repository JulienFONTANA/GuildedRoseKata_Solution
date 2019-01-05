using GildedRoseKata;
using NFluent;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class AgedBrieCalculatorTests
    {
        private ICalculator Calculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            Calculator = new AgedBrieCalculator();
        }

        [Test]
        public void Should_Quality_Of_Aged_Brie_Increase_When_Update_Quality_Is_Called()
        {
            var agedBrie = GetAgedBrie();
            Calculator.UpdateQuality(agedBrie);
            Check.That(agedBrie.Quality).IsEqualTo(1);
        }

        [Test]
        public void Should_Quality_Of_Aged_Brie_Increase_Twice_When_Update_Quality_Is_Called_And_Sellin_Is_Passed()
        {
            var agedBrie = GetAgedBrie(sellin:-2);
            Calculator.UpdateQuality(agedBrie);
            Check.That(agedBrie.Quality).IsEqualTo(2);
        }

        public Item GetAgedBrie(int sellin = 2, int quality = 0)
        {
            return new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality };
        }
    }
}
