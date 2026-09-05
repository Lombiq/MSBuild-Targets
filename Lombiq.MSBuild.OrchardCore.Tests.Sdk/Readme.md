# Lombiq MSBuild SDK - Unit Testing

This MSBuild SDK can be used for unit testing with the [Lombiq.Tests](https://github.com/Lombiq/Testing-Toolbox) library. See [Using MSBuild SDKs](../Docs/UsingMSBuildSdks.md) for information on how to use it.

The SDK configures xUnit 4 and Microsoft Testing Platform (MTP), including the `Microsoft.Testing.Extensions.GitHubActionsReport`, `Microsoft.Testing.Extensions.TrxReport`, and `Microsoft.Testing.Extensions.HangDump` packages. Projects using central package management must declare versions for these packages and `xunit.v3` in _Directory.Packages.props_.

Use .NET SDK 10 or later, and add `"test": { "runner": "Microsoft.Testing.Platform" }` to the solution's _global.json_. Preserve any existing SDK settings. Run tests with `dotnet test --project path/to/Tests.csproj` or `dotnet test --solution path/to/Solution.slnx`.
