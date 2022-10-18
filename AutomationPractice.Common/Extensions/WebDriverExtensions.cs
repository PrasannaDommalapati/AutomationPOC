﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Polly;
using System.Collections.ObjectModel;

namespace AutomationPractice.Common.Extensions
{
    public static class WebDriverExtensions
    {
        private const int MAX_RETRIES = 3;
        //Build the policy
        private static readonly Policy _retryPolicy = Policy.Handle<NoSuchElementException>()
            .Or<StaleElementReferenceException>()
            .Or<ElementClickInterceptedException>()
            .Or<ElementNotInteractableException>()
            .WaitAndRetry(retryCount: MAX_RETRIES, sleepDurationProvider: (attemptCount) => TimeSpan.FromSeconds(attemptCount * 2),
            onRetry: (exception, sleepDuration, attemptNumber, context) =>
            {
                Console.WriteLine($"{exception.Message}. Retrying in {sleepDuration}. {attemptNumber} / {MAX_RETRIES}");
            });

        public static IWebElement FindWebElement(this IWebDriver driver, By locator)
        {
             return _retryPolicy.Execute(action: () => driver.FindElement(locator));
        }

        public static ReadOnlyCollection<IWebElement> FindWebElements(this IWebDriver driver, By by, int timeoutInSeconds = 5)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
    }
}