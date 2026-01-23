using EmployeeAudit.Data;
using EmployeeAudit.Model;
using EmployeeAudit.ServiceLayer.ServicesDeclaration;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAudit.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;
		private readonly IEmployeeService _employeeService;
		public EmployeesController(AppDbContext appDbContext,IEmployeeService employeeService)
		{
			_appDbContext = appDbContext;
			_employeeService = employeeService;
		}

		[HttpGet("GetTotalEmployees")]
		public IEnumerable<Employee> GetTotalEmployee()
		{
			return _employeeService.GetTotalEmployeesService();

		}
		[HttpGet("GetEmployeeById/{id}")]
		public IEnumerable<Employee> GetEmployeeById(int id)
		{
			return _employeeService.GetEmployeeByIdService(id);
		}
		[HttpPost("CreateEmployee")]
		public IEnumerable<Employee> CareteEmployee(Employee employee)
		{

			return _employeeService.CreateEmployeesService(employee);
		}
		[HttpPut("UpdateEmployee/{id}")]
		public IEnumerable<Employee> UpdateEmployee(int id, Employee employee)
		{
			return _employeeService.UpdateEmployeesService(id, employee);
		}
		[HttpDelete("DeleteEmployee/{id}")]
		public IEnumerable<Employee> DeleteEmployee(int id)
		{
			return _employeeService.DeleteEmployeeService(id);

		}


	}
}
