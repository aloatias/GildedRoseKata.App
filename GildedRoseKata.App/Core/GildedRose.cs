using GildedRoseKata.App.Models;
using System.Collections.Generic;

namespace GildedRoseKata.App.Core
{
    public class GildedRose
    {
        private List<ItemBase> _items;
        private readonly IItemFactory _itemFactory;

        public GildedRose(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public List<ItemBase> GetItems()
        {
            return _items;
        }

        public void SetItems(List<ItemBase> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            _items.ForEach(item =>
            {
                var subItem = _itemFactory.Create(item.Name, item.Quality, item.Sellin);
                subItem.UpdateQuality();

                item.Quality = subItem.Quality;
                item.Sellin = subItem.Sellin;
            });
        }
    }
}
