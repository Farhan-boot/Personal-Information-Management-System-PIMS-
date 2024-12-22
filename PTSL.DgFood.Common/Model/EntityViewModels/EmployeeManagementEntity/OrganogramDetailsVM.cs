namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
	public class OrganogramDetailsVM : OrganogramVM
    {
        public long EmployeeCount { get; set; }
        public bool HasAvailablePost => TotalPost - EmployeeCount > 0;
    }
}
