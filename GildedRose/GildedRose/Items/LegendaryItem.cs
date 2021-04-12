using System;

namespace GildedRose
{
    public class LegendaryItem: Item, IItemProcessor
    {
        public LegendaryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            //Do nothing, legendary item Quality never alters or needs to be sold.
        }

        public string ShowItemInfo()
        {
            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine("");

            return Name + ", " + SellIn + ", " + Quality;
        }
    }
}
