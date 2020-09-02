using GildedRoseKata.App.Models;
using System;

namespace GildedRoseKata.App.Core
{
    public class ItemFactory : IItemFactory
    {
        private readonly ItemTypesHelper _itemTypesHelper;
        
        public ItemFactory(ItemTypesHelper itemTypesHelper)
        {
            _itemTypesHelper = itemTypesHelper;
        }

        public IItem CreateSubItemFromItem(Item item)
        {
            IItem createdItem = new UnknownItem(item.Name, item.SellIn, item.Quality);

            foreach (var itemType in _itemTypesHelper.ItemTypesList)
            {
                var temporaryItem = (IValidItem)Activator.CreateInstance(itemType, item.Name, item.SellIn, item.Quality);
                createdItem = temporaryItem.Build();

                if (createdItem.GetType() != typeof(UnknownItem))
                {
                    return createdItem;
                }
            }

            return createdItem;
        }
    }
}