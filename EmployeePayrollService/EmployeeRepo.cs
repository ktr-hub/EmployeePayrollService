using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(LocalDb)\Ktr;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employee = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"select empName,deptName,netPay,companyName from employee,department,employeeDepartment,payroll,company
                                     where employeeDepartment.empId = employee.empId 
                                     AND department.deptId = employeeDepartment.deptId
                                     AND payroll.empId = employeeDepartment.empId;";


                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employee.EmployeeName = dr.GetString(0);
                            employee.Department = dr.GetString(1);
                            employee.NetPay = (double)dr.GetDecimal(2);
                            employee.Country = dr.GetString(3);
                            Console.WriteLine("\n"+employee.EmployeeName + " " + employee.Department + " " + employee.NetPay + " " + employee.Country);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data");
                    }
                    dr.Close();

                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

    }
}
