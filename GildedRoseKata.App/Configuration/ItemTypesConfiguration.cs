using GildedRoseKata.App.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.App.Configuration
{
    public class ItemTypesConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly string _configurationSectionName = "itemTypes";
        private readonly List<string> _itemTypesConfiguration;
        private readonly string _itemTypesModelsNamespace = "GildedRoseKata.App.Models.";

        public List<Type> ItemTypes { get; private set; } = new List<Type>();

        public ItemTypesConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            _itemTypesConfiguration = _configuration.GetSection(_configurationSectionName)?.GetChildren()?.Select(itc => itc.Value)?.ToList();
            SetItemTypes();
        }

        public void SetItemTypes()
        {
            if (!ItemTypes.Any())
            {
                foreach (var type in _itemTypesConfiguration)
                {
                    var classPath = $"{ _itemTypesModelsNamespace }{ type }";
                    var currentObject = (IValidItem)Activator.CreateInstance(Type.GetType(classPath), type, 0, 0);
                    ItemTypes.Add(currentObject.GetType());
                }
            }
        }
    }
}