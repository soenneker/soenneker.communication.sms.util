[![](https://img.shields.io/nuget/v/soenneker.communication.sms.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.communication.sms.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.util/actions/workflows/codeql.yml)

# Soenneker.Communication.Sms.Util

A utility library for Azure Communication Services SMS operations.

## Install

```bash
dotnet add package Soenneker.Communication.Sms.Util
```

## Quick start

```csharp
using Soenneker.Communication.Sms.Util.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddAzureSmsUtilAsSingleton();
```

Adds `IAzureSmsUtil` as a singleton service.

## What you get

- `IAzureSmsUtil` — A utility library for Azure Communication Services SMS operations.
- `AzureSmsUtilRegistrar` — A utility library for Azure Communication Services SMS operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IAzureSmsUtil.Send(from, to, message)` | Sends azure Sms. | A task that completes when the send operation is complete. |
| `AzureSmsUtilRegistrar.AddAzureSmsUtilAsSingleton(services)` | Adds `IAzureSmsUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `AzureSmsUtilRegistrar.AddAzureSmsUtilAsScoped(services)` | Adds `IAzureSmsUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |
