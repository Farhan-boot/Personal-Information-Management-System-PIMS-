using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface IRoutesBusiness : IBaseBusiness<Routes>
    {
        Task<(ExecutionState executionState, Routes entity, string message)> RoutesByUserId(Routes model);
        Task<(ExecutionState executionState, IQueryable<Routes> entity, string message)> GetFilterData(QueryOptions<Routes> queryOptions, RoutesVM entity);

    }
}
