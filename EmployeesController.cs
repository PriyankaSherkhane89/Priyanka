using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMWebApp.Models;
//new comment
//Comment by Priya Patil
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRMWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id=  10, FirstName=  "Manisha", LastName=  "Waghmare", Location=  "Mumbai", Department = "HR", ContactNumber = "8562246685", Email = "manisha123@gmail.com" });
            employees.Add(new Employee { Id = 11, FirstName = "Bhagyashri", LastName = "Lahade", Location = "Latur", Department = "Admin", ContactNumber = "9852156322", Email = "bhagyashri89@gmail.com" });
            employees.Add(new Employee { Id = 12, FirstName = "Sneha", LastName = "Surwase", Location = "Solapur", Department = "Manager", ContactNumber = "9236587456", Email = "sneha97@gmail.com" });
            employees.Add(new Employee { Id = 13, FirstName = "Kavita", LastName = "Suryawanshi", Location = "Pune", Department = "Programmer", ContactNumber = "77854216352", Email = "kavita45@gmail.com" });
            employees.Add(new Employee { Id = 14, FirstName = "Rupali", LastName = "Nadre", Location = "Nanded", Department = "Sales", ContactNumber = "9654822435", Email = "rupali34@gmail.com" });
            employees.Add(new Employee { Id = 15, FirstName = "Ankita", LastName = "Yadde", Location = "Chakur", Department = "Service", ContactNumber = "9525856542", Email = "ankita23@gmail.com" });
            //return Json(employees, JsonRequestBehavior.AllowGet);
            return View(employees);

            Console.WriteLine("Object is serialized");
            FileStream fs = new FileStream("employees.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, employees);
            fs.Close();

            Console.WriteLine("File has been stored with all list of person data");
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Employees retrieved from file using deserialization");
//first change
        }
    }
}
