using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }
        private readonly IDictionary<string, ICalculator> Calculators = new Dictionary<string, ICalculator>
        {
            { "Backstage passes to a TAFKAL80ETC concert", new BackStagePassesCalculator() },
            { "Aged Brie", new AgedBrieCalculator() },
            { "NormalItem", new NormalItemCalculator() }
        };

        public GildedRose() { }

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            var keyList = Calculators.Keys;

            foreach (var item in Items.Where(x => x.Name != "Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn -= 1;

                if (keyList.Any(x => x == item.Name))
                {
                    Calculators[item.Name].UpdateQuality(item);
                }
                else
                {
                    Calculators["NormalItem"].UpdateQuality(item);
                }
            }
        }
    }
}
