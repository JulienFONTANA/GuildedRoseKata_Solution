using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private GildedRose GuildedRose { get; set; }

        [SetUp]
        public void SetUp()
        {
            GuildedRose = new GildedRose();
        }

        [Test]
        public void Should_Never_Decreade_Quality_Of_Sulfuras_Updating_Quality()
        {
            GuildedRose.Items = GetItemList(GetSulfuras());
            GuildedRose.UpdateQuality();

            Check.That(GuildedRose.Items[0].Quality).IsEqualTo(80);
        }

        [Test]
        public void Should_Decreade_SellIn_Of_Normal_Item_By_One_When_Updating_Quality()
        {
            GuildedRose.Items = GetItemList(GetNormalItem());
            GuildedRose.UpdateQuality();

            Check.That(GuildedRose.Items[0].SellIn).IsEqualTo(9);
        }

        [Test]
        public void Should_Never_Decreade_SellIn_Of_Sulfuras_When_Updating_Quality()
        {
            GuildedRose.Items = GetItemList(GetSulfuras());
            GuildedRose.UpdateQuality();

            Check.That(GuildedRose.Items[0].SellIn).IsEqualTo(10);
        }

        #region Helpers
        public IList<Item> GetItemList(Item item)
        {
            return new List<Item> { item };
        }

        public Item GetNormalItem(int sellin = 10, int quality = 20)
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellin, Quality = quality };
        }

        public Item GetSulfuras(int sellin = 10, int quality = 80)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality };
        }
        #endregion
    }
}
