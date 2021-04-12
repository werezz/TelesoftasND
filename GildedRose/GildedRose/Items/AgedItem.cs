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
            UpdateAgedItemQuality();
            --SellIn;
        }

        public void ShowItemInfo()
        {
            Console.Write(Name + ", " + SellIn + ", " + Quality);
            Console.WriteLine("");
        }

        private int UpdateAgedItemQuality()
        {
            if (SellIn <= 0 && !CheckIfItemQualityIsMax())
            {
                return Quality += 2;
            }
            else if (Quality > 0 && CheckIfItemQualityIsMax())
            {
                return Quality = Constants.MaxItemQuality;
            }

            return ++Quality;
        }
    
        private bool CheckIfItemQualityIsMax()
        {
            if (Quality >= Constants.MaxItemQuality)
            {  
                return true;
            }

            return false;
        }
    }
}
