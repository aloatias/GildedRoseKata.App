using GildedRoseKata.App.Models;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.App.Core
{
    public class ItemFactory : IItemFactory
    {
        private readonly List<Type> _itemsType;

        public ItemFactory()
        {
            _itemsType = new List<Type> { typeof(AgedBrie), typeof(BackstagePasses), typeof(Conjured), typeof(Sulfuras) };
        }

        public IItem CreateSubItemFromName(Item item)
        {
            var createdItem = new Item();
            _itemsType.ForEach(type =>
            {
                var temporaryItem = (IItem)Activator.CreateInstance(type, item.Name, item.SellIn, item.Quality);
                var createdItem = temporaryItem.Build();

                
                createdItem.UpdateQuantity();
            });

            return createdItem;
        }
    }
}