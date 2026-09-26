using System.Text.Json.Serialization.Metadata;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Zapier.Webhooks.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Zapier.Webhooks;

/// <inheritdoc cref="IZapierWebhookUtil" />
public sealed class ZapierWebhookUtil : IZapierWebhookUtil
{
    private const string _clientId = nameof(ZapierWebhookUtil);

    private readonly IHttpClientCache _httpClientCache;

    public ZapierWebhookUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    [RequiresUnreferencedCode("JSON serialization requires reflection. Use the overload accepting JsonTypeInfo<T> for trimming.")]
    [RequiresDynamicCode("JSON serialization may require runtime code generation. Use the overload accepting JsonTypeInfo<T> for Native AOT.")]
    public async ValueTask<string> Trigger<T>(string webhookUrl, T payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(webhookUrl);
        ArgumentNullException.ThrowIfNull(payload);

        if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out Uri? uri) || (uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp))
            throw new ArgumentException("The webhook URL must be an absolute HTTP or HTTPS URL.", nameof(webhookUrl));

        HttpClient client = await _httpClientCache.Get(_clientId, cancellationToken);

        using HttpResponseMessage response = await client.PostAsJsonAsync(uri, payload, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    public async ValueTask<string> Trigger<T>(string webhookUrl, T payload, JsonTypeInfo<T> typeInfo, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        ArgumentException.ThrowIfNullOrWhiteSpace(webhookUrl);
        ArgumentNullException.ThrowIfNull(payload);

        if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out Uri? uri) || (uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp))
            throw new ArgumentException("The webhook URL must be an absolute HTTP or HTTPS URL.", nameof(webhookUrl));

        HttpClient client = await _httpClientCache.Get(_clientId, cancellationToken);

        using HttpResponseMessage response = await client.PostAsJsonAsync(uri, payload, typeInfo, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
