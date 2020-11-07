using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        public int EmployeeID { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
