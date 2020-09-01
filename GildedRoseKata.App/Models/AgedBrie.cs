using GildedRoseKata.App.Core;
using System;

namespace GildedRoseKata.App.Models
{
    public class AgedBrie : Item, IItem
    {
        public AgedBrie(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public IItem Build()
        {
            if (Name != "Aged Brie")
            {
                return new NullItem();
            }

            return this;
        }

        public void UpdateQuality()
        {
            Console.WriteLine("AgedBrie update quantity");
        }
    }
}
