# Lombiq MSBuild SDK - Orchard Core Module

## About

MSBuild SDK for Orchard Core modules that also use [Lombiq Helpful Libraries](https://github.com/Lombiq/Helpful-Libraries). Using this instead of `Microsoft.NET.Sdk.Razor` greatly reduces the project file boilerplate. See [Using MSBuild SDKs](../Docs/UsingMSBuildSdks.md) for information on how to use it.

## LibMan Integration

If the project importing this SDK has a _libman.json_ file in the project root, then the [Lombiq.MSBuild.LibMan.Targets](../Lombiq.MSBuild.LibMan.Targets/Readme.md) is automatically imported and all of its features can be used.
