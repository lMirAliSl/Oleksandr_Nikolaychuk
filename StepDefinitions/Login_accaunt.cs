using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CucumberTest.Pages
{
    internal class LoginAccaunt
    {
        public IWebDriver webDriver { get; }
        public IWebElement Login_button;
        public IWebElement UserName_text;
        public IWebElement Password_text;
        public LoginAccaunt(IWebDriver webDriver1)
        {
            webDriver = webDriver1;
        }

        private void Init()
        {
            Thread.Sleep(2000);
            Login_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div/div[2]/div[2]/form/div[3]/button"));
            UserName_text = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div/div[2]/div[2]/form/div[1]/div/div[2]/input"));
            Password_text = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div/div[2]/div[2]/form/div[2]/div/div[2]/input"));
        }
     
        public void Login(string userName, string password)
        {
            Init();
            UserName_text.SendKeys(userName);
            Password_text.SendKeys(password);
            ClickLoginButton();
        }
        private void ClickLoginButton() => Login_button.Click();
    }
}