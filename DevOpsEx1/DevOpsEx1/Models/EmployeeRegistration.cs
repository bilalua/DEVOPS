using DevOpsExe1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOpsEx1.Models
{
    public class EmployeeRegistration
    {
        List<Employee> employeeList;
        static EmployeeRegistration empregd = null;
        private EmployeeRegistration()
        {
            employeeList = new List<Employee>();
        }
        public static EmployeeRegistration getInstance()
        {
            if (empregd == null)
            {
                //Employee[] employees = new Employee[]
                //    {
                //        new Employee { ID = 1, Name = "Mark", Age = 30 },
                //        new Employee { ID = 2, Name = "Allan", Age = 35 },
                //        new Employee { ID = 3, Name = "Johny", Age = 21 }
                //    };
                empregd = new EmployeeRegistration();
                return empregd;
            }
            else
            {
                return empregd;
            }
        }
        public void Add(Employee employee)
        {
            employeeList.Add(employee);
        }
        public String Remove(int idNumber)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                Employee empl = employeeList.ElementAt(i);
                if (empl.ID.Equals(idNumber))
                {
                    employeeList.RemoveAt(i);//update the new record
                    return "Delete successful";
                }
            }
            return "Delete un-successful";
        }
        public List<Employee> getAllEmployee()
        {
            return employeeList;
        }

        public Employee GetbyID(int EmplID)
        {
            var Employee = employeeList.Find(x => x.ID.Equals(EmplID));
            return Employee;
        }

        public String UpdateEmployee(Employee emp)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                Employee empl = employeeList.ElementAt(i);
                if (empl.ID.Equals(emp.ID))
                {
                    employeeList[i] = emp;//update the new record
                    return "Update successful";
                }
            }
            return "Update un-successful";
        }

    }


}