namespace Lombiq.MSBuild.Targets.Samples;

// Here you can see that the version strings from libman.json are exposed as static constants without any special
// configuration. You just have to import Lombiq.MSBuild.LibMan.Targets and include the "[LibManVersions]" attribute.
// (Also reference Lombiq.HelpfulLibraries.SourceGenerators and Lombiq.HelpfulLibraries.SourceGenerators if you are
// using Lombiq.MSBuild.LibMan.Targets as a NuGet package.)

[LibManVersions]
public static partial class ResourcesExample
{
    public static bool IsVersionCorrectlyGenerated() =>
        // We used the NPM package "async" because it's popular, small, and rarely updated.
        LibManVersions.Async == "3.2.6";
}

// END OF TRAINING SECTION: Using Library Manager Targets
