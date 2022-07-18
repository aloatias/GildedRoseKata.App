using GildedRoseKata.App.Models;

namespace GildedRoseKata.App.Core
{
    public class UnknownItem : ItemBase, IItem
    {
        public UnknownItem()
        {
            Name = nameof(UnknownItem);
        }

        public void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }

            Sellin -= 1;

            if (Sellin < 0 && Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}