using GildedRoseKata.App.Core;

namespace GildedRoseKata.App.Models
{
    public class CustomItem : ItemBase, IItem
    {
        public CustomItem()
        {
            Name = "Alvaro's Test";
        }

        public void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}
