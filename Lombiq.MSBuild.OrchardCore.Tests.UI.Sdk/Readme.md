# Lombiq MSBuild SDK - UI Testing

This SDK configures executable Orchard Core UI test projects using [Lombiq.Tests.UI](https://github.com/Lombiq/UI-Testing-Toolbox). It includes the [unit testing SDK](../Lombiq.MSBuild.OrchardCore.Tests.Sdk/Readme.md), which supplies the xUnit runner, Microsoft Testing Platform, and reporting extensions. The UI SDK also supplies the `Lombiq.Tests.UI` dependency, so test projects only need the UI SDK reference.

Use [Lombiq.MSBuild.OrchardCore.Tests.UI.Library.Sdk](../Lombiq.MSBuild.OrchardCore.Tests.UI.Library.Sdk/Readme.md) for reusable libraries containing UI test methods. These libraries do not run tests themselves.

See [Using MSBuild SDKs](../Docs/UsingMSBuildSdks.md) for setup. The unit testing SDK's requirements for _global.json_ and central package management apply to this SDK too.
