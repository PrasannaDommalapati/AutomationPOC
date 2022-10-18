using AutomationPractice.Common.Extensions;
using AutomationPractice.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.UiTests;

[TestFixture]
public class WebdriverInjectionTests : Hooks
{
    private IWebDriver? _driver;

    [Test]
    public void Test1()
    {
        _driver = UiTestSession.Current.Resolve<IWebDriver>();
        var url = UiTestSession.Current.Settings.ApplicationUrl;
        _driver.Navigate().GoToUrl(url);
        var ele = _driver.FindWebElement(By.Id("L2AGLb"));
        ele.Click();
        Assert.Pass();
    }

    [TearDown]
    public void CleanUp()
    {
        _driver?.Close();
        _driver?.Quit();
    }
}