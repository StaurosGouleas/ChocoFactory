using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ChocoFactory.Domain

{
    
    public class Employee : IEmployee
    {

        //properties
        
        public int ID { get; set; }

        
        public decimal Salary { get; set; }

        
        public int DeparmentId { get; set; }

        
        public int ManagerId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public double Phone { get; set; }

        

        //default constructor

        //custom constructor
        //methods
    }
}
