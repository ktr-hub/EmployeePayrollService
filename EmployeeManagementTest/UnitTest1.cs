using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollService.Model.SalaryModel;
using System.Collections.Generic;
using System;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                EmployeeId = 1,
                EmployeeSalary = 10067,
            };

            int empsalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(10067, empsalary);
        }

        [TestMethod]
        public void GivenEmployeeName_AbleToRetrieveSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryDetailModel expected = new SalaryDetailModel()
            {
                EmployeeId = 2,
                EmployeeSalary = 1300,
                EmployeeName = "Vijay",
                Deductions = 500,
                TaxablePay = 0,
                NetPay = 18500,
                tax = 500
            };

            SalaryDetailModel actual = salary.getEmployeeObject("Vijay");
            Assert.IsTrue(expected.Equals(actual));
        }

        /// <summary>
        /// UC1 without multithreading
        /// To observe the difference in execution time
        /// </summary>
        [TestMethod]
        public void AddEmployee_ShouldMatchEmployeeEnries()
        {
            EmployeeRepo repo = new EmployeeRepo();

            EmployeePayroll employee = new EmployeePayroll();
            employee.EmployeeName = "ktrrr";
            employee.Department = ".Net";
            employee.StartDate = DateTime.Parse("10-24-2009");
            
            DateTime startTime = DateTime.Now;
            repo.AddEmployee(employee);
            repo.AddEmployee(employee);
            repo.AddEmployee(employee);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopTime - startTime));
        }

    }
}
