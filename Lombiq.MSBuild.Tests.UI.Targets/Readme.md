# Lombiq MSBuild Targets - Tests - UI

## About

Target for a UI testing projects.

For general details about and usage instructions see the [root Readme](../Readme.md).

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

### Setup

To use it, either add the `Lombiq.MSBuild.Tests.UI.Targets` NuGet package to your project, or include an `<Import>` element with the relative path of the Props file, if you want to use submodules instead. For example:

```xml
<Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.Tests.UI.Targets/Lombiq.MSBuild.Tests.UI.Targets.targets" />
```

### Configuration

Besides the properties inherited from the [core configuration](../Readme.md#configuration), this target automatically imports `Lombiq.Tests.UI`, unless you have the `<ImportLombiqTests>true</ImportLombiqTests>` property. (This makes sense, because `Lombiq.Tests.UI` already implicitly imports `Lombiq.Tests`, so the only reason to explicitly import it is if you don't need the UI testing library.) This way, you can use this target for both unit testing and UI testing with less overhead.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
