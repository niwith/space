using Blazored.LocalStorage;
using Blazored.LocalStorage.JsonConverters;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.Extensions.DependencyInjection;

namespace Space.Client.Services
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoredLocalStorageSingleton(this IServiceCollection services)
        {
            return services
                .AddSingleton<ILocalStorageService, LocalStorageService>()
                .AddSingleton<ISyncLocalStorageService, LocalStorageService>()
                .Configure<LocalStorageOptions>(configureOptions =>
                {
                    configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}