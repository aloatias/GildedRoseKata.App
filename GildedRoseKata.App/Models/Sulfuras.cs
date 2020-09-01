using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Sulfuras : Item, IItem
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
                return new NullItem();
            }

            return this;
        }

        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
