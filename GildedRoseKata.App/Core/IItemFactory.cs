using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public interface IItemFactory
    {
        IItem CreateSubItemFromItemName(Item item);
    }
}