/*
DROP PROCEDURE [dbo].[sqRetrieveEmployeeSalary]
*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sqRetrieveEmployeeSalary]
AS
BEGIN
 select e.start,e.empId,e.empName,s.basicPay,s.deductions,s.taxablePay,s.netPay,s.tax
 from (employee e inner join payroll s  
 ON e.empId = s.empId);
END
