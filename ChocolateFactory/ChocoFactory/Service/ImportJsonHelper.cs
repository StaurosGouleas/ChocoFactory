using ChocoFactory.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Service
{
    internal static class ImportJsonHelper
    {
        public static List<Employee> MockEmployeeList()
        {
            string json = File.ReadAllText(@"..\..\Service\MockEmployeesFile.json");
            List<Employee> Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            return Employees;
        }
    }

   
}