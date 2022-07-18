using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.App.Core
{
    public class ItemFactory : IItemFactory
    {
        private readonly Func<IEnumerable<IItem>> _factory;

        public ItemFactory(Func<IEnumerable<IItem>> factory)
        {
            _factory = factory;
        }

        public IItem Create(string name, int quality, int sellin)
        {
            var item = _factory().FirstOrDefault(x => 
                name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase) ||
                name.Contains(x.Name, StringComparison.InvariantCultureIgnoreCase)
            );

            if (item == null)
            {
                return new UnknownItem();
            }

            item.Quality = quality;
            item.Sellin = sellin;

            return item;
        }
    }
}