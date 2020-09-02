namespace GildedRoseKata.App.Core
{
    public interface IValidItem : IItem
    {
        IItem Build();
    }
}