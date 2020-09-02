using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Conjured : Item, IValidItem
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
                return new UnknownItem(Name, SellIn, Quality);
            }

            return this;
        }

        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
