using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPostResponsibilityService
    {
        (ExecutionState executionState, List<PostResponsibilityVM> entity, string message) List();
        (ExecutionState executionState, PostResponsibilityVM entity, string message) Create(PostResponsibilityVM model);
        (ExecutionState executionState, PostResponsibilityVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PostResponsibilityVM entity, string message) Update(PostResponsibilityVM model);
        (ExecutionState executionState, PostResponsibilityVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
