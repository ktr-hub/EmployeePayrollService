using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeePayroll employee = new EmployeePayroll();

            employee.EmployeeName = "rao";
            employee.BasicPay = 123456;
            employee.StartDate = DateTime.Now;
            employee.Department = ".Net";

            //if (repo.AddEmployee(employee))
            //{
            //    Console.WriteLine("Added data to the database");
            //}

            Salary.EmployeesBetweenDateRange(DateTime.Parse("10-14-2019"), DateTime.Parse("10-15-2019"));

            //repo.GetAllEmployee();
        }
    }
}
