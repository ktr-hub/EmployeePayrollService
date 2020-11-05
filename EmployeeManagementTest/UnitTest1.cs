using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollService.Model.SalaryModel;

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
                EmployeeSalary = 10060,
            };

            int empsalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(10060, empsalary);
        }

        [TestMethod]
        public void GivenStringName_AbleToRetrieveSalaryDetails()
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



    }
}
