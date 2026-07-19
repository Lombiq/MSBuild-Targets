# Using MSBuild SDKs

> [!NOTE]
> The following document uses [Lombiq.MSBuild.OrchardCore.Module.Sdk](../Lombiq.MSBuild.OrchardCore.Module.Sdk/Readme.md) as an example, but you can achieve the same with all of the `Lombiq.MSBuild.OrchardCore.*.Sdk` projects.

It can be used by updating your project XML's root `Sdk` attribute to contain the NuGet package name and version, like this:

```xml
<Project Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk/1.0.0">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  ...
</Project>
```

Or by removing the `Sdk` attribute and importing the .props and .targets files directly form the NuGet package. In this case the `Sdk` attribute of the import indicates where to look for the file in the NuGet package cache.

```xml
<Project>
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>

  <Import Project="Sdk.props" Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk" Version="1.0.0" />
  ...
  <Import Project="Sdk.targets" Sdk="Lombiq.MSBuild.OrchardCore.Module.Sdk" Version="1.0.0" />
</Project>
```

If you want to use a local copy rather than NuGet, you can import these files by giving a full path, like with any other Targets project:

```xml
<Project>
  <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.OrchardCore.Module.Sdk/Sdk/Import.props" />
  ...
  <Import Project="../../../Utilities/Lombiq.MSBuild.Targets/Lombiq.MSBuild.OrchardCore.Module.Sdk/Sdk/Import.targets" />
</Project>
```

> [!IMPORTANT]
> Make sure to import the _Sdk.props_ and _Sdk.targets_ files for NuGet, but the _Import.props_ and _Import.targets_ files for submodule. They both reference the same [code files](Sdk/Core.props), but there are slight differences accounted in these different consumable files.

You can mix the latter two approaches if you need to support both NuGet and submodule use. We do this in our projects (for example [here](https://github.com/Lombiq/Orchard-Privacy/blob/dev/Lombiq.Privacy/Lombiq.Privacy.csproj)), because `<Sdk Condition="..." Name="...">` is not supported by .NET, so the two cases can only be toggled using imports.

## Common Features

All of our MSBuild SDK projects share these features and configurations:

- Link and pack _Readme.md_ and _NuGetIcon.png_ files, if they exist.
- Link and pack _../Readme.md_ as _Readme.md_ if it doesn't exist in the project directory. This is useful for the primary project of a repository.
- If the project has `<IsLombiqProject>true</IsLombiqProject>` property, then a lot of NuGet properties are provided with appropriate defaults to reduce boilerplate:
  - Authors: Defaults to `Lombiq Technologies`.
  - Copyright: Use the `<CopyrightYear>` property to make it `Copyright © $(CopyrightYear), Lombiq Technologies Ltd.`.
  - Description: Use the `<DescriptionBody>` property to make it `$(Title): $(DescriptionBody)`.
  - PackageIcon: Defaults to `NuGetIcon.png` if _NuGetIcon.png_ exists.
  - PackageTags: Defaults to `OrchardCore;Lombiq;AspNetCore`.
  - PackageProjectUrl: Defaults to the value of `<RepositoryUrl>`, so you don't have to enter both if they are the same.
  - PackageLicenseExpression: Defaults to `BSD-3-Clause`.
- When you import the SDK via the _Import.props_ file, it tries to automatically set these values if they are not yet initialized:
  - LombiqSolutionRootPath: Path of the directory where the solution file and the _src_ directory should be.
  - LombiqHelpfulLibrariesPath: Path of the _src/Libraries/Lombiq.HelpfulLibraries_ directory where the [Lombiq Helpful Libraries](https://github.com/Lombiq/Helpful-Libraries) submodule should be.
  - LombiqAnalyzersPath: Path of the _tools/Lombiq.Analyzers_ directory where the [.NET Analyzers](https://github.com/Lombiq/.NET-Analyzers/) submodule should be.
- If you import the SDK via the `<Sdk>` element or the _Sdk.props_ file, it sets the `<FromNuGet>true</FromNuGet>` property.

## LibMan Integration

If the project importing this SDK has a _libman.json_ file in the project root, then the [Lombiq.MSBuild.LibMan.Targets](../Lombiq.MSBuild.LibMan.Targets/Readme.md) is automatically imported and all of its features can be used. To disable this feature, also include a _.disable-libman_ file in the project root. It can be empty, only file existence is checked.
