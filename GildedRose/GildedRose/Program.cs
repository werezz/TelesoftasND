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

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            //var common = new CommonItem("+5 Dexterity Vest",10,20);
            //var legendary = new LegendaryItem("Sulfuras, Hand of Ragnaros",0,80);

            IList<IItemProcessor> testPro = new List<IItemProcessor> {
                new CommonItem("+5 Dexterity Vest", 10, 20),
                new AgedItem("Aged Brie",2,0),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert",15,20),
                new ConjuredItem("Conjured Mana Cake",3,6)};
            //testPro.Add(common);
            //testPro.Add(legendary);
            testPro[0].UpdateQuality();
            testPro[1].UpdateQuality();
            testPro[2].UpdateQuality();
            testPro[3].UpdateQuality();
            testPro[4].UpdateQuality();

            var itemProcessor = new GildedRoseProcess(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                itemProcessor.UpdateQuality();

                Console.ReadKey();
            }
        }
    }
}
