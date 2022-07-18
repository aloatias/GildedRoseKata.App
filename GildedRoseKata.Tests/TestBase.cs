using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using System.Collections.Generic;
using System.IO;

namespace GildedRoseKata.Tests
{
    public class TestBase
    {
        protected string InitialCharacterizationResult = File.ReadAllText($"{ Directory.GetCurrentDirectory() }/{ Path.Combine("ApprovalTest.ThirtyDays.received.txt") }").ToString();

        protected static GildedRose CreateGildedRose()
        {
            return new GildedRose(CreateItemFactory());
        }

        protected static IItemFactory CreateItemFactory()
        {
            return new ItemFactory(() => new List<IItem>
            {
                new AgedBrie(),
                new BackstagePasses(),
                new Conjured(),
                new Sulfuras(),
                new CustomItem(),
                new UnknownItem()
            });
        }
    }
}
