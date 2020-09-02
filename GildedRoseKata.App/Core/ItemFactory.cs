using GildedRoseKata.App.Configuration;
using GildedRoseKata.App.Models;
using System;

namespace GildedRoseKata.App.Core
{
    public class ItemFactory : IItemFactory
    {
        private readonly ItemTypesConfiguration _itemTypesConfiguration;
        
        public ItemFactory(ItemTypesConfiguration itemTypesHelper)
        {
            _itemTypesConfiguration = itemTypesHelper;
        }

        public IItem CreateSubItemFromItem(Item item)
        {
            IItem createdItem = new UnknownItem(item.Name, item.SellIn, item.Quality);

            foreach (var itemType in _itemTypesConfiguration.ItemTypes)
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