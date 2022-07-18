using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class AgedBrie : ItemBase, IItem
    {
        public AgedBrie()
        {
            Name = "Aged Brie";
        }

        public void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }

            Sellin -= 1;

            if (Sellin < 0 && Quality < 50)
            {
                Quality += 1;
            }
        }
    }
}
