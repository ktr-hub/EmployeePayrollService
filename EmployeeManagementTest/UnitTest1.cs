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
        
    }
}
