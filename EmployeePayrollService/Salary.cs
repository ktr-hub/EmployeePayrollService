using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeePayrollService.Model.SalaryModel;
using System.Text;
using System.Data;

namespace EmployeePayrollService
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\Ktr;Initial Catalog=payroll_service;Integrated Security=True");
        }

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    SalaryConnection.Open();
                    SqlCommand command = new SqlCommand("sqUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id",salaryUpdateModel.EmployeeId);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int empId = Convert.ToInt32(dr["empId"]);
                            if (empId == salaryUpdateModel.EmployeeId)
                            {
                                return Convert.ToInt32(dr["basicPay"]);
                            }
                        }
                    }

                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return 0;
        }


        public SalaryDetailModel getEmployeeObject(string empName)
        {
            SalaryDetailModel salaryDetail = new SalaryDetailModel();
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    SalaryConnection.Open();
                    SqlCommand command = new SqlCommand("sqRetrieveEmployeeSalary", SalaryConnection);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            String Employeename = dr["empName"].ToString();
                            if (Employeename.Equals(empName))
                            {
                                salaryDetail.EmployeeName = empName;
                                salaryDetail.EmployeeId = (int)dr["empId"];
                                salaryDetail.EmployeeSalary = Convert.ToDouble(dr["basicPay"]);
                                salaryDetail.Deductions = Convert.ToDouble(dr["deductions"]);
                                salaryDetail.TaxablePay = Convert.ToDouble(dr["taxablePay"]);
                                salaryDetail.NetPay = Convert.ToDouble(dr["netPay"]);
                                salaryDetail.tax = Convert.ToDouble(dr["tax"]);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return salaryDetail;
        }

        public static void EmployeesBetweenDateRange(DateTime date1, DateTime date2)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    SqlCommand command = new SqlCommand("sqRetrieveEmployeeSalary", SalaryConnection);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime date = (DateTime)dr["start"];
                            if (date >= date1 && date <= date2)
                            {
                                Console.WriteLine(dr["empName"].ToString());
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
        }

    }
}

