﻿using Xunit;
using System.Collections.Generic;
using GildedRoseKata.App.Models;
using GildedRoseKata.App.Core;
using System.Text;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTests : TestFactory
    {
        [Fact]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void SystemCharacterization_Test()
        {
            // Prepare
            string expectedResult = InitialCharacterizationResult;

            IList<Item> Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
            };

			// this conjured item does not work properly yet
			// new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}

            // Act
            var gildedRoseCore = new GildedRose(Items);
            gildedRoseCore.UpdateQuality();

            var sb = new StringBuilder();
            for (var i = 0; i < 31; i++)
            {
                sb.AppendLine("-------- day " + i + " --------");
                sb.AppendLine("name, sellIn, quality");
                for (var j = 0; j < gildedRoseCore.Items.Count; j++)
                {
                    sb.AppendLine(gildedRoseCore.Items[j].Name + ", " + gildedRoseCore.Items[j].SellIn + ", " + gildedRoseCore.Items[j].Quality);
                }

                sb.AppendLine("");
            }

            var actualResult = sb.ToString();
            
            // Test
            Assert.Equal(expectedResult, actualResult);
        }
    }
}