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
            UpdateCommonItemQuality();
            --SellIn;    
        }

        public void ShowItemInfo()
        {
            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine("");
        }

        private int UpdateCommonItemQuality()
        {
            if (SellIn <= 0 && !CheckIfItemQualityIsZero())
            {
                return Quality -= 2;
            }
            else if (Quality > 0 && !CheckIfItemQualityIsZero())
            {
                return --Quality;
            }

            return Quality;
        }

        private bool CheckIfItemQualityIsZero()
        {
            if (Quality <= 0)
            {
                Quality = 0;
                return true;
            }

            return false;
        }
    }   
}
