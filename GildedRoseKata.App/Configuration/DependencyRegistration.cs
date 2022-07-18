using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.App.Configuration
{
    public static class DependencyRegistrationExtensions
    {
        public static ServiceProvider RegisterServices(this ServiceCollection services)
        {
            services
                .AddTransient<IItem, AgedBrie>()
                .AddTransient<IItem, BackstagePasses>()
                .AddTransient<IItem, Conjured>()
                .AddTransient<IItem, Sulfuras>()
                .AddSingleton<Func<IEnumerable<IItem>>>(x => () => x.GetService<IEnumerable<IItem>>())
                .AddSingleton<IItemFactory, ItemFactory>()
                .AddSingleton<GildedRose>();

            return services.BuildServiceProvider();
        }
    }
}
