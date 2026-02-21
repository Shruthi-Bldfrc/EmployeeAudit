namespace EmployeeAudit.Model
{
    public class EmployeeAuditTable
    {
		public int Id { get; set; }

		public int EmployeeId { get; set; }

		public string EmployeeName { get; set; }

		public DateTime ActionDate { get; set; }

		public string ActionType { get; set; }

		public string  ActionUser { get; set; }


	}
}
