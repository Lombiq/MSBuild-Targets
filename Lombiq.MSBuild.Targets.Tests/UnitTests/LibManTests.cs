using Lombiq.MSBuild.Targets.Samples;
using Shouldly;
using System.IO;
using Xunit;

namespace Lombiq.MSBuild.Targets.Tests.UnitTests;

public class LibManTests
{
    [Fact]
    public void DownloadedFileShouldExist() =>
        File.Exists(Path.Join("wwwroot", "vendors", "async", "dist", "async.min.js")).ShouldBeTrue();

    [Fact]
    public void CorrectVersionStringShouldBeGenerated() =>
        ResourcesExample.IsVersionCorrectlyGenerated().ShouldBeTrue();
}
