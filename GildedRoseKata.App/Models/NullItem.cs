using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public class NullItem : Item, IUnknownItem
    {
        public NullItem(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public int UpdateQuality()
        {
            return Quality--;
        }
    }
}