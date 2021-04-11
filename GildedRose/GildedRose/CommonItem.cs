using System;

namespace GildedRose
{
    class CommonItem : Item, IItemProcessor
    {
        public void UpdateQuality()
        {
            Console.WriteLine("Commont item processed");
        }
    }
}
