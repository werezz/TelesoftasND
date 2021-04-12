using System;

namespace GildedRose
{
    public class BackstageItem:Item, IItemProcessor
    {
        public BackstageItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            UpdateBackstageItemQuality();
            --SellIn;
        }

        public string ShowItemInfo()
        {
            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine("");

            return Name + ", " + SellIn + ", " + Quality;
        }

        private int UpdateBackstageItemQuality()
        {
            if (CheckIfQualityIsLessThenMax() && SellIn >= 0)
            {
                ++Quality;

                if (CheckIfSellInIsFiveDaysLeft())
                {
                    if (CheckIfQualityIsLessThenMax())
                    {
                        return Quality += 2;
                    }
                }

                if (CheckIfSellInIsTenDaysLeft())
                {
                    if (CheckIfQualityIsLessThenMax())
                    {
                        return ++Quality;
                    }
                }
            }
            else if(SellIn<=0)
            {
                return Quality = 0;
            }
            return Quality;
        }

        private bool CheckIfSellInIsTenDaysLeft()
        {
            if (SellIn < 11)
                return true;
            return false;
        }

        private bool CheckIfSellInIsFiveDaysLeft()
        {
            if (SellIn < 6)
                return true;
            return false;
        }

        private bool CheckIfQualityIsLessThenMax()
        {
            if (Quality < Constants.MaxItemQuality)
                return true;
            return false;
        }
    }
}
