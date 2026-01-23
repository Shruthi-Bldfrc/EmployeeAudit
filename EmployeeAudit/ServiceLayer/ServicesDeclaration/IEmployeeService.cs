using EmployeeAudit.Model;

namespace EmployeeAudit.ServiceLayer.ServicesDeclaration
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetTotalEmployeesService();

		public IEnumerable<Employee> GetEmployeeByIdService(int id);

		public IEnumerable<Employee> CreateEmployeesService(Employee employee);

        public IEnumerable<Employee> UpdateEmployeesService(int id, Employee employee);

        public IEnumerable<Employee> DeleteEmployeeService(int id);
	}
}
