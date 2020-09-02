using GildedRoseKata.App.Configuration;
using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.App
{
    public class Program
    {
        private static IConfiguration _configuration;
        private static ServiceProvider _serviceProvider;
        private static IItemFactory _itemTypesHelper;

        public static void Main(string[] args)
        {
            LoadConfiguration();
            InjectDependencies();
            LoadItemsType();

            Console.WriteLine("OMGHAI!");

            var items = new List<Item>{
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
                new Item { Name = "Alvaro's Test", SellIn = 5, Quality = 10 }
				
                // this conjured item does not work properly yet
				// new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var _gildedRoseCore = new GildedRose(items, _itemTypesHelper);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(_gildedRoseCore.Items[j].Name + ", " + _gildedRoseCore.Items[j].SellIn + ", " + _gildedRoseCore.Items[j].Quality);
                }
                Console.WriteLine("");

                _gildedRoseCore.UpdateQuality();
            }
        }

        private static void LoadConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static void InjectDependencies()
        {
            _serviceProvider = new ServiceCollection().RegisterServices(_configuration);
        }

        private static void LoadItemsType()
        {
            _itemTypesHelper = _serviceProvider.GetRequiredService<IItemFactory>();
        }
    }
}
