namespace GildedRoseKata
{
    public class BackStagePassesCalculator : ICalculator
    {
        private QualityHelper QualityHelper { get; set; }

        public BackStagePassesCalculator()
        {
            QualityHelper = new QualityHelper();
        }

        public void UpdateQuality(Item item)
        {
            var sellInDate = item.SellIn;

            if (sellInDate < 0)
            {
                QualityHelper.SetQualityToZero(item);
            }
            else if (sellInDate < 5)
            {
                QualityHelper.IncreaseQuality(item, 3);
            }
            else if (sellInDate < 10)
            {
                QualityHelper.IncreaseQuality(item, 2);
            }
            else
            {
                QualityHelper.IncreaseQuality(item);
            }
        }
    }
}
