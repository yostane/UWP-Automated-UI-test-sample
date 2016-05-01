using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;

namespace CalculatorTest
{
    [TestClass]
    public class BasicScenarios
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected static IOSDriver<IOSElement> AppSession;
        protected static IOSElement RestultTextElement;
        protected static IOSElement ButtonPlusElement;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //Launch the app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "57b3a460-8843-4d84-822a-9f316274c2bf_tz6ph9wdjhqw8!App");
            AppSession = new IOSDriver<IOSElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(AppSession);
            AppSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            //locate elements
            ButtonPlusElement = AppSession.FindElementByAccessibilityId("btn_plus") as IOSElement;
            Assert.IsNotNull(ButtonPlusElement);
            ButtonPlusElement.Click();
            ButtonPlusElement.Click();
            RestultTextElement = AppSession.FindElementByAccessibilityId("result") as IOSElement;
            Assert.IsNotNull(RestultTextElement);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            RestultTextElement = null;
            AppSession.Dispose();
            AppSession = null;
        }

        [TestMethod]
        public void Case1()
        {
            Assert.AreEqual("2", RestultTextElement.Text);
        }

        [TestMethod]
        public void Case2()
        {
            ButtonPlusElement.Click();
            Assert.AreEqual("2", RestultTextElement.Text);
        }
    }
}
