using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q2
{
    class Employee
    {
        public string EmpoyeeName { get; set; }
        public bool Male { get; set; }
        public int Salary { get; set; }
        public string Moblie { get; set; }

        public Employee()
        {
        }

        public Employee(string empoyeeName, bool male, int salary, string moblie)
        {
            EmpoyeeName = empoyeeName;
            Male = male;
            Salary = salary;
            Moblie = moblie;
        }
    }
}
