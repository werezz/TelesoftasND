using System;

namespace GildedRose.Items
{
    class AgedItem:Item, IItemProcessor
    {
        public AgedItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("Aged item processed");
        }
    }
}
