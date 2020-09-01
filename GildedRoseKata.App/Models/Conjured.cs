using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Conjured : Item, IItem
    {
        public Conjured(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public IItem Build()
        {
            if (!Name.Contains("Conjured"))
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
