using System;
using System.Globalization;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;
using OpenQA.Selenium.Remote;

namespace Structura.GuiTests
{
    [TestFixture("internet explorer", "11", "WIN8_1", "", "")]
    [TestFixture("chrome", "54", "WIN8_1", "", "")]
    [TestFixture("firefox", "48", "WIN8_1", "", "")]
    public class AltoroMutualTests
    {
        private IWebDriver driver;
        private String browser;
        private String version;
        private String os;
        private String deviceName;
        private String deviceOrientation;
        private LoginPage loginPage;

        /// <summary>
        ///
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="version"></param>
        /// <param name="os"></param>
        /// <param name="deviceName"></param>
        /// <param name="deviceOrientation"></param>
        public AltoroMutualTests(String browser, String version, string os, String deviceName, String deviceOrientation)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
            this.deviceName = deviceName;
            this.deviceOrientation = deviceOrientation;
        }
        [OneTimeSetUp]
        public void SetupTest()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, os);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), caps, TimeSpan.FromSeconds(600));
            loginPage = new LoginPage(driver);

        }

        [OneTimeTearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();

            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
                    }

        [Test]
        public void LoginWithValidCredentialsShouldSucceed()
        {
            loginPage.GoToGoogle();
        }

    }
}


