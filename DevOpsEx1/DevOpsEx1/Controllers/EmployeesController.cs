using DevOpsEx1.Models;
using DevOpsExe1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DevOpsEx1.Controllers
{
    public class EmployeesController : ApiController
    {
         //Employee[] employees = new Employee[]
         //{
         //   new Employee { ID = 1, Name = "Mark", Age = 30 },
         //   new Employee { ID = 2, Name = "Allan", Age = 35 },
         //   new Employee { ID = 3, Name = "Johny", Age = 21 }
         //};

        public List<Employee> GetAllEmployees()
        {
            var employees = EmployeeRegistration.getInstance().getAllEmployee();
            return employees;
        }

        //public IHttpActionResult GetEmployee(int id)
        //{
        //    var employee = employees.FirstOrDefault((p) => p.ID == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(employee);
        //}

        [HttpGet]
        public Employee GetByEmployeesID(int empID)
        {
            Employee employees_data = EmployeeRegistration.getInstance().GetbyID(empID);
            return employees_data;
        }


        [HttpPost]
        public Employee PostEmployee([FromBody]Employee value)
        {
            Employee emp = new Employee();

            Console.WriteLine("In employeeRegistration");
            Employee empObj = new Employee();
            EmployeeRegistration.getInstance().Add(value);
            empObj.ID = value.ID;
            empObj.Name = value.Name;
            empObj.Age = value.Age;
            return empObj;
        }

        [HttpPut]
        public string UpdateEmployee([FromBody]Employee value)
        {      
                Console.WriteLine("In updateStudentRecord");
                return EmployeeRegistration.getInstance().UpdateEmployee(value);
        }

        [HttpDelete]
        public String DeleteEmployeeRecord(int ID)
        {
            Console.WriteLine("In deleteStudentRecord");
            return EmployeeRegistration.getInstance().Remove(ID);
        }



    }
}