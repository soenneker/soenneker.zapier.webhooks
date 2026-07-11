using Soenneker.Zapier.Webhooks.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Zapier.Webhooks.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ZapierWebhookUtilTests : HostedUnitTest
{
    private readonly IZapierWebhookUtil _util;

    public ZapierWebhookUtilTests(Host host) : base(host)
    {
        _util = Resolve<IZapierWebhookUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
