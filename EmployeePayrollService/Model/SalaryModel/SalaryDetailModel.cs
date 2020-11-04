using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService.Model.SalaryModel
{
    public class SalaryDetailModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double tax { get; set; }
        public double EmployeeSalary { get; set; }
        public double Deductions { get; set; }
        public double NetPay { get; set; }
        public double TaxablePay { get; set; }
        
        public bool Equals(SalaryDetailModel salary)
        {
            if (this.EmployeeId == salary.EmployeeId &&
                this.EmployeeName == salary.EmployeeName &&
                this.tax == salary.tax &&
                this.EmployeeSalary == salary.EmployeeSalary &&
                this.Deductions == salary.Deductions &&
                this.NetPay == salary.NetPay &&
                this.TaxablePay == salary.TaxablePay)
            {
                return true;
            }
            return false;
        }

    }
}
