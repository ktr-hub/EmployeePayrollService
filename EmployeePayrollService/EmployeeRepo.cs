using System;
using System.Collections.Generic;
using System.Data;
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

                    Console.WriteLine("\nConnection established with the database");

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("\nReading Data Rows : ");
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
        public bool AddEmployee(EmployeePayroll employee)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", employee.EmployeeName);
                    command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    command.Parameters.AddWithValue("@start_Date", employee.StartDate);
                    command.Parameters.AddWithValue("@department", employee.Department);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
