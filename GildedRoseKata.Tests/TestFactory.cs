using System.IO;

namespace GildedRoseKata.Tests
{
    public class TestFactory
    {
        protected string InitialCharacterizationResult = File.ReadAllText($"{ Directory.GetCurrentDirectory() }/{ Path.Combine("ApprovalTest.ThirtyDays.received.txt") }").ToString();
    }
}
