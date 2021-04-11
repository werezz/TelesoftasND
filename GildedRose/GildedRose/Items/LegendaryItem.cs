using System;

namespace GildedRose
{
    class LegendaryItem: Item, IItemProcessor
    {
        public LegendaryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("Legendary item processed");
        }
    }
}
