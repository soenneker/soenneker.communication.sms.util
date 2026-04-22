using Soenneker.Communication.Sms.Util.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Communication.Sms.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class AzureSmsUtilTests : HostedUnitTest
{
    private readonly IAzureSmsUtil _util;

    public AzureSmsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IAzureSmsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
