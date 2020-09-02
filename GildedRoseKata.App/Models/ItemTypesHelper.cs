using GildedRoseKata.App.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.App.Models
{
    public class ItemTypesHelper
    {
        private readonly IConfiguration _configuration;

        public List<Type> ItemTypesList { get; private set; } = new List<Type>();

        public ItemTypesHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            SetItemTypesList();
        }

        public void SetItemTypesList()
        {
            if (!ItemTypesList.Any())
            {
                foreach (var type in _configuration.GetSection("itemTypes").GetChildren())
                {
                    var currentObject = (IValidItem)Activator.CreateInstance(Type.GetType($"GildedRoseKata.App.Models.{ type.Value }"), type.Value, 0, 0);
                    ItemTypesList.Add(currentObject.GetType());
                }
            }
        }
    }
}