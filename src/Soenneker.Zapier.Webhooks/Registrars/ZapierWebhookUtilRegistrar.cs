using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Zapier.Webhooks.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Zapier.Webhooks.Registrars;

/// <summary>
/// A utility library for Zapier webhook calling
/// </summary>
public static class ZapierWebhookUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IZapierWebhookUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZapierWebhookUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<IZapierWebhookUtil, ZapierWebhookUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IZapierWebhookUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZapierWebhookUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<IZapierWebhookUtil, ZapierWebhookUtil>();

        return services;
    }
}
