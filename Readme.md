# Lombiq MSBuild Targets

[![Lombiq.MSBuild.LibMan.Targets NuGet](https://img.shields.io/nuget/v/Lombiq.MSBuild.LibMan.Targets?label=Lombiq.MSBuild.LibMan.Targets)](https://www.nuget.org/packages/Lombiq.MSBuild.LibMan.Targets/)

## About

Contains MSBuild Targets and Props files to streamline repetitive project configuration.

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

To learn about the packages maintained in this repository, check out their individual Readmes:

- Targets (`Lombiq.MSBuild.*.Targets`):
  - [LibMan](Lombiq.MSBuild.LibMan.Targets/Readme.md): Targets for [Microsoft Library Manager](https://github.com/aspnet/LibraryManager) integration.
- MSBuild SDKs (`Lombiq.MSBuild.*.Sdk`):
  - [Base](Lombiq.MSBuild.Base.Sdk/Readme.md): The root SDK that configures some common features across all other SDKs. This is imported by our other SDKs, it's unlikely that you'd want to use it directly.
  - [OrchardCore.Module](Lombiq.MSBuild.OrchardCore.Module.Sdk/Readme.md): An SDK for Orchard Core modules.
  - [OrchardCore.Tests](Lombiq.MSBuild.OrchardCore.Tests.Sdk/Readme.md): An SDK for unit test projects using `Lombiq.Tests`.
  - [OrchardCore.Tests.UI](Lombiq.MSBuild.OrchardCore.Tests.UI.Sdk/Readme.md): An SDK for UI test projects using `Lombiq.Tests.UI`.
  - [OrchardCore.Theme](Lombiq.MSBuild.OrchardCore.Theme.Sdk/Readme.md): An SDK for Orchard Core themes.

> [!NOTE]
> Read about how to use and configure our MSBuild SDKs [here](Docs/UsingMSBuildSdks.md).

> [!TIP]
> Check out the [`Lombiq.MSBuild.Targets.Samples` project](Lombiq.MSBuild.Targets.Samples/Readme.md) for examples.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
