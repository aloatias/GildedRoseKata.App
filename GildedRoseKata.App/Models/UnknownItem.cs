using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public class UnknownItem : Item, IUnknownItem
    {
        public UnknownItem(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }

            SellIn -= 1;

            if (SellIn < 0 && Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}