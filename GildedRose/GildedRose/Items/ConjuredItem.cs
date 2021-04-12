using System;

namespace GildedRose
{
    public class ConjuredItem:Item, IItemProcessor
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
        }

        public string ShowItemInfo()
        {
            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine("");

            return Name + ", " + SellIn + ", " + Quality;
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
