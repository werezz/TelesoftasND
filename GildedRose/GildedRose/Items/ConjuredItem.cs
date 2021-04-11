using System;

namespace GildedRose
{
    class ConjuredItem:Item, IItemProcessor
    {
        public ConjuredItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("Conjured item processed");
        }
    }
}
