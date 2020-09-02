using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class BackstagePasses : Item, IValidItem
    {
        public BackstagePasses(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public IItem Build()
        {
            if (!Name.Contains("Backstage passes"))
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

            if (SellIn < 11 && Quality < 50)
            {
                Quality += 1;
            }

            if (SellIn < 6 && Quality < 50)
            {
                Quality += 1;
            }

            SellIn -= 1;

            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }
}
