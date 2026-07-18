# Lombiq MSBuild Targets - Library Manager for Orchard Core Modules

## About

Targets for [Microsoft Library Manager](https://github.com/aspnet/LibraryManager) integration. Include this project via NuGet or import its Props and Targets files to ensure the vendor assets in your _libman.json_ are fetched before build and included during publishing.

This target reduces [configuration boilerplate related to code generation](https://github.com/Lombiq/Helpful-Libraries/tree/dev/Lombiq.HelpfulLibraries.SourceGenerators) and applies necessary workarounds (e.g. issues with deployment mentioned [here](https://github.com/aspnet/LibraryManager/issues/799)).

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

#### From a Git submodule

1. Reference the targets in your project file by adding an `<Import>` element with the relative path of the Props file at the top end of your project file, and one for the Targets file at bottom end.
2. If the `Lombiq.HelpfulLibraries.SourceGenerators` project is not found, specify the local relative path to the submodule in the `<LombiqHelpfulLibrariesPath>` property _before_ the `<Import>` element for the Props file.

For example:

```xml
<Project>
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.props" />
    
    <ItemGroup>
        <PackageReference Include="Microsoft.Web.LibraryManager.Build" Version="3.0.114" />
    </ItemGroup>

    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.targets" />
</Project>
```

#### From a NuGet package

1. Reference the targets in your project file by adding the [`Lombiq.MSBuild.LibMan.Targets`](https://www.nuget.org/packages/Lombiq.MSBuild.LibMan.Targets) NuGet package.
2. To use Library Manager during build, reference the [`Microsoft.Web.LibraryManager.Build`](https://www.nuget.org/packages/Lombiq.MSBuild.LibMan.Targets) NuGet package.
3. Optionally, if you want to use the automatically generated version numbers (e.g. when declaring an asset in the Orchard Core resource manager), you have to include the [`Lombiq.HelpfulLibraries.SourceGenerators`](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.SourceGenerators/) and [`Lombiq.HelpfulLibraries.Attributes`](https://www.nuget.org/packages/Lombiq.HelpfulLibraries.Attributes/) projects from the Lombiq HelpfulLibraries.

For example:

```xml
<Project>
    <ItemGroup>
        <PackageReference Include="Microsoft.Web.LibraryManager.Build" Version="<latest version>" />
        <PackageReference Include="Lombiq.MSBuild.LibMan.Targets" Version="<latest version>" />
        <PackageReference Include="Lombiq.HelpfulLibraries.Attributes" Version="12.6.1-alpha.10.osoe-925" OutputItemType="Analyzer" ReferenceOutputAssembly="true" />
        <PackageReference Include="Lombiq.HelpfulLibraries.SourceGenerators" Version="12.6.1-alpha.10.osoe-925" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
    </ItemGroup>
</Project>
```

### Usage

1. If you don't have a _libman.json_ file yet, build the project after setup. This will copy an empty _libman.json_ file into the project directory, which is pre-configured to use the expected package output directory.
2. Now you can install new NPM packages using the CLI tool like this: `libman install "{NpmPackageName}@{Version}"`, e.g. `libman install chart.js@4.5.1`.
3. If you want to use the automatically generated version numbers (e.g. when declaring an asset in the Orchard Core resource manager), follow [the instructions in the Helpful Libraries documentation](https://github.com/Lombiq/Helpful-Libraries/tree/dev/Lombiq.HelpfulLibraries.SourceGenerators#using-the-libmanresourceversiongenerator).

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
