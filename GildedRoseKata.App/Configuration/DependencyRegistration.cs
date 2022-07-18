using GildedRoseKata.App.Core;
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
                .AddSingleton<GildedRose>()
                .AddSingleton<IItemFactory, ItemFactory>()
                .AddSingleton<Func<IEnumerable<IItem>>>(x => () => x.GetService<IEnumerable<IItem>>());

            return services.BuildServiceProvider();
        }
    }
}
