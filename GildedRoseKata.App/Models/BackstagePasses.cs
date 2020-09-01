using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class BackstagePasses : Item, IItem
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
                return new NullItem();
            }

            return this;
        }

        public void UpdateQuantity()
        {
            throw new System.NotImplementedException();
        }
    }
}
