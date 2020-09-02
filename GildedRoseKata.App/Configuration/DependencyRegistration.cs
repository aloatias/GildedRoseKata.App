using GildedRoseKata.App.Core;
using GildedRoseKata.App.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRoseKata.App.Configuration
{
    public static class DependencyRegistration
    {
        public static ServiceProvider RegisterServices(this ServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<ItemTypesHelper>()
                .AddSingleton<IItemFactory, ItemFactory>()
                .AddSingleton(configuration);

            return services.BuildServiceProvider();
        }
    }
}
