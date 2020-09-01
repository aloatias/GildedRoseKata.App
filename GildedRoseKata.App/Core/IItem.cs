namespace GildedRoseKata.App.Core
{
    public interface IItem
    {
        string Name { get; set; }

        int SellIn { get; set; }

        int Quality { get; set; }

        void UpdateQuality();
    }
}