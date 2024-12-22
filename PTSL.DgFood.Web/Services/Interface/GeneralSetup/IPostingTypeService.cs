using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPostingTypeService
    {
        (ExecutionState executionState, List<PostingTypeVM> entity, string message) List();
        (ExecutionState executionState, PostingTypeVM entity, string message) Create(PostingTypeVM model);
        (ExecutionState executionState, PostingTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PostingTypeVM entity, string message) Update(PostingTypeVM model);
        (ExecutionState executionState, PostingTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
