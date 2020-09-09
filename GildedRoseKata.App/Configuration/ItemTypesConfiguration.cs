using GildedRoseKata.App.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.App.Configuration
{
    public class ItemTypesConfiguration
    {
        private readonly string _configurationSectionName = "itemTypes";
        private readonly List<string> _itemTypesInConfiguration;
        private readonly string _itemTypesModelsNamespace = "GildedRoseKata.App.Models.";

        private readonly List<Type> _itemTypes = new List<Type>();

        public ItemTypesConfiguration(IConfiguration configuration)
        {
            _itemTypesInConfiguration = configuration.GetSection(_configurationSectionName)?.GetChildren()?.Select(itc => itc.Value)?.ToList();
            SetItemTypes();
        }

        public List<Type> GetItemTypes()
        {
            return _itemTypes;
        }

        private void SetItemTypes()
        {
            if (!_itemTypes.Any())
            {
                foreach (var type in _itemTypesInConfiguration)
                {
                    var classPath = $"{ _itemTypesModelsNamespace }{ type }";
                    var currentObject = (IValidItem)Activator.CreateInstance(Type.GetType(classPath), type, 0, 0);
                    _itemTypes.Add(currentObject.GetType());
                }
            }
        }
    }
}