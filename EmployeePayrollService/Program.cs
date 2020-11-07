using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Salary.EmployeesBetweenDateRange(DateTime.Parse("10-14-2019"), DateTime.Parse("10-15-2019"));
            //Salary.EmployeesGroupData();

            EmployeeRepo repo = new EmployeeRepo();
            EmployeePayroll employee = new EmployeePayroll();

            employee.EmployeeName = "rao";
            employee.CompanyId = 420;
            employee.PhoneNumber = "1234567890";
            employee.Address = "1-106,sunnada";
            employee.Department = ".Net";
            employee.Gender = 'M';
            employee.StartDate = DateTime.Parse("10-24-2009");
            employee.City = "srikakulam";
            employee.Country = "India";


            if (repo.AddEmployee(employee))
            {
                Console.WriteLine("Added data to the database");
            }

            repo.AddEmployeeWithThread(employee);
            //repo.GetAllEmployee();
        }
    }
}
