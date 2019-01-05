namespace GildedRoseKata
{
    public class AgedBrieCalculator : ICalculator
    {
        private QualityHelper QualityHelper { get; set; }

        public AgedBrieCalculator()
        {
            QualityHelper = new QualityHelper();
        }

        public void UpdateQuality(Item item)
        {
            var sellIn = item.SellIn;

            if (sellIn >= 0)
            {
                QualityHelper.IncreaseQuality(item);
            }
            else
            {
                QualityHelper.IncreaseQuality(item, 2);
            }
        }
    }
}
