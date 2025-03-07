using Soenneker.Communication.Sms.Util.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Communication.Sms.Util.Tests;

[Collection("Collection")]
public class AzureSmsUtilTests : FixturedUnitTest
{
    private readonly IAzureSmsUtil _util;

    public AzureSmsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IAzureSmsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
