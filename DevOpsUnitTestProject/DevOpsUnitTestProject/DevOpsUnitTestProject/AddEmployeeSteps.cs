using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace DevOpsUnitTestProject
{
    [Binding]
    public class AddEmployeeSteps
    {
        IWebDriver driver;
        WebDriverWait UserWait;

        [Given(@"I open the web ""(.*)"" site")]
        public void GivenIOpenTheWebon(string p1)
        {         
                    driver = new ChromeDriver();
                    UserWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));          
                // http://localhost:16061/Home/Index
                driver.Navigate().GoToUrl(p1);
        }
        
        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string p0)
        { 
            try
            { 
            UserWait.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
            UserWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'"+ p0 +"')]")));

            driver.FindElement(By.XPath("//button[contains(text(),'" + p0 + "')]")).Click();
            }      

            catch(NoSuchElementException ex)
            {
                driver.Quit();
                throw ex;
            }

            catch(TimeoutException ex)
            {
                driver.Quit();
                throw ex;
            }

            catch (Exception Ex)
            {
                driver.FindElement(By.Id("btnAdd")).Click();
            }



        }
        [When(@"I enter following emplyee data ""(.*)"",""(.*)"",""(.*)""")]
        public void WhenIEneterFollowingEmplyeeData(string p0, string p1, string p2)
        {
            try
            { 
            UserWait.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
            UserWait.Until(ExpectedConditions.ElementIsVisible(By.Id("ID")));
            driver.FindElement(By.Id("ID")).SendKeys(p0);
            driver.FindElement(By.Id("Name")).SendKeys(p1);
            driver.FindElement(By.Id("Age")).SendKeys(p2);
            }
            catch(Exception ex)
            {
                driver.Quit();
                throw ex;
            }
        }
        
        [Then(@"I should see added Id and should remove the data")]
        public void ThenIShouldSeeFollowingInformationOnPage(Table table)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                var dictionary = new Dictionary<string, string>();
                foreach (var row in table.Rows)
                {
                    dictionary.Add(row[0], row[1]);
                }
                string getIDValue = dictionary["ID"].ToString();
                bool recordFoundAndDelete = false;
                UserWait.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
                System.Threading.Thread.Sleep(1000);
                List<IWebElement> list = driver.FindElements(By.XPath("//tbody/tr")).ToList();
                foreach (var item in list)
                {
                    List<IWebElement> innerList = item.FindElements(By.XPath(".//td")).ToList();
                    foreach (var tditem in innerList)
                    {
                        if(tditem.Text == getIDValue)
                        {
                            item.FindElement(By.XPath(".//td/a")).Click();
                            recordFoundAndDelete = true;
                            break;
                        }
                    }
                }
                Assert.IsTrue(recordFoundAndDelete);
                System.Threading.Thread.Sleep(100);
                driver.Quit();
            }
            catch(Exception ex)
            {
                driver.Quit();
                throw ex;
            }
        }


    }
}
