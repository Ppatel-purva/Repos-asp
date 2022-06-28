using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Composite
    {
       

        interface IEmployee
        {
            float GetSalary();
            string GetRole();
            string GetName();
        }
        class Developer : IEmployee
        {
            private string mName;
            private string mSalary;
        }
        public Developer(string name, float salary)
        {
            this.mName = name;
            this.mSalary = salary;
        }
        public float GetSalary()
        {
            return this.mSalary;
        }
        public string GetRole()
        {
            return "Developer";
        }
        public string GetName()
        {
            return mName();
        }
        class Organaization
        {
            protected List<IEmployee> employees;
            public void Orgenization()
            {
                employees = new List<IEmployee>();
            }
            public void AddEmployee(IEmployee employee)
            {
                employees.Add(employee);
            }
            public float GetNetSalaries()
            {
                float netSalaries = 0;
                foreach(var e in employees)
                {
                    netSalaries+= e.GetSalary();
                }
                return netSalaries;
            }

            //use

         
        }
    }
}
var developer = new Developer("hemend,1000");
var Orgenazation = new Orgenazation(developer);
Orgenazation.AddEmployee(developer);

Console.WriteLine("net salary od oragenization is {orgenization.GetNetSalaries():c}");
