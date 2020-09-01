using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public interface IItem
    {
        IItem Build();

        void UpdateQuantity();
    }
}