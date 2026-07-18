using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System.Threading.Tasks;

namespace Lombiq.MSBuild.Targets.Tests.UI.Extensions;

public static class UITestContextExtensions
{
    public static async Task TestSdkUsingThemeAsync(this UITestContext context)
    {
        void Validate(string cssSelector, string expected) =>
            context.Get(By.CssSelector(cssSelector)).GetTextTrimmed().ShouldBe(expected);

        await context.SignInDirectlyAsync();
        await context.GoToAdminRelativeUrlAsync("/Themes");
        await context.ClickReliablyOnAsync(By.CssSelector("form[action='/Admin/Themes/SetCurrentTheme/Lombiq.MSBuild.Sdk.Samples'] button"));
        
        Validate("h4.card-title", "Lombiq MSBuild SDK - Orchard Core Module Sample");
        Validate(".theme-card p", "If the SDK works, this module is visible with a minimalistic csproj file.");

        await context.GoToHomePageAsync();
        context.Get(By.Id("sdk-test")).GetTextTrimmed().ShouldBe("This is a working theme!");
    }
}
