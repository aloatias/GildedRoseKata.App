using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public class NullItem : Item, IItem
    {
        public IItem Build()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateQuantity()
        {
            throw new System.NotImplementedException();
        }
    }
}