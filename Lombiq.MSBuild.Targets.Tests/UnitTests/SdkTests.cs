using Lombiq.HelpfulLibraries.Cli;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace Lombiq.MSBuild.Targets.Tests.UnitTests;

public class SdkTests
{
    private CancellationToken Token => TestContext.Current.CancellationToken;
    
    [Fact]
    public async Task NuGetPropertiesShouldBePopulatedAsync()
    {
        var rawPath = Assembly
            .GetExecutingAssembly()
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(a => a.Key == "SdkSamplePath")?
            .Value ?? string.Empty;
        rawPath.ShouldNotBeNullOrEmpty();

        var path = Path.Join(
            Path.GetRelativePath(Environment.CurrentDirectory, rawPath.Replace('/', Path.DirectorySeparatorChar)),
            "Lombiq.MSBuild.Sdk.NuGet.Samples.csproj");

        await CliProgram.DotNet.ExecuteAsync(Token, "pack", path, "--output", nameof(NuGetPropertiesShouldBePopulatedAsync));

        var directoryInfo = new DirectoryInfo(nameof(NuGetPropertiesShouldBePopulatedAsync));

        try
        {
            await using var nupkg = directoryInfo.GetFiles("*.nupkg").ShouldHaveSingleItem().OpenRead();
            await using var zip = new ZipArchive(nupkg);
            await using var nuspec = await zip.GetEntry("Lombiq.MSBuild.Sdk.NuGet.Samples.nuspec").ShouldNotBeNull().OpenAsync(Token);
        
            var xml = new XmlDocument();
            xml.Load(nuspec);
            var elements = xml.SelectNodes("//*").CastWhere<XmlElement>().ToLookup(element => element.Name);
        
            var metadata = new[]
            {
                elements["title"],
                elements["authors"],
                elements["license"],
                elements["copyright"],
                elements["tags"],
                elements["projectUrl"],
            };
            metadata.Select(results => results.SingleOrDefault()?.InnerText).ToArray().ShouldBe([
                "Lombiq MSBuild SDK Sample",
                "Lombiq Technologies",
                "BSD-3-Clause",
                "Copyright © 2026, Lombiq Technologies Ltd.",
                "OrchardCore Lombiq AspNetCore",
                "https://github.com/Lombiq/MSBuild-Targets/",
            ]);
        
            elements["frameworkReference"]
                .Single()
                .Attributes!["name"]!
                .Value
                .ShouldBe("Microsoft.AspNetCore.App");
        
            var dependencies = elements["dependency"].Select(node => node.Attributes["id"]?.Value ?? string.Empty).ToList();
            dependencies.ShouldContain("Lombiq.HelpfulLibraries.OrchardCore");
            dependencies.ShouldContain("OrchardCore.Module.Targets");
        }
        finally
        {
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete(recursive: true);
            }
        }
    }
}
