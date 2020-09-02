using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Test : Item, IValidItem
    {
        public Test(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public IItem Build()
        {
            if (Name != "Alvaro's Test")
            {
                return new UnknownItem(Name, SellIn, Quality);
            }

            return this;
        }

        public void UpdateQuality()
        {
            Quality -= 1;
        }
    }
}
