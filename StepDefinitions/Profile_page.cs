using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CucumberTest.Pages
{
    internal class Profile{
        private IWebDriver webDriver { get; }

        public Profile(IWebDriver webDriver1){
            webDriver = webDriver1;
        }

        private IWebElement Admin_button;
        public void Click_Admin(){
            Thread.Sleep(1500);
            Admin_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/aside/nav/div[2]/ul/li[1]/a"));
            Admin_button.Click();
        }

        private IWebElement Job_button;
        private IWebElement ShiftName_button;
        public void Click_Job_ShiftName(){
            Thread.Sleep(1000);
            Job_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]"));
            Job_button.Click();
            ShiftName_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[5]/a"));
            ShiftName_button.Click();
        }

        private IWebElement Add_button;
        public void Click_Add(){
            Thread.Sleep(1000);
            Add_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[1]/div/button/i"));
            Add_button.Click();
        }

        private IWebElement ShiftName_text;
        private IWebElement AssignedEmployees_text;
        private IWebElement ClickOdis;
        private IWebElement Time_button;
        private IWebElement TimeFrom_button;
        private IWebElement TimesetFrom_button;
        private IWebElement TimeTo_button;
        private IWebElement TimesetTo_button;
        public void Add_Info(string shiftName, string assignedEmployees){
            Thread.Sleep(1000);
            ShiftName_text = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/input"));
            AssignedEmployees_text = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[1]/input"));
            ShiftName_text.SendKeys(shiftName);
            AssignedEmployees_text.SendKeys(assignedEmployees);
            Thread.Sleep(3000);
            ClickOdis = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[2]"));
            Thread.Sleep(1000);
            ClickOdis.Click();

            Time_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[2]"));
            Time_button.Click();

            TimeFrom_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[1]/input"));
            TimeFrom_button.Click();

            for (int i = 0; i < 3; i++)
            {
                TimesetFrom_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[2]/div[1]/i[2]"));
                TimesetFrom_button.Click();
            }
            Thread.Sleep(1000);
            TimeTo_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[1]/input"));
            TimeTo_button.Click();

            for (int i = 0; i < 1; i++)
            {
                TimesetTo_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[2]/div[1]/i[1]"));
                TimesetTo_button.Click();
            }
            Thread.Sleep(1000);
        }


        private IWebElement Save_button;
        public void Click_Save(){
            Save_button = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[4]/button[2]"));
            Save_button.Click();
        }

        private IWebElement Delete_button;
        private IWebElement ConfirmDelete_button;
        public void Click_Delete(){
            Thread.Sleep(4000);
           
            Delete_button = webDriver.FindElement(By.XPath($"/html/body/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div/div/div/div[1]/div[2]/div/div/button[1]/i"));
            Delete_button.Click();
            Thread.Sleep(3000);
            ConfirmDelete_button = webDriver.FindElement(By.XPath($"/html/body/div/div[3]/div/div/div/div[3]/button[2]"));
            ConfirmDelete_button.Click();
        }
    }
}