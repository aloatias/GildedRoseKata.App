using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTests : TestFactory
    {
        private readonly IItemFactory _itemFactory;

        public GildedRoseTests()
        {
            _itemFactory = CreateItemFactory();
        }

        [Fact]
        public void Foo()
        {
            List<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };

            var itemFactory = new ItemFactory();
            GildedRose app = new GildedRose(items, itemFactory);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void SystemCharacterizationTest()
        {
            // Prepare
            string expectedResult = InitialCharacterizationResult;

            List<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 2 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 2 },
            };

            // this conjured item does not work properly yet
            // new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}

            // Act
            var gildedRoseCore = new GildedRose(items, _itemFactory);

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

                gildedRoseCore.UpdateQuality();
            }

            var actualResult = sb.ToString();

            // Test
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact(DisplayName = "AgedBrie sub type system characterization tests")]
        public void AgedBrieCharacterizationTest()
        {
            // Prepare
            List<Item> initialItems = new List<Item>
            {
                // Kata example
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 },

                new Item { Name = "Aged Brie", SellIn = 12, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = 11, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 6, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 1 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -3, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 }
            };

            var expectedResult = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = 11, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 11 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 11 },
                new Item { Name = "Aged Brie", SellIn = 4, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -4, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = 4, Quality = 1 }
            };

            // Act
            var gildedRoseCore = new GildedRose(initialItems, _itemFactory);
            gildedRoseCore.UpdateQuality();

            // Test
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, gildedRoseCore.Items[i].Quality);
            }
        }

        [Fact(DisplayName = "BackstagePasses sub type system characterization tests")]
        public void BackstagePassesCharacterizationTest()
        {
            // Prepare
            List<Item> initialItems = new List<Item>
            {
                // Kata example
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 2 },

                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 }
            };

            var expectedResult = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 11 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 12 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 4 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -4, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 3 }
            };

            // Act
            var gildedRoseCore = new GildedRose(initialItems, _itemFactory);
            gildedRoseCore.UpdateQuality();

            // Test
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, gildedRoseCore.Items[i].Quality);
            }
        }

        [Fact(DisplayName = "Sulfuras sub type system characterization tests")]
        public void SulfurasCharacterizationTest()
        {
            // Prepare
            List<Item> initialItems = new List<Item>
            {
                // Kata example
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },

                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 49 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 2 },                   
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 12, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 11, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 6, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 1 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 0 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 0 }
            };

            var expectedResult = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 49 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 2 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 12, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 11, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 6, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 1 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 0 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 0 }
            };

            // Act
            var gildedRoseCore = new GildedRose(initialItems, _itemFactory);
            gildedRoseCore.UpdateQuality();

            // Test
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, gildedRoseCore.Items[i].Quality);
            }
        }
    }
}