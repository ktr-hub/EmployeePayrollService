using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService.Model.SalaryModel
{
    public class SalaryUpdateModel
    {
        //public int SalaryId { get; set; }
        //public string Month { get; set; }
        public double EmployeeSalary { get; set; }
        public int EmployeeId { get; set; }
   
        
    }
}
