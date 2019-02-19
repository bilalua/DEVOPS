using DevOpsUnitTestProject.Models;
using DevOpsUnitTestProject.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DevOpsUnitTestProject
{
    [Binding]
    public class ApiTestingSteps
    {
        public static string deleteMesssage = null;

        [Given(@"I am able to send a GET request to ""(.*)""")]
        public void GivenIAmAbleToSendAGETRequestTo(string p0)
        {
            ApiEmployeeRequest obj = new ApiEmployeeRequest();
            List<Employee> test = obj.GetEmployeeAsync("api/employees").Result;
            
        }
        
        [When(@"I send a POST request to ""(.*)"" with ""(.*)"",""(.*)"" and ""(.*)""")]
        public void WhenISendAPOSTRequestToWithAnd(string p0, int p1, string p2, int p3)
        {
            ApiEmployeeRequest obj = new ApiEmployeeRequest();
            Employee payLoad = new Employee { ID = p1, Name = p2, Age = p3 }; 
            Employee employee_result = obj.AddEmployeeAsync(payLoad).Result;
        }
        
        [When(@"I send a DELETE request to ""(.*)"" with ""(.*)""")]
        public void WhenISendADELETERequestToWith(string p0, int p1)
        {
            deleteMesssage = null;
            ApiEmployeeRequest obj = new ApiEmployeeRequest();
            deleteMesssage = obj.DeleteEmployeeAsync(p1).Result;     
        }
        
        [Then(@"I should get ""(.*)"" response code")]
        public void ThenIShouldGetResponseCode(int p0)
        {
            ApiEmployeeRequest obj = new ApiEmployeeRequest();
            ApiEmployeeRequest.response.EnsureSuccessStatusCode();        
        }
        
        [Then(@"I should see following data")]
        public void ThenIShouldSeeFollowingData(Table table)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                var dictionary = new Dictionary<string, string>();
                foreach (var row in table.Rows)
                {
                    dictionary.Add(row[0], row[1]);
                }
                string getIDValue = dictionary["EmployeeID"].ToString();
                string getNameValue = dictionary["EmployeeName"].ToString();
                string getAgeValue = dictionary["EmployeeAge"].ToString();
                string verificationData = ApiEmployeeRequest.responseBody;
                Assert.True(verificationData.Contains(getIDValue));
                Assert.True(verificationData.Contains(getNameValue));
                Assert.True(verificationData.Contains(getAgeValue));

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        [Then(@"I should see sucessfully deleted message in response")]
        public void ThenIShouldSeeSucessfullyDeletedMessageInResponse()
        {
            Assert.True(deleteMesssage.Contains("Delete successful"));
        }
    }
}
