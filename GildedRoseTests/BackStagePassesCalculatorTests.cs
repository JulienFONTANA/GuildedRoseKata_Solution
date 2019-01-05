using GildedRoseKata;
using NFluent;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class BackStagePassesCalculatorTests
    {
        private ICalculator Calculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            Calculator = new BackStagePassesCalculator();
        }

        [Test]
        public void Should_Increase_Quality_Of_Bck_Stage_Passes_By_One_When_Updating_Quality()
        {
            var bckstagePasses = GetBckstagePasses();
            Calculator.UpdateQuality(bckstagePasses);
            Check.That(bckstagePasses.Quality).IsEqualTo(1);
        }

        [Test]
        public void Should_Increase_Quality_Of_Bck_Stage_Passes_By_Two_When_Updating_Quality_And_Sellin_Between_10_And_5()
        {
            var bckstagePasses = GetBckstagePasses(sellin:8);
            Calculator.UpdateQuality(bckstagePasses);
            Check.That(bckstagePasses.Quality).IsEqualTo(2);
        }

        [Test]
        public void Should_Increase_Quality_Of_Bck_Stage_Passes_By_Three_When_Updating_Quality_And_Sellin_Between_5_And_0()
        {
            var bckstagePasses = GetBckstagePasses(sellin: 3);
            Calculator.UpdateQuality(bckstagePasses);
            Check.That(bckstagePasses.Quality).IsEqualTo(3);
        }

        [Test]
        public void Should_Increase_Quality_Of_Bck_Stage_Passes_To_Zero_Quality_And_SellIn_Is_Passed()
        {
            var bckstagePasses = GetBckstagePasses(sellin: -2);
            Calculator.UpdateQuality(bckstagePasses);
            Check.That(bckstagePasses.Quality).IsEqualTo(0);
        }

        public Item GetBckstagePasses(int sellin = 15, int quality = 0)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality };
        }
    }
}
