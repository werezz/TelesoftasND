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
            UpdateCommonItemQuality();
            --SellIn;

            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine(" Conjured item processed");
        }

        private int UpdateCommonItemQuality()
        {
            if (SellIn <= 0 && !CheckIfItemQualityIsZero())
            {
                return Quality -= 4;
            }
            else if (Quality > 0 && !CheckIfItemQualityIsZero())
            {
                return Quality -= 2;
            }

            return Quality = 0;
        }

        private bool CheckIfItemQualityIsZero()
        {
            if (Quality <= 0)
            {              
                return true;
            }

            return false;
        }
    }
}
