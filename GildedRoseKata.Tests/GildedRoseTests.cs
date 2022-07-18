using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTests : TestBase
    {
        private readonly GildedRose _gildedRose;

        public GildedRoseTests()
        {
            _gildedRose = CreateGildedRose();
        }

        [Fact]
        public void Foo()
        {
            var items = new List<ItemBase> { new ItemBase { Name = "foo", Sellin = 0, Quality = 0 } };
            _gildedRose.SetItems(items);
            _gildedRose.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void SystemCharacterizationTest()
        {
            // Prepare
            string expectedResult = InitialCharacterizationResult;

            var items = new List<ItemBase>
            {
                new ItemBase { Name = "+5 Dexterity Vest", Sellin = 10, Quality = 20 },
                new ItemBase { Name = "Aged Brie", Sellin = 2, Quality = 0 },
                new ItemBase { Name = "Aged Brie", Sellin = -1, Quality = 0 },
                new ItemBase { Name = "Elixir of the Mongoose", Sellin = 5, Quality = 7 },
                new ItemBase { Name = "Elixir of the Mongoose", Sellin = -1, Quality = 2 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 0, Quality = 80 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -1, Quality = 80 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 15, Quality = 20 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 10, Quality = 49 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 5, Quality = 49 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = -2, Quality = 2 },
                new ItemBase { Name = "Conjured Mana Cake", Sellin = -1, Quality = 6 },
                new ItemBase { Name = "Conjured Mana Cake", Sellin = 2, Quality = 6 }
            };

            // Act
            var gildedRoseCore = _gildedRose;
            gildedRoseCore.SetItems(items);

            var sb = new StringBuilder();
            for (var i = 0; i < 31; i++)
            {
                sb.AppendLine("-------- day " + i + " --------");
                sb.AppendLine("name, sellIn, quality");

                var coreItems = gildedRoseCore.GetItems();

                for (var j = 0; j < coreItems.Count; j++)
                {
                    sb.AppendLine(coreItems[j].Name + ", " + coreItems[j].Sellin + ", " + coreItems[j].Quality);
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
            var initialItems = new List<ItemBase>
            {
                // Kata example
                new ItemBase { Name = "Aged Brie", Sellin = 2, Quality = 0 },
                new ItemBase { Name = "Aged Brie", Sellin = -1, Quality = 0 },

                new ItemBase { Name = "Aged Brie", Sellin = 12, Quality = 50 },
                new ItemBase { Name = "Aged Brie", Sellin = 11, Quality = 10 },
                new ItemBase { Name = "Aged Brie", Sellin = 6, Quality = 10 },
                new ItemBase { Name = "Aged Brie", Sellin = 5, Quality = 1 },
                new ItemBase { Name = "Aged Brie", Sellin = 0, Quality = 50 },
                new ItemBase { Name = "Aged Brie", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Aged Brie", Sellin = 5, Quality = 0 }
            };

            var expectedResult = new List<ItemBase>
            {
                new ItemBase { Name = "Aged Brie", Sellin = 2, Quality = 1 },
                new ItemBase { Name = "Aged Brie", Sellin = -1, Quality = 2 },
                new ItemBase { Name = "Aged Brie", Sellin = 11, Quality = 50 },
                new ItemBase { Name = "Aged Brie", Sellin = 10, Quality = 11 },
                new ItemBase { Name = "Aged Brie", Sellin = 5, Quality = 11 },
                new ItemBase { Name = "Aged Brie", Sellin = 4, Quality = 2 },
                new ItemBase { Name = "Aged Brie", Sellin = -1, Quality = 50 },
                new ItemBase { Name = "Aged Brie", Sellin = -4, Quality = 2 },
                new ItemBase { Name = "Aged Brie", Sellin = 4, Quality = 1 }
            };

            // Act
            var gildedRoseCore = _gildedRose;
            gildedRoseCore.SetItems(initialItems);
            gildedRoseCore.UpdateQuality();

            // Test
            var coreItems = gildedRoseCore.GetItems();

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, coreItems[i].Quality);
            }
        }

        [Fact(DisplayName = "BackstagePasses sub type system characterization tests")]
        public void BackstagePassesCharacterizationTest()
        {
            // Prepare
            var initialItems = new List<ItemBase>
            {
                // Kata example
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 15, Quality = 20 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 10, Quality = 49 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 5, Quality = 49 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = -2, Quality = 2 },

                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 12, Quality = 50 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 11, Quality = 10 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 6, Quality = 10 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 5, Quality = 1 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 0, Quality = 50 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 5, Quality = 0 }
            };

            var expectedResult = new List<ItemBase>
            {
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 14, Quality = 21 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 9, Quality = 50 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 4, Quality = 50 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 11, Quality = 50 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 10, Quality = 11 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 5, Quality = 12 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 4, Quality = 4 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 1, Quality = 0 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = -4, Quality = 0 },
                new ItemBase { Name = "Backstage passes to a TAFKAL80ETC concert", Sellin = 4, Quality = 3 }
            };

            // Act
            var gildedRoseCore = _gildedRose;
            gildedRoseCore.SetItems(initialItems);
            gildedRoseCore.UpdateQuality();

            // Test
            var coreItems = gildedRoseCore.GetItems();

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, coreItems[i].Quality);
            }
        }

        [Fact(DisplayName = "Sulfuras sub type system characterization tests")]
        public void SulfurasCharacterizationTest()
        {
            // Prepare
            var initialItems = new List<ItemBase>
            {
                // Kata example
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 0, Quality = 80 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -1, Quality = 80 },

                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 49 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -2, Quality = 2 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 12, Quality = 50 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 11, Quality = 10 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 6, Quality = 10 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 1 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 0, Quality = 50 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 0 }
            };

            var expectedResult = new List<ItemBase>
            {
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 0, Quality = 80 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -1, Quality = 80 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 49 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -2, Quality = 2 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 12, Quality = 50 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 11, Quality = 10 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 6, Quality = 10 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 1 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 0, Quality = 50 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Sulfuras, Hand of Ragnaros", Sellin = 5, Quality = 0 }
            };

            // Act
            var gildedRoseCore = _gildedRose;
            gildedRoseCore.SetItems(initialItems);
            gildedRoseCore.UpdateQuality();

            // Test
            var coreItems = gildedRoseCore.GetItems();

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, coreItems[i].Quality);
            }
        }

        [Fact(DisplayName = "Alvaro Test sub type system characterization tests")]
        public void AlvaroCharacterizationTest()
        {
            // Prepare
            var initialItems = new List<ItemBase>
            {
                // Kata example
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 49 },
                new ItemBase { Name = "Alvaro's Test", Sellin = -2, Quality = 2 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 12, Quality = 50 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 11, Quality = 10 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 6, Quality = 10 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 1 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 0, Quality = 50 },
                new ItemBase { Name = "Alvaro's Test", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 0 }
            };

            var expectedResult = new List<ItemBase>
            {
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 48 },
                new ItemBase { Name = "Alvaro's Test", Sellin = -2, Quality = 1 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 12, Quality = 49 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 11, Quality = 9 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 6, Quality = 9 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 0 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 0, Quality = 49 },
                new ItemBase { Name = "Alvaro's Test", Sellin = -3, Quality = 0 },
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 0 }
            };

            // Act
            var gildedRoseCore = _gildedRose;
            gildedRoseCore.SetItems(initialItems);
            gildedRoseCore.UpdateQuality();

            // Test
            var coreItems = gildedRoseCore.GetItems();

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Quality, coreItems[i].Quality);
            }
        }
    }
}