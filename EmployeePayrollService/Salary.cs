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

        
    }
}

