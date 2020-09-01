using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class AgedBrie : Item, IValidItem
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
                return new NullItem(Name, SellIn, Quality);
            }

            return this;
        }

        public int UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }

            SellIn--;

            if (SellIn < 0 && Quality < 50)
            {
                Quality++;
            }

            return Quality;
        }
    }
}
