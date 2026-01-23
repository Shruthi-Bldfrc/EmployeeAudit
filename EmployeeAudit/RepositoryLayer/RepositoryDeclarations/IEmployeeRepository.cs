using EmployeeAudit.Model;

namespace EmployeeAudit.RepositoryLayer.RepositoryDeclarations
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetTotalEmployeesRepository();

		public IEnumerable<Employee> GetEmployeeByIdRepository(int id);
		public IEnumerable<Employee> CreateEmployeesRepository(Employee employee);
		
		public IEnumerable<Employee> UpdateEmployeesRepository(int id, Employee employee);

        public IEnumerable<Employee> DeleteEmployeesRepository(int id);

	}
}
