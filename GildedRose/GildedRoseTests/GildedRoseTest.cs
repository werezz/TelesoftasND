using System.Collections.Generic;
using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Test]
        public void GildedRose_Should_Update_Item_Quality_List()
        {
            // Arrange
            IList<IItemProcessor> items = new List<IItemProcessor> {
                new CommonItem("+5 Dexterity Vest", 10, 20),
                new AgedItem("Aged Brie",2,0),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert",15,20),
                new ConjuredItem("Conjured Mana Cake",3,6)};

            // Act
            var itemProcessor = new GildedRoseProcess(items);
            itemProcessor.UpdateQuality();

            // Assert
            Assert.AreEqual("+5 Dexterity Vest, 9, 19",items[0].ShowItemInfo());
            Assert.AreEqual("Aged Brie, 1, 1", items[1].ShowItemInfo());
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 0, 80", items[2].ShowItemInfo());
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, 14, 21", items[3].ShowItemInfo());
            Assert.AreEqual("Conjured Mana Cake, 2, 4", items[4].ShowItemInfo());

        }

        [Test]
        public void Updating_Common_Item_Quality_Should_Decrease()
        {
            // Arrange
            var commonItem = new CommonItem("+5 Dexterity Vest", 10, 20);

            // Act
            commonItem.UpdateQuality();

            // Assert
            Assert.AreEqual(commonItem.Quality, 19);
            Assert.AreEqual(commonItem.SellIn, 9);
        }

        [Test]
        public void Updating_Common_Item_After_Sell_Date_Quality_Should_Decrease_Twice_As_Fast()
        {
            // Arrange
            var commonItem = new CommonItem("+5 Dexterity Vest", 0, 10);

            // Act
            commonItem.UpdateQuality();

            // Assert
            Assert.AreEqual(commonItem.Quality, 8);
            Assert.AreEqual(commonItem.SellIn, -1);
        }

        [Test]
        public void Updating_Legendary_Item_Quality_Should_Not_Decrease()
        {
            // Arrange
            var legendaryItem = new  LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80);

            // Act
            legendaryItem.UpdateQuality();

            // Assert
            Assert.AreEqual(legendaryItem.Quality, 80);
            Assert.AreEqual(legendaryItem.SellIn, 0);
        }

        [Test]
        public void Updating_The_Quality_Of_An_Item_Should_Never_Be_Negative()
        {
            // Arrange
            var commonItem = new CommonItem("+5 Dexterity Vest", 0, 0);
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 20, 0);
            var agedItem = new AgedItem("Aged Brie", 2, 0);
            var conjuredItem = new ConjuredItem("Conjured Mana Cake", 3, 0);
            var legendaryItem = new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80);

            // Act
            commonItem.UpdateQuality();
            backstageItem.UpdateQuality();
            agedItem.UpdateQuality();
            conjuredItem.UpdateQuality();
            legendaryItem.UpdateQuality();

            // Assert
            Assert.AreEqual(commonItem.Quality, 0);
            Assert.AreEqual(backstageItem.Quality, 1);
            Assert.AreEqual(agedItem.Quality, 1);
            Assert.AreEqual(conjuredItem.Quality, 0);
            Assert.AreEqual(legendaryItem.Quality, 80);
        }

        [Test]
        public void Aged_Item_Quality_Should_Increase_The_Older_It_Gets()
        {
            // Arrange
            var agedItem = new AgedItem("Aged Brie", 2, 0);

            // Act
            agedItem.UpdateQuality();

            // Assert
            Assert.AreEqual(agedItem.Quality, 1);
            Assert.AreEqual(agedItem.SellIn, 1);
        }

        [Test]
        public void Aged_Item_Quality_Should_Increase_The_Older_It_Gets_Twice_As_Fast_After_Sell_Date()
        {
            // Arrange
            var agedItem = new AgedItem("Aged Brie", 0, 0);

            // Act
            agedItem.UpdateQuality();

            // Assert
            Assert.AreEqual(agedItem.Quality, 2);
        }

        [Test]
        public void The_Quality_Of_An_Item_Should_Never_Be_More_Than_50_For_BackStage_And_Aged_Items()
        {
            // Arrange
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 20, 50);
            var agedItem = new AgedItem("Aged Brie", 2, 50);

            // Act
            backstageItem.UpdateQuality();
            agedItem.UpdateQuality();

            // Assert
            Assert.AreEqual(backstageItem.Quality, 50);
            Assert.AreEqual(agedItem.Quality, 50);
        }

        [Test]
        public void Conjured_Items_Should_Degrade_In_Quality_Twice_As_Fast_As_Normal_Items()
        {
            // Arrange
            var conjuredItem = new ConjuredItem("Conjured Mana Cake", 3, 6);

            // Act
            conjuredItem.UpdateQuality();

            // Assert
            Assert.AreEqual(conjuredItem.Quality, 4);
            Assert.AreEqual(conjuredItem.SellIn, 2);
        }

        [Test]
        public void Conjured_Items_Should_Degrade_In_Quality_Four_Times_As_Fast_As_Normal_Items_After_Sell_Date()
        {
            // Arrange
            var conjuredItem = new ConjuredItem("Conjured Mana Cake", 0, 6);

            // Act
            conjuredItem.UpdateQuality();

            // Assert
            Assert.AreEqual(conjuredItem.Quality, 2);
        }

        [Test]
        public void Backstage_Item_Should_Increases_Quality_As_Its_SellIn_Value_pproaches()
        {
            // Arrange
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 15, 40);

            // Act
            backstageItem.UpdateQuality();

            // Assert
            Assert.AreEqual(backstageItem.Quality, 41);
        }

        [Test]
        public void Backstage_Item_Should_Increase_By_2_In_Quality_As_Its_SellIn_Value_pproaches_10_days()
        {
            // Arrange
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 10, 40);

            // Act
            backstageItem.UpdateQuality();

            // Assert
            Assert.AreEqual(backstageItem.Quality, 42);
        }

        [Test]
        public void Backstage_Item_Should_Increase_By_3_In_Quality_As_Its_SellIn_Value_pproaches_5_days()
        {
            // Arrange
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 5, 40);

            // Act
            backstageItem.UpdateQuality();

            // Assert
            Assert.AreEqual(backstageItem.Quality, 43);
        }

        [Test]
        public void Backstage_Item_Should_Drop_To_Zero_Quality_As_Its_SellIn_Value_passes()
        {
            // Arrange
            var backstageItem = new BackstageItem("Backstage passes to a TAFKAL80ETC concert", -1, 40);

            // Act
            backstageItem.UpdateQuality();

            // Assert
            Assert.AreEqual(backstageItem.Quality, 0);
        }
    }
}