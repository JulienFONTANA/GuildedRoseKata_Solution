namespace GildedRoseKata
{
    public class NormalItemCalculator : ICalculator
    {
        private QualityHelper QualityHelper { get; set; }

        public NormalItemCalculator()
        {
            QualityHelper = new QualityHelper();
        }

        public void UpdateQuality(Item item)
        {
            var sellIn = item.SellIn;

            if (sellIn >= 0)
            {
                QualityHelper.DecreaseQuality(item);
            }
            else
            {
                QualityHelper.DecreaseQuality(item, 2);
            }
        }
    }
}
