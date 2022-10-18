using AutomationPractice.Core;
using NUnit.Framework;

namespace AutomationPractice.UiTests
{
    public class Hooks
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            UiTestSession.Current.Start();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            UiTestSession.Current.CleanUp();
        }
    }
}