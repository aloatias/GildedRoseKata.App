using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Xunit;

namespace GildedRoseKata.Tests
{
    public class ItemFactoryTests : TestFactory
    {
        private readonly IItemFactory _itemFactory;

        public ItemFactoryTests()
        {
            _itemFactory = CreateItemFactory();
        }

        [Fact(DisplayName = "Should create an AgedBrie sub item type")]
        public void ShouldCreateAnAgedBrieItem()
        {
            // Prepare
            var itemName = "Aged Brie";
            var itemQuality = 1;
            var itemSellin = 1;

            var initialItem = new Item { Name = itemName, Quality = itemQuality, SellIn = itemSellin };

            // Act
            var actualResult = _itemFactory.CreateSubItemFromItemName(initialItem);

            // Test
            Assert.IsType<AgedBrie>(actualResult);
        }

        [Fact(DisplayName = "Should create a BackstagePasses sub item type")]
        public void ShouldCreateABackstagePassesItem()
        {
            // Prepare
            var itemName = "Backstage passes integration test";
            var itemQuality = 1;
            var itemSellin = 1;

            var initialItem = new Item { Name = itemName, Quality = itemQuality, SellIn = itemSellin };

            // Act
            var actualResult = _itemFactory.CreateSubItemFromItemName(initialItem);

            // Test
            Assert.IsType<BackstagePasses>(actualResult);
        }

        [Fact(DisplayName = "Should create a Conjured sub item type")]
        public void ShouldCreateAConjuredItem()
        {
            // Prepare
            var itemName = "Conjured integration test";
            var itemQuality = 1;
            var itemSellin = 1;

            var initialItem = new Item { Name = itemName, Quality = itemQuality, SellIn = itemSellin };

            // Act
            var actualResult = _itemFactory.CreateSubItemFromItemName(initialItem);

            // Test
            Assert.IsType<Conjured>(actualResult);
        }

        [Fact(DisplayName = "Should create a Sulfuras sub item type")]
        public void ShouldCreateASulfurasItem()
        {
            // Prepare
            var itemName = "Sulfuras integration test";
            var itemQuality = 1;
            var itemSellin = 1;

            var initialItem = new Item { Name = itemName, Quality = itemQuality, SellIn = itemSellin };

            // Act
            var actualResult = _itemFactory.CreateSubItemFromItemName(initialItem);

            // Test
            Assert.IsType<Sulfuras>(actualResult);
        }

        [Fact(DisplayName = "Should create a NullItem sub item type")]
        public void ShouldCreateANullItem()
        {
            // Prepare
            var itemName = "This description shouldn't match any sub item type";
            var itemQuality = 1;
            var itemSellin = 1;

            var initialItem = new Item { Name = itemName, Quality = itemQuality, SellIn = itemSellin };

            // Act
            var actualResult = _itemFactory.CreateSubItemFromItemName(initialItem);

            // Test
            Assert.IsType<UnknownItem>(actualResult);
        }
    }
}
