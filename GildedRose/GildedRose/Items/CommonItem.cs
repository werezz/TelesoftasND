using System;

namespace GildedRose
{
    class CommonItem : Item, IItemProcessor
    {
        public CommonItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("Commont item processed");
        }
    }
}
