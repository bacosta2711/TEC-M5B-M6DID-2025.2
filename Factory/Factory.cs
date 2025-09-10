using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaDA2.Interfaces;
using TiendaDA2.Services;

namespace Factory;

public static class Factory
{
    [ExcludeFromCodeCoverage]
    public static void AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IProductService, ProductService>();
    }
}