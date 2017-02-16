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
using Titanium.Web.Proxy.Examples.Basic;
using System.Collections.Generic;

namespace Structura.GuiTests
{
    [TestFixture("chrome", "54", "WIN8_1", "", "")]
    public class AltoroMutualTests
    {
        private IWebDriver driver;
        private String browser;
        private String version;
        private String os;
        private String deviceName;
        private String deviceOrientation;
        private LoginPage loginPage;
        private ProxyTestController Controller;

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
            Controller = new ProxyTestController();
           Controller.StartProxy();
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, os);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            var proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.IsAutoDetect = false;
            proxy.HttpProxy =
            proxy.SslProxy = "127.0.0.1:8001";
           // caps.SetCapability(CapabilityType.Proxy, proxy);
            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), caps, TimeSpan.FromSeconds(600));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            loginPage = new LoginPage(driver);
          
        }

        [OneTimeTearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                Controller.Stop();

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
            Console.WriteLine("console");
            TestContext.WriteLine("context");
                       Assert.Pass("Your first passing test");
        }

    }
}


