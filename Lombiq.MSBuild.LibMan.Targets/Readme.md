# Lombiq MSBuild Targets - Library Manager for Orchard Core Modules

## About

Target for Microsoft Library Manager integration. Include this project via NuGet or import its Targets file to ensure the vendor assets in your _libman.json_ are fetched before build and included during publishing.

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

To use it, either add the `Lombiq.MSBuild.LibMan.Targets` NuGet package to your project, or include an `<Import>` element with the relative path of the Targets file, if you want to use submodules instead. For example:

```xml
<Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.LibMan.Targets/Lombiq.MSBuild.LibMan.Targets.targets" />
```

### Usage

1. Create a _libman.json_ file in the project if you don't have one yet. (You can use the `libman init` if you've installed [the CLI utility](https://www.nuget.org/packages/Microsoft.Web.LibraryManager.Cli/).)
2. Make sure your _libman.json_ file contains the following top level property: `"defaultDestination": "wwwroot/vendors/[Name]"`. This will ensure that the assets are downloaded to the expected location.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
