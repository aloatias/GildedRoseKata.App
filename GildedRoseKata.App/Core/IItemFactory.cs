using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public interface IItemFactory
    {
        IItem CreateSubItemFromName(Item item);
    }
}