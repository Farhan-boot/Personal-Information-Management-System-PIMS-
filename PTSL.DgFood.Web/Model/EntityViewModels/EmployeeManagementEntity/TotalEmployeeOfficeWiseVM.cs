using System.Collections.Generic;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
	public class TotalEmployeeOfficeWiseVM
	{
		public long TotalEmployee { get; set; }
		public List<OfficeWiseEmployee> OfficeWiseEmployees { get; set; } = new List<OfficeWiseEmployee>();
	}

	public class OfficeWiseEmployee
	{
		public long PostingId { get; set; }
		public string PostingName { get; set; }
		public long EmployeeCount { get; set; }
	}
}

