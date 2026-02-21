using EmployeeAudit.Data;
using EmployeeAudit.Model;
using EmployeeAudit.RepositoryLayer.RepositoryDeclarations;
using System;

namespace EmployeeAudit.RepositoryLayer.RepositoryImplementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
		private readonly AppDbContext _appDbContext;
		public EmployeeRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IEnumerable<Employee> GetTotalEmployeesRepository                                                                                                                                                                                                                                                                                           ()
        {
			//return _appDbContext.Employees.ToList();
			var employees = _appDbContext.Employees.ToList();

			foreach (var emp in employees)
			{
				_appDbContext.EmployeeAudits.Add(new EmployeeAuditTable
				{
					EmployeeId = emp.EmployeeId,
					EmployeeName = emp.EmployeeName,
					ActionDate = DateTime.Now,
					ActionType = "GET",
					ActionUser = Environment.UserName
				});
			}

			_appDbContext.SaveChanges();

			return employees;
		}
		public IEnumerable<Employee> GetEmployeeByIdRepository(int id)
		{
			var employees = _appDbContext.Employees
					   .Where(e => e.EmployeeId == id)
					   .ToList();

			foreach (var emp in employees)
			{
				_appDbContext.EmployeeAudits.Add(new EmployeeAuditTable
				{
					EmployeeId = emp.EmployeeId,   // generated after SaveChanges
					EmployeeName = emp.EmployeeName,
					ActionDate = DateTime.Now,
					ActionType = "GETBYID",
					ActionUser = Environment.UserName
				});
			}

			_appDbContext.SaveChanges();

			return employees;
		}

		public IEnumerable<Employee> CreateEmployeesRepository(Employee employee)
		{
			_appDbContext.Employees.Add(employee);
			_appDbContext.SaveChanges();

			_appDbContext.EmployeeAudits.Add(new EmployeeAuditTable
			{
				EmployeeId = employee.EmployeeId,   // generated after SaveChanges
				EmployeeName = employee.EmployeeName,
				ActionDate = DateTime.Now,
				ActionType = "POST",
				ActionUser = Environment.UserName
			});

			_appDbContext.SaveChanges();

			// 3. Return updated list
			return _appDbContext.Employees.ToList();
		}
		public IEnumerable<Employee> UpdateEmployeesRepository(int id, Employee employee)
		{
			var existingEmployee = _appDbContext.Employees.Find(id);
			if (existingEmployee != null)
			{
				existingEmployee.EmployeeName = employee.EmployeeName;
				// Update other properties as needed
				//_appDbContext.SaveChanges();
				_appDbContext.EmployeeAudits.Add(new EmployeeAuditTable
				{
					EmployeeId = existingEmployee.EmployeeId,
					EmployeeName = existingEmployee.EmployeeName,
					ActionDate = DateTime.Now,
					ActionType = "PUT",
					ActionUser = Environment.UserName
				});
				_appDbContext.SaveChanges();
			}
			// 3. Return updated list
			return _appDbContext.Employees.ToList();
		}
		
		public IEnumerable<Employee> DeleteEmployeesRepository(int id)
		{
			var existingEmployee = _appDbContext.Employees.Find(id);

			if (existingEmployee != null)
			{
				// ✅ Add audit first (we still have employee data)
				_appDbContext.EmployeeAudits.Add(new EmployeeAuditTable
				{
					EmployeeId = existingEmployee.EmployeeId,
					EmployeeName = existingEmployee.EmployeeName,
					ActionDate = DateTime.Now,
					ActionType = "DELETE",
					ActionUser = Environment.UserName
				});

				// ✅ Then delete employee
				_appDbContext.Employees.Remove(existingEmployee);

				// ✅ Save both in single transaction
				_appDbContext.SaveChanges();
			}

			// ✅ Return remaining employees
			return _appDbContext.Employees.ToList();
		}

	}

}

