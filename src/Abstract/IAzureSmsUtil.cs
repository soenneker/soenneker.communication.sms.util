using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Util.Abstract;

/// <summary>
/// A utility library for Azure Communication Services SMS operations
/// </summary>
public interface IAzureSmsUtil
{
    ValueTask Send(string from, string to, string message);
}