using GildedRoseKata.App.Configuration;
using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.App
{
    public class Program
    {
        private static ServiceProvider _serviceProvider;
                
        public static void Main(string[] args)
        {
            InjectDependencies();

            Console.WriteLine("OMGHAI!");

            var items = new List<ItemBase>{
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
                new ItemBase { Name = "Alvaro's Test", Sellin = 5, Quality = 10 },
                new ItemBase { Name = "Conjured Mana Cake", Sellin = -1, Quality = 6 },
                new ItemBase { Name = "Conjured Mana Cake", Sellin = 2, Quality = 6 }
            };

            var gildedRose = ResolveGildedRose();
            gildedRose.SetItems(items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                var coreItemBases = gildedRose.GetItems();

                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(coreItemBases[j].Name + ", " + coreItemBases[j].Sellin + ", " + coreItemBases[j].Quality);
                }
                Console.WriteLine("");

                gildedRose.UpdateQuality();
            }
        }

        private static GildedRose ResolveGildedRose()
        {
            return _serviceProvider.GetRequiredService<GildedRose>();
        }

        private static void InjectDependencies()
        {
            _serviceProvider = new ServiceCollection().RegisterServices();
        }
    }
}
