using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IRankService
    {
        (ExecutionState executionState, List<RankVM> entity, string message) List();
        (ExecutionState executionState, RankVM entity, string message) Create(RankVM model);
        (ExecutionState executionState, RankVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RankVM entity, string message) Update(RankVM model);
        (ExecutionState executionState, RankVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
