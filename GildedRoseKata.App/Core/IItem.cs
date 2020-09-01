namespace GildedRoseKata.App.Core
{
    public interface IItem
    {
        IItem Build();

        void UpdateQuality();
    }
}