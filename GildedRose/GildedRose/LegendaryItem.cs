using System;

namespace GildedRose
{
    class LegendaryItem: Item, IItemProcessor
    {
        public void UpdateQuality()
        {
            Console.WriteLine("Legendary item processed");
        }
    }
}
