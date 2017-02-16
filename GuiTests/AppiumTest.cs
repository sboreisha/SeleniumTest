using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using System.Drawing;

namespace Structura.GuiTests
{
    [TestFixture]
    class AppiumTest
    {
        public AppiumDriver<IWebElement> driver;
        public AndroidDriver<IWebElement> driver2;
        public DesiredCapabilities capabilities;

        public AppiumTest()
        {
            Console.WriteLine("Connecting to Appium server");
            capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "donatello");
            capabilities.SetCapability("platformVersion", "6.0");
            capabilities.SetCapability("platformName", "Android");

            capabilities.SetCapability("appPackage", "com.experitest.ExperiBank");
            capabilities.SetCapability("appActivity", ".LoginActivity");
            
            //Application path and configurations
            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }
        [Test]
        public void TestAndroid()
        {
            Console.WriteLine("console");
            TestContext.WriteLine("context");

            //userName - com.experitest.ExperiBank:id/usernameTextField            
            driver.FindElement(By.Id("com.experitest.ExperiBank:id/usernameTextField")).SendKeys("company");

            //pwd- com.experitest.ExperiBank:id/passwordTextField      
            driver.FindElement(By.Id("com.experitest.ExperiBank:id/passwordTextField")).SendKeys("company");

            //login- com.experitest.ExperiBank:id/loginButton
            driver.FindElement(By.Id("com.experitest.ExperiBank:id/loginButton")).Click();

            //logout - com.experitest.ExperiBank:id/logoutButton
            driver.FindElement(By.Id("com.experitest.ExperiBank:id/logoutButton")).Click();

            Thread.Sleep(5000);
            driver.Quit();
            Assert.Pass("Your first passing test");
        }

    }
}
