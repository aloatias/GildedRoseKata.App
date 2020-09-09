using GildedRoseKata.App.Models;
using System.Collections.Generic;

namespace GildedRoseKata.App.Core
{
    public class GildedRose
    {
        private List<Item> _items;
        private readonly IItemFactory _itemFactory;

        public GildedRose(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public void SetItems(List<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            _items.ForEach(item =>
            {
                var subItem = _itemFactory.CreateSubItemFromItemName(item);
                subItem.UpdateQuality();

                item.Quality = subItem.Quality;
                item.SellIn = subItem.SellIn;
            });
        }
    }
}
