using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Util.Abstract;

/// <summary>
/// A utility library for Azure Communication Services SMS operations
/// </summary>
public interface IAzureSmsUtil
{
    /// <summary>
    /// Executes the send operation.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="message">The message.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Send(string from, string to, string message);
}