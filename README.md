[![](https://img.shields.io/nuget/v/soenneker.communication.sms.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.communication.sms.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.util/actions/workflows/codeql.yml)

# Soenneker.Communication.Sms.Util

Sends SMS messages through Azure Communication Services using a reusable SDK client.

## Installation

```bash
dotnet add package Soenneker.Communication.Sms.Util
```

## Configuration

```json
{
  "Azure": {
    "CommunicationServices": {
      "ConnectionString": "<Azure Communication Services connection string>"
    }
  }
}
```

Keep the connection string in a secret provider rather than source control.

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Communication.Sms.Util.Registrars;

services.AddAzureSmsUtilAsSingleton();
```

`AddAzureSmsUtilAsScoped()` is also available. Both registrations reuse the underlying Azure SMS client.

## Usage

```csharp
using Azure.Communication.Sms;
using Soenneker.Communication.Sms.Util.Abstract;

public sealed class VerificationMessages
{
    private readonly IAzureSmsUtil _sms;

    public VerificationMessages(IAzureSmsUtil sms)
    {
        _sms = sms;
    }

    public ValueTask<SmsSendResult> SendCode(
        string destination,
        string code,
        CancellationToken cancellationToken)
    {
        return _sms.SendWithResult(
            "+15551234567",
            destination,
            $"Your verification code is {code}",
            cancellationToken);
    }
}
```

The sender number must belong to the configured Azure Communication Services resource. Format sender and recipient phone numbers in E.164 form where required.

Use the existing `Send(from, to, message)` method when the immediate result and cancellation are not needed. It throws if Azure returns an unsuccessful per-message result.

## Result and delivery behavior

- `SendWithResult` returns Azure's immediate `SmsSendResult`, including unsuccessful results, the message ID, HTTP status, and error message. Check `Successful` before treating the request as accepted.
- A successful send result means Azure accepted the request; it does not guarantee carrier or handset delivery.
- Delivery reporting is enabled on every send. Process Azure Communication Services delivery-report events separately when final delivery status matters.
- Azure request failures are thrown as `RequestFailedException`. The compatibility `Send` method surfaces a non-successful result as `InvalidOperationException` instead of silently completing.
- Pass application cancellation through `SendWithResult`; the compatibility `Send` method has no cancellation parameter.
- The utility logs the Azure message ID and success flag at debug level. It does not log the recipient or message body.
- Treat phone numbers and message content as sensitive data and apply appropriate consent, retention, and redaction policies.
