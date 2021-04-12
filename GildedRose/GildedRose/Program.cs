using GildedRose.Items;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<IItemProcessor> items = new List<IItemProcessor> {
                new CommonItem("+5 Dexterity Vest", 10, 20),
                new AgedItem("Aged Brie",2,0),
                new CommonItem("Elixir of the Mongoose",5,7),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", -1, 80),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert",15,20),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert",10,49),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert",5,49),
                new ConjuredItem("Conjured Mana Cake",3,6)};

            var itemProcessor = new GildedRoseProcess(items);


            for (var i = 0; i < Constants.MonthCycle; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    items[j].ShowItemInfo();
                }
                Console.WriteLine("");
                itemProcessor.UpdateQuality();

                Console.ReadKey();
            }
        }
    }
}
