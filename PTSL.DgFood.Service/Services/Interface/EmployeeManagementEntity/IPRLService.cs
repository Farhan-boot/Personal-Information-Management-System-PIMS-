using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity
{
    public interface IPRLService : IBaseService<PRL_VM, PRL>
    {
        Task<(ExecutionState executionState, IList<OfficialInformationVM> prlList, string message)> PRLList();
        Task<(ExecutionState executionState, IList<PRL_VM> entitys, string[] prlSendingWay, string message)> CreateAsync(IList<PRL_VM> model, string noticeType);
    }
}