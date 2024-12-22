using System.Collections.Generic;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
	public class DirectAndPromotionalEmployeeVM
	{
		public long DirectEmployee { get; set; }
		public long PromotionalEmployee { get; set; }

		public List<OfficeWiseEmployee> OfficeWiseDirectEmployees { get; set; } = new List<OfficeWiseEmployee>();
		public List<OfficeWiseEmployee> OfficeWisePromotionalEmployees { get; set; } = new List<OfficeWiseEmployee>();
	}
}

