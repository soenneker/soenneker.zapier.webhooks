using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Zapier.Webhooks.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Zapier.Webhooks.Registrars;

/// <summary>
/// Registers the Zapier webhook sender.
/// </summary>
public static class ZapierWebhookUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IZapierWebhookUtil"/> as a singleton service.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZapierWebhookUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<IZapierWebhookUtil, ZapierWebhookUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IZapierWebhookUtil"/> as a scoped service while retaining the singleton HTTP client cache.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZapierWebhookUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<IZapierWebhookUtil, ZapierWebhookUtil>();

        return services;
    }
}
