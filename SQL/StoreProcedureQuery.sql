/*DROP PROCEDURE [sqUpdateEmployeeSalary]*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sqUpdateEmployeeSalary]
	@id int,
	@salary int
AS
BEGIN
 UPDATE payroll
 set basicPay = @salary
 where empId = @id;

 select e.empId,e.empName,s.basicPay,s.deductions,s.taxablePay,s.netPay,s.tax
 from (employee e inner join payroll s  
 ON e.empId = s.empId);
END
