using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class Sulfuras : ItemBase, IItem
    {
        public Sulfuras()
        {
            Name = "Sulfuras";
        }

        public void UpdateQuality()
        {
            // being a legendary item, never has to be sold or decreases in Quality
        }
    }
}
