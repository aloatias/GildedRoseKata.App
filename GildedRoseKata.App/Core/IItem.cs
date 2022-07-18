namespace GildedRoseKata.App.Core
{
    public interface IItem
    {
        string Name { get; set; }

        int Sellin { get; set; }

        int Quality { get; set; }

        void UpdateQuality();
    }
}