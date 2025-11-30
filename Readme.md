# Lombiq MSBuild Targets

## About

It contains MSBuild Target and Props files to streamline and DRY our projects. It has some Lombiq-specific default values, but any project can benefit from it that adopts our solution organization structure.

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

To learn about the `Lombiq.MSBuild.*.Targets` packages maintained in this repository, check out their individual readmes:

- Core: Target for Lombiq-style projects. All other targets import this under the hood.
- [Module](Lombiq.MSBuild.Module.Targets/Readme.md): Target for a Lombiq Orchard Core module, theme or application.
- [LibMan](Lombiq.MSBuild.LibMan.Targets/Readme.md): Target for Microsoft Library Manager integration. Implicitly references `Lombiq.MSBuild.Module.Targets`.
- [Tests.UI](Lombiq.MSBuild.Tests.UI.Targets/Readme.md): Target for a UI testing projects.

## Configuration

There are some properties you can set before importing either of the Props files.

When you set the `<Import{full package name without dots}>` property to true, it imports the project either using `<ProjectReference>` or `<PackageReference>` depending on your current configuration. It also provides centralized version management for the package references. For example:

```xml
  <PropertyGroup>
    <ImportLombiqHelpfulLibrariesOrchardCore>true</ImportLombiqHelpfulLibrariesOrchardCore>
  </PropertyGroup>
```

does the same as

```xml
  <ItemGroup Condition="'$(NuGetBuild)' != 'true'">
    <ProjectReference Include="$(LombiqHelpfulLibrariesPath)\Lombiq.HelpfulLibraries.OrchardCore\Lombiq.HelpfulLibraries.OrchardCore.csproj"/>
  </ItemGroup>

  <ItemGroup Condition="'$(NuGetBuild)' == 'true'">
    <PackageReference Include="Lombiq.HelpfulLibraries.OrchardCore" Version="12.5.0"/>
  </ItemGroup>
```

The following packages are supported:

- `ImportLombiqHelpfulLibrariesCli`: [Lombiq.HelpfulLibraries.Cli](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.Cli/)
- `ImportLombiqHelpfulLibrariesOrchardCore`: [Lombiq.HelpfulLibraries.OrchardCore](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.OrchardCore/)
- `ImportLombiqHelpfulLibrariesLinqToDb`: [Lombiq.HelpfulLibraries.LinqToDb](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.LinqToDb/)
- `ImportLombiqHelpfulLibrariesRefit`: [Lombiq.HelpfulLibraries.Refit](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.Refit/)
- `ImportLombiqHelpfulLibrariesSourceGenerators`: [Lombiq.HelpfulLibraries.SourceGenerators](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.SourceGenerators/)
- `ImportLombiqHelpfulExtensions`: [Lombiq.HelpfulExtensions](https://www.nuget.org/packages/Lombiq.HelpfulExtensions/)
- `ImportLombiqHostingBuildVersionDisplay`: [Lombiq.Hosting.BuildVersionDisplay](https://www.nuget.org/packages/Lombiq.Hosting.BuildVersionDisplay/)
- `ImportLombiqVueJsResources`: [Lombiq.VueJs.Resources](https://www.nuget.org/packages/Lombiq.VueJs.Resources/)
- `ImportLombiqTests`: [Lombiq.Tests.UI](https://www.nuget.org/packages/Lombiq.Tests/)
- `ImportLombiqTestsUI`: [Lombiq.Tests.UI](https://www.nuget.org/packages/Lombiq.Tests.UI/)
- `ImportLombiqTestsUIAppExtensions`: [Lombiq.Tests.UI.AppExtensions](https://www.nuget.org/packages/Lombiq.Tests.UI.AppExtensions/)
- `ImportLombiqPrivacy`: [Lombiq.Privacy](https://www.nuget.org/packages/Lombiq.Privacy/)
- `ImportLombiqPrivacyTestsUI`: [Lombiq.Privacy.Tests.UI](https://www.nuget.org/packages/Lombiq.Privacy.Tests.UI/)

Depending on your project structure, you may have to set the `<SolutionSrcDir>` or `<LombiqHelpfulLibrariesPath>` properties to correctly import these as `<ProjectReference>`. The default value for `<LombiqHelpfulLibrariesPath>` is _$(SolutionSrcDir)\Libraries\Lombiq.HelpfulLibraries_.

If you want to set the `NuGetBuild` property, this should be done before importing the props file as well. It's best practice to do this in the _Directory.Build.props_ instead.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
