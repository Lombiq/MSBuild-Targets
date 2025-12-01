# Lombiq MSBuild Targets - Library Manager for Orchard Core Modules

## About

Target for Microsoft Library Manager integration. Include this project via NuGet or import its Targets file to ensure the vendor assets in your _libman.json_ are fetched before build and included during publishing.

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

1. Reference the targets in your project file by doing either:
   - Add the `Lombiq.MSBuild.LibMan.Targets` NuGet package to your project.
   - Include an `<Import>` element with the relative path of the Props file at the top end of your project file, and one for the Targets file at bottom end.
2. Reference `Lombiq.HelpfulLibraries.SourceGenerators` by doing either:
   - Reference `Lombiq.MSBuild.Core.Targets` or one of its descendant projects (e.g. `Lombiq.MSBuild.Module.Targets`) the same way as described above. Make sure to put it _after_ the LibMan import.
   - Manually, by following the instructions on [the project's readme](https://github.com/Lombiq/Helpful-Libraries/tree/dev/Lombiq.HelpfulLibraries.SourceGenerators).

For example:

```xml
<Project>
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.props" />
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.Module.Targets/Lombiq.MSBuild.Module.Targets.props" />
    
    <!-- Rest of the project file goes here. -->

    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.targets" />
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.Module.Targets/Lombiq.MSBuild.Module.Targets.targets" />
</Project>
```

or

```xml
<Project>
    <ItemGroup>
        <PackageReference Include="Lombiq.MSBuild.LibMan.Targets" Version="<latest version>" />
        <PackageReference Include="Lombiq.MSBuild.Module.Targets" Version="<latest version>" />
    </ItemGroup>
</Project>
```

### Usage

1. Create a _libman.json_ file in the project if you don't have one yet. (You can use the `libman init` if you've installed [the CLI utility](https://www.nuget.org/packages/Microsoft.Web.LibraryManager.Cli/).)
2. Make sure your _libman.json_ file contains the following top level property: `"defaultDestination": "wwwroot/vendors/[Name]"`. This will ensure that the assets are downloaded to the expected location.
3. Additionally, we suggest this top level property, so you don't have to specify the provider for each package separately: `"defaultProvider": "jsdelivr",`.
4. Now you can install new NPM packages using the CLI tool like this: `libman install "{NpmPackageName}@{Version}"`, e.g. `libman install chart.js@4.5.1`.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
