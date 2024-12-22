using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface IDesignationBusiness : IBaseBusiness<Designation>
    {
        Task<(ExecutionState executionState, IQueryable<Designation> entity, string message)> GetByRankAndDesignationClass(long? rankId, long? designationClassId);
    }
}
