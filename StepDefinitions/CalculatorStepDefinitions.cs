using OpenQA.Selenium;
using CucumberTest.Pages;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Edge;
using System.Xml.Linq;
using OpenQA.Selenium.Chrome;

namespace CucumberTest.StepDefinitions{
    [Binding]
    public sealed class Create_ShiftName{
        IWebDriver webDriver = new EdgeDriver();

        [Given(@"login in accaount")]
        public void Login_Accaunt(Table table){
            webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            LoginAccaunt Login_ac = new LoginAccaunt(webDriver);
            dynamic data = table.CreateDynamicInstance();
            Login_ac.Login((string)data.UserName, (string)data.Password);
        }

        [When(@"click on admin")]
        public void Click_Admin(){
            Profile Profile_page = new Profile(webDriver);
            Profile_page.Click_Admin();
        }

        [When(@"click on job and shiftname")]
        public void Job_ShiftName(){
            Profile mainPage = new Profile(webDriver);
            mainPage.Click_Job_ShiftName();
        }

        [When(@"click on add")]
        public void Add_ShiftName(){
            Profile mainPage = new Profile(webDriver);
            mainPage.Click_Add();
        }

        [When(@"write information")]
        public void Write_Information(Table table){
            Profile mainPage = new Profile(webDriver);
            dynamic data = table.CreateDynamicInstance();
            mainPage.Add_Info((string)data.ShiftName, (string)data.AssignedEmployees);
        }

        [When(@"click on save")]
        public void Save_Info(){
            Profile mainPage = new Profile(webDriver);
            mainPage.Click_Save();
        }

        [Then(@"delete shiftname")]
        public void Delete_ShiftName(){
            Profile mainPage = new Profile(webDriver);
            mainPage.Click_Delete();
        }
    }
}