using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity
{
	public interface IPRLBusiness : IBaseBusiness<PRL>
    {
        Task<(ExecutionState executionState, IList<OfficialInformation> entity, string message)> List();
        Task<(ExecutionState executionState, IList<PRL> entity, string[] empsendingWay, string message)> CreateAsync(IList<PRL> entitys, string noticeType);
    } 
}