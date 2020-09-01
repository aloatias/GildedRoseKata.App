using GildedRoseKata.App.Core;
using System.IO;

namespace GildedRoseKata.Tests
{
    public class TestFactory
    {
        protected IItemFactory CreateItemFactory()
        {
            return new ItemFactory();
        }

        protected string InitialCharacterizationResult = File.ReadAllText($"{ Directory.GetCurrentDirectory() }/{ Path.Combine("ApprovalTest.ThirtyDays.received.txt") }").ToString();
    }
}
