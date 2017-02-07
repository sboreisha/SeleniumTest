using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Tests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_LoginLink")]
        public IWebElement SignInLink { get; set; }

        [FindsBy(How = How.Id, Using = "uid")]
        public IWebElement UserIdField { get; set; }

        [FindsBy(How = How.Id, Using = "passw")]
        public IWebElement PasswordField { get; set; }
        [FindsBy(How = How.Name, Using = "btnSubmit")]
        public IWebElement LoginButton;

        /// <summary>
        /// JQuery selector example
        /// </summary>
        /*public IWebElement LoginButton {
            get
            {
                return _driver.FindElementByJQuery("input[name='btnSubmit']");
            }
        }
        */
        public void GoToGoogle()
        {
            _driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=Pt2vv1bVIbU");
        }
        public void LoginAsAdmin(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();
            UserIdField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            UserIdField.SendKeys("admin'--");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }

        public void LoginAsNobody(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();
            UserIdField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            UserIdField.SendKeys("nobody");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }
    }
}

