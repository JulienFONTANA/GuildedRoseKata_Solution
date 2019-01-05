namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public bool Conjured { get; set; }

        public override string ToString()
        {
            return Conjured == true ? 
                "[Conjured] " + Name + ", " + SellIn + ", " + Quality
                : Name + ", " + SellIn + ", " + Quality;
        }  
    }
}
