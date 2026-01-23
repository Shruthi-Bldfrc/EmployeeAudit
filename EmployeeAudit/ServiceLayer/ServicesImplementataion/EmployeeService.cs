using EmployeeAudit.Model;
using EmployeeAudit.RepositoryLayer.RepositoryDeclarations;
using EmployeeAudit.RepositoryLayer.RepositoryImplementations;
using EmployeeAudit.ServiceLayer.ServicesDeclaration;

namespace EmployeeAudit.ServiceLayer.ServicesImplementataion
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
		}
		public IEnumerable<Employee> GetTotalEmployeesService()
        {
            return _employeeRepository.GetTotalEmployeesRepository();
		}
		public IEnumerable<Employee> CreateEmployeesService(Employee employee)
		{
			return _employeeRepository.CreateEmployeesRepository(employee);
		}
		public IEnumerable<Employee> GetEmployeeByIdService(int id)
		{
			return _employeeRepository.GetEmployeeByIdRepository(id);
		}
		public IEnumerable<Employee> UpdateEmployeesService(int id, Employee employee)
		{
			return _employeeRepository.UpdateEmployeesRepository(id, employee);

		}
		public IEnumerable<Employee> DeleteEmployeeService(int id)
		{
			return _employeeRepository.DeleteEmployeesRepository(id);
		}
	}
}
