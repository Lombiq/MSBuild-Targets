# Lombiq MSBuild SDK - UI Testing

This MSBuild SDK can be used for UI testing Orchard Core projects with the [Lombiq.Tests.UI](https://github.com/Lombiq/UI-Testing-Toolbox) library. See [Using MSBuild SDKs](../Docs/UsingMSBuildSdks.md) for information on how to use it.

It includes the [unit testing SDK](../Lombiq.MSBuild.OrchardCore.Tests.Sdk/Readme.md), which configures the executable xUnit runner, Microsoft Testing Platform, and reporting extensions. UI test projects only need this UI testing SDK; it also supplies the `Lombiq.Tests.UI` dependency. The unit testing SDK's requirements for _global.json_ and central package management apply here too.
