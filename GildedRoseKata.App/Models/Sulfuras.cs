using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Sulfuras : Item, IValidItem
    {
        public Sulfuras(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public IItem Build()
        {
            if (!Name.Contains("Sulfuras"))
            {
                return new NullItem(Name, SellIn, Quality);
            }

            return this;
        }

        public int UpdateQuality()
        {
            return Quality;
        }
    }
}
