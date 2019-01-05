using GildedRoseKata;
using NFluent;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class QualityHelperTests
    {
        private QualityHelper QualityHelper { get; set; }

        [SetUp]
        public void SetUp()
        {
            QualityHelper = new QualityHelper();
        }

        [Test]
        public void Should_Increase_Quality_When_IncreaseQuality_Is_Called()
        {
            var item = GetItem();
            QualityHelper.IncreaseQuality(item);
            Check.That(item.Quality).IsEqualTo(11);
        }

        [Test]
        public void Should_Never_Increase_Quality_Over_50_When_IncreaseQuality_Is_Called()
        {
            var item = GetItem(quality:50);
            QualityHelper.IncreaseQuality(item, 5);
            Check.That(item.Quality).IsEqualTo(50);
        }

        [Test]
        public void Should_Decrease_Quality_When_DecreaseQuality_Is_Called()
        {
            var item = GetItem();
            QualityHelper.DecreaseQuality(item);
            Check.That(item.Quality).IsEqualTo(9);
        }

        [Test]
        public void Should_Decrease_Quality_Under_Zero_When_DecreaseQuality_Is_Called()
        {
            var item = GetItem(quality:0);
            QualityHelper.DecreaseQuality(item, 4);
            Check.That(item.Quality).IsEqualTo(0);
        }

        [Test]
        public void Should_Set_Quality_To_Zero_When_SetQualityToZero_Is_Called()
        {
            var item = GetItem();
            QualityHelper.SetQualityToZero(item);
            Check.That(item.Quality).IsEqualTo(0);
        }

        [Test]
        public void Should_Decrease_Quality_Twice_As_Fast_For_Conjured_Items_When_DecreaseQuality_Is_Called()
        {
            var item = GetItem(conjured:true);
            QualityHelper.DecreaseQuality(item);
            Check.That(item.Quality).IsEqualTo(8);
        }

        [Test]
        public void Should_Increase_Quality_Twice_As_Fast_For_Conjured_Items_When_IncreaseQuality_Is_Called()
        {
            var item = GetItem(conjured: true);
            QualityHelper.IncreaseQuality(item);
            Check.That(item.Quality).IsEqualTo(12);
        }

        public Item GetItem(int sellin = 10, int quality = 10, bool conjured = false)
        {
            return new Item { Name = "Normal Item", SellIn = sellin, Quality = quality, Conjured = conjured };
        }
    }
}
