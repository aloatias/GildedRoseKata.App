﻿using GildedRoseKata.App.Models;
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
            IItem createdItem = new NullItem();

            for (var i = 0; i < _itemsType.Count; i++)
            {
                var temporaryItem = (IItem)Activator.CreateInstance(_itemsType[i], item.Name, item.SellIn, item.Quality);
                createdItem = temporaryItem.Build();

                if (createdItem.GetType() != typeof(NullItem))
                {
                    return createdItem;
                }
            }

            return createdItem;
        }
    }
}