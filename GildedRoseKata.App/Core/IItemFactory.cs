namespace GildedRoseKata.App.Core
{
    public interface IItemFactory
    {
        IItem Create(string name, int quality, int sellin);
    }
}