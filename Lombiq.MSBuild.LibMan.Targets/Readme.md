# Lombiq MSBuild Targets - Library Manager for Orchard Core Modules

## About

Target for Microsoft Library Manager integration. Include this project via NuGet or import its Props and Targets files to ensure the vendor assets in your _libman.json_ are fetched before build and included during publishing.

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

1. Reference the targets in your project file by doing either:
   - Add the `Lombiq.MSBuild.LibMan.Targets` NuGet package to your project.
   - Include an `<Import>` element with the relative path of the Props file at the top end of your project file, and one for the Targets file at bottom end.
2. If using submodules and the `Lombiq.HelpfulLibraries.SourceGenerators` project is not found, specify the local relative path to the submodule in the `<LombiqHelpfulLibrariesPath>` property.

For example:

```xml
<Project>
    <PropertyGroup>
        <LombiqHelpfulLibrariesPath>../../../Libraries/Lombiq.HelpfulLibraries</LombiqHelpfulLibrariesPath>
    </PropertyGroup>
    
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.props" />
    
    <!-- Rest of the project file goes here. -->

    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.targets" />
</Project>
```

or

```xml
<Project>
    <ItemGroup>
        <PackageReference Include="Lombiq.MSBuild.LibMan.Targets" Version="<latest version>" />
    </ItemGroup>
</Project>
```

### Usage

1. If you don't have a _libman.json_ file yet, build the project after setup. This will copy an empty _libman.json_ file into the project directory, which is pre-configured to use the expected package output directory.
2. Now you can install new NPM packages using the CLI tool like this: `libman install "{NpmPackageName}@{Version}"`, e.g. `libman install chart.js@4.5.1`.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
