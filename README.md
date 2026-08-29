[![](https://img.shields.io/nuget/v/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zapier.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zapier.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)

# Soenneker.Zapier.Webhooks

A utility library for Zapier webhook calling.

## Install

```bash
dotnet add package Soenneker.Zapier.Webhooks
```

## Quick start

```csharp
using Soenneker.Zapier.Webhooks.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddZapierWebhookUtilAsSingleton();
```

Adds `IZapierWebhookUtil` as a singleton service.

## What you get

- `IZapierWebhookUtil` — A utility library for Zapier webhook calling.
- `ZapierWebhookUtilRegistrar` — A utility library for Zapier webhook calling.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IZapierWebhookUtil.Trigger(webhookUrl, payload, cancellationToken)` | Sends a JSON payload to a Zapier webhook URL. | The response body returned by Zapier. |
| `ZapierWebhookUtilRegistrar.AddZapierWebhookUtilAsSingleton(services)` | Adds `IZapierWebhookUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `ZapierWebhookUtilRegistrar.AddZapierWebhookUtilAsScoped(services)` | Adds `IZapierWebhookUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
