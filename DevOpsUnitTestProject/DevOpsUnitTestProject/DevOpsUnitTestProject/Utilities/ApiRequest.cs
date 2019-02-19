using DevOpsUnitTestProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsUnitTestProject.Utilities
{
    public class ApiEmployeeRequest
    {
        static HttpClient client = new HttpClient();
        public static HttpResponseMessage response { get; set; }
        public static string responseBody { get; set; }

        public async Task<List<Employee>> GetEmployeeAsync(string path)
        {
            response = null;
            responseBody = null;
            client.BaseAddress = new Uri("http://localhost:16061/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Employee> emp = null;
            response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                //responseBody = responseBody.Substring(1, responseBody.Length - 2);
                Newtonsoft.Json.JsonSerializer newSerilizer = new Newtonsoft.Json.JsonSerializer();
                emp = newSerilizer.Deserialize<List<Employee>>(new JsonTextReader(new StringReader(responseBody)));
            }
            return emp;
        }

        public async Task<Employee> AddEmployeeAsync(Employee empData)
        {
            response = null;
            responseBody = null;
            //client.BaseAddress = new Uri("http://localhost:16061/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.PostAsJsonAsync(
            "api/employees", empData);
            Employee emp = null;
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            Newtonsoft.Json.JsonSerializer newSerilizer = new Newtonsoft.Json.JsonSerializer();
            emp = newSerilizer.Deserialize<Employee>(new JsonTextReader(new StringReader(responseBody)));
            return emp;
        }

        public async Task<String> DeleteEmployeeAsync(int Id)
        {
            response = null;
            responseBody = null;
            //client.BaseAddress = new Uri("http://localhost:16061/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.DeleteAsync("api/employees/"+ Id + "");
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();           
            return responseBody;
        }


    }
}
