using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class BackstagePasses : ItemBase, IItem
    {
        public BackstagePasses()
        {
            Name = "Backstage passes";
        }

        public void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }

            if (Sellin < 11 && Quality < 50)
            {
                Quality += 1;
            }

            if (Sellin < 6 && Quality < 50)
            {
                Quality += 1;
            }

            Sellin -= 1;

            if (Sellin < 0)
            {
                Quality = 0;
            }
        }
    }
}
