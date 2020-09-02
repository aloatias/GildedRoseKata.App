using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GildedRoseKata.Tests
{
    public class TestFactory
    {
        protected IItemFactory CreateItemFactory()
        {
            return new ItemFactory(CreateItemTypesHelper(CreateConfiguration()));
        }

        private ItemTypesHelper CreateItemTypesHelper(IConfiguration configuration)
        {
            return new ItemTypesHelper(configuration);
        }

        private IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        protected string InitialCharacterizationResult = File.ReadAllText($"{ Directory.GetCurrentDirectory() }/{ Path.Combine("ApprovalTest.ThirtyDays.received.txt") }").ToString();
    }
}
