using System.Collections.Generic;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseProcess app = new GildedRoseProcess(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
    }
}