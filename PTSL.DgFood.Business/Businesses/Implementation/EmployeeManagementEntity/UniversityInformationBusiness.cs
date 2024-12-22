using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.GENERIC.Business.Businesses.Interface.EmployeeManagementEntity;


namespace PTSL.GENERIC.Business.Businesses.Implementation.EmployeeManagementEntity
{
    public class UniversityInformationBusiness : BaseBusiness<UniversityInformation>, IUniversityInformationBusiness
    {
        public UniversityInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}