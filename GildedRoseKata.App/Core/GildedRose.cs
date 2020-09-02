using GildedRoseKata.App.Models;
using System.Collections.Generic;

namespace GildedRoseKata.App.Core
{
    public class GildedRose
    {
        public readonly List<Item> Items;
        private readonly IItemFactory _itemFactory;

        public GildedRose(List<Item> items, IItemFactory itemFactory)
        {
            Items = items;
            _itemFactory = itemFactory;
        }

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                var subItem = _itemFactory.CreateSubItemFromItem(item);
                subItem.UpdateQuality();

                item.Quality = subItem.Quality;
                item.SellIn = subItem.SellIn;
            });
        }
    }
}
