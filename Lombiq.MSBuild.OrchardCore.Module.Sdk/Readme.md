# Lombiq MSBuild SDK - Orchard Core Module

## About

MSBuild SDK for Orchard Core modules that also use [Lombiq Helpful Libraries](https://github.com/Lombiq/Helpful-Libraries). Using this instead of `Microsoft.NET.Sdk.Razor` greatly reduces the project file boilerplate.

## Usage

It can be used by updating your project XML's root `Sdk` attribute to contain the Nuget package name and version, like this: 

```xml
<Project Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk/1.0.0">
  ...
</Project>
```

Or by removing the `Sdk` attribute and importing the .props and .targets files directly form the NuGet package:

```xml
<Project>
  <Import Project="Sdk.props" Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk" Version="1.0.0" />
  ...
  <Import Project="Sdk.targets" Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk" Version="1.0.0" />
</Project>
```

If you want to use a local copy rather than Nuget, you can import these files by giving a full path, like with any other Targets project:

```xml
<Project>
  <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.OrchardCore.Module.Sdk/Sdk/Import.props" />
  ...
  <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.OrchardCore.Module.Sdk/Sdk/Import.targets" />
</Project>
```

> [!NOTE]
> Make sure to import the _Sdk.props_ and _Sdk.targets_ files for NuGet, but the _Import.props_ and _Import.targets_ files for submodule. They both reference the same [code files](Sdk/Core.props), but there are slight differences accounted in these different consumable files.

You can mix the latter two approaches if you need to support both NuGet and submodule use. We do this in our projects (for example [here](https://github.com/Lombiq/Orchard-Privacy/blob/dev/Lombiq.Privacy/Lombiq.Privacy.csproj)), because `<Sdk Condition="..." Name="...">` is not supported by .NET, so the two cases can only be toggled using imports.
