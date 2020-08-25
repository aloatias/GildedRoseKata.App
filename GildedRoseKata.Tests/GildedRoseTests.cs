using Xunit;
using System.Collections.Generic;
using GildedRoseKata.App.Models;
using GildedRoseKata.App.Core;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}