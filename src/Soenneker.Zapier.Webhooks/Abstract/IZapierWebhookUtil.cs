using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Zapier.Webhooks.Abstract;

/// <summary>
/// A utility library for Zapier webhook calling
/// </summary>
public interface IZapierWebhookUtil
{
    /// <summary>
    /// Sends a JSON payload to a Zapier webhook URL.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    /// <param name="webhookUrl">The complete webhook URL supplied by Zapier.</param>
    /// <param name="payload">The value to serialize as JSON.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response body returned by Zapier.</returns>
    ValueTask<string> Trigger<T>(string webhookUrl, T payload, CancellationToken cancellationToken = default);
}
