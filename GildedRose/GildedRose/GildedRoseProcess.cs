using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseProcess
    {
        private IList<IItemProcessor> Items;

        public GildedRoseProcess(IList<IItemProcessor> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQuality();
            }
        }
    }
}
