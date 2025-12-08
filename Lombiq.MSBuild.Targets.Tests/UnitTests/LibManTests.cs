using Lombiq.MSBuild.Targets.Samples;
using Shouldly;
using System.IO;
using Xunit;

namespace Lombiq.MSBuild.Targets.Tests.UnitTests;

public class LibManTests
{
    [Fact]
    public void CustomizedAdminPrefixShouldBeUsed()
    {
        File.Exists(Path.Join("wwwroot", "vendors", "async", "dist", "async.min.js")).ShouldBeTrue();
        ResourcesExample.IsVersionCorrectlyGenerated().ShouldBeTrue();
    }
}
