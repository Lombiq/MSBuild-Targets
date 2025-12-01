# Lombiq MSBuild Targets - Orchard Core Module

## About

Target for a Lombiq Orchard Core module.

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

1. Reference the targets in your project file by doing either:
   - Add the `Lombiq.MSBuild.Module.Targets` NuGet package to your project.
   - Include an `<Import>` element with the relative path of the Props file at the top end of your project file, and one for the Targets file at bottom end.
2. If you want to import a Lombiq package from the list mentioned in the [root Readme](../Readme.md#configuration), add a `<PropertyGroup>` at the top of the project file.

For example:

```xml
<Project>
    <PropertyGroup>
        <ImportLombiqHelpfulLibrariesOrchardCore>true</ImportLombiqHelpfulLibrariesOrchardCore>
        <ImportLombiqHelpfulLibrariesLinqToDb>true</ImportLombiqHelpfulLibrariesLinqToDb>
    </PropertyGroup>
    
    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.Module.Targets/Lombiq.MSBuild.Module.Targets.props" />
    
    <!-- Rest of the project file goes here. -->

    <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.Module.Targets/Lombiq.MSBuild.Module.Targets.targets" />
</Project>
```

or

```xml
<Project>
    <PropertyGroup>
        <ImportLombiqHelpfulLibrariesOrchardCore>true</ImportLombiqHelpfulLibrariesOrchardCore>
        <ImportLombiqHelpfulLibrariesLinqToDb>true</ImportLombiqHelpfulLibrariesLinqToDb>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Lombiq.MSBuild.Module.Targets" Version="<latest version>" />
    </ItemGroup>
</Project>
```

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
