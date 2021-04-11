using System;

namespace GildedRose
{
    class BackstageItem:Item, IItemProcessor
    {
        public BackstageItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("Backstage item processed");
        }
    }
}
