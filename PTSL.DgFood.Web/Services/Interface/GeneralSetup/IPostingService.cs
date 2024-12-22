using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPostingService
    {
        (ExecutionState executionState, List<PostingVM> entity, string message) List();
        (ExecutionState executionState, PostingVM entity, string message) Create(PostingVM model);
        (ExecutionState executionState, PostingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PostingVM entity, string message) Update(PostingVM model);
        (ExecutionState executionState, PostingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
