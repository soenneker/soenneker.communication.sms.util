using Azure.Communication.Sms;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Util.Abstract;

/// <summary>
/// Sends SMS messages through Azure Communication Services.
/// </summary>
public interface IAzureSmsUtil
{
    /// <summary>
    /// Sends an SMS and throws when Azure rejects the message.
    /// </summary>
    /// <param name="from">Sender phone number owned by the configured Azure Communication Services resource.</param>
    /// <param name="to">Recipient phone number.</param>
    /// <param name="message">Message body.</param>
    /// <returns>A task that completes when Azure accepts the send request.</returns>
    ValueTask Send(string from, string to, string message);

    /// <summary>
    /// Sends an SMS and returns Azure's immediate send result.
    /// </summary>
    /// <param name="from">Sender phone number owned by the configured Azure Communication Services resource.</param>
    /// <param name="to">Recipient phone number.</param>
    /// <param name="message">Message body.</param>
    /// <param name="cancellationToken">Token used to cancel client acquisition and the send request.</param>
    /// <returns>Azure's immediate send result. Inspect <see cref="SmsSendResult.Successful"/> before treating the request as accepted.</returns>
    ValueTask<SmsSendResult> SendWithResult(string from, string to, string message, CancellationToken cancellationToken = default);
}
