using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPromtionNatureService
    {
        (ExecutionState executionState, List<PromtionNatureVM> entity, string message) List();
        (ExecutionState executionState, PromtionNatureVM entity, string message) Create(PromtionNatureVM model);
        (ExecutionState executionState, PromtionNatureVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PromtionNatureVM entity, string message) Update(PromtionNatureVM model);
        (ExecutionState executionState, PromtionNatureVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
