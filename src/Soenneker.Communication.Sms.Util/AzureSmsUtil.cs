using Soenneker.Communication.Sms.Util.Abstract;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.Sms;
using Soenneker.Communication.Sms.Client.Abstract;
using Microsoft.Extensions.Logging;

namespace Soenneker.Communication.Sms.Util;

/// <inheritdoc cref="IAzureSmsUtil"/>
public sealed class AzureSmsUtil : IAzureSmsUtil
{
    private readonly ISmsClientUtil _smsClientUtil;
    private readonly ILogger<AzureSmsUtil> _logger;

    public AzureSmsUtil(ISmsClientUtil smsClientUtil, ILogger<AzureSmsUtil> logger)
    {
        _smsClientUtil = smsClientUtil;
        _logger = logger;
    }

    public async ValueTask Send(string from, string to, string message)
    {
        SmsClient client = await _smsClientUtil.Get();

        Response<SmsSendResult>? response = await client.SendAsync(from, to, message,
            options: new SmsSendOptions(enableDeliveryReport: true));

        SmsSendResult result = response.Value;

        _logger.LogDebug("Sms id: {messageId}", result.MessageId);
        _logger.LogDebug("Send Result Successful: {successful}", result.Successful);
    }
}