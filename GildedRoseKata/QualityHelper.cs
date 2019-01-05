namespace GildedRoseKata
{
    public class QualityHelper
    {
        public void IncreaseQuality(Item item, int quality = 1)
        {
            if (item.Conjured)
            {
                quality *= 2;
            }

            if (item.Quality + quality <= 50)
            {
                item.Quality += quality;
            }
            else
            {
                item.Quality = 50;
            }
        }

        public void DecreaseQuality(Item item, int quality = 1)
        {
            if (item.Conjured)
            {
                quality *= 2;
            }

            if (item.Quality - quality >= 0)
            {
                item.Quality -= quality;
            }
            else
            {
                SetQualityToZero(item);
            }
        }

        public void SetQualityToZero(Item item)
        {
            item.Quality = 0;
        }
    }
}