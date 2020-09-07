using GildedRoseKata.App.Configuration;
using GildedRoseKata.App.Models;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.App.Core
{
    public class ItemFactory : IItemFactory
    {
        private readonly List<Type> _itemTypes;

        public ItemFactory(ItemTypesConfiguration itemTypesConfiguration)
        {
            _itemTypes = itemTypesConfiguration.GetItemTypes();
        }

        public IItem CreateSubItemFromItemName(Item item)
        {
            IItem subItem = new UnknownItem(item.Name, item.SellIn, item.Quality);

            foreach (var itemType in _itemTypes)
            {
                var temporarySubItem = (IValidItem)Activator.CreateInstance(itemType, item.Name, item.SellIn, item.Quality);
                subItem = temporarySubItem.Build();

                if (subItem.GetType() != typeof(UnknownItem))
                {
                    return subItem;
                }
            }

            return subItem;
        }
    }
}