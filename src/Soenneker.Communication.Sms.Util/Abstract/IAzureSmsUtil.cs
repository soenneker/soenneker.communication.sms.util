using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Util.Abstract;

/// <summary>
/// A utility library for Azure Communication Services SMS operations
/// </summary>
public interface IAzureSmsUtil
{
    /// <summary>
    /// Sends azure Sms.
    /// </summary>
    /// <param name="from">Sender address.</param>
    /// <param name="to">Recipient address.</param>
    /// <param name="message">Message content to send.</param>
    /// <returns>A task that completes when the send operation is complete.</returns>
    ValueTask Send(string from, string to, string message);
}
