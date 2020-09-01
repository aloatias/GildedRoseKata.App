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
                return new UnknownItem(Name, SellIn, Quality);
            }

            return this;
        }

        public void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }

            SellIn -= 1;

            if (SellIn < 0 && Quality < 50)
            {
                Quality += 1;
            }
        }
    }
}
