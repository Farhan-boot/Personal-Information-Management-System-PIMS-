using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPostingRecordsService
    {
        (ExecutionState executionState, List<PostingRecordsVM> entity, string message) List();
        (ExecutionState executionState, PostingRecordsVM entity, string message) Create(PostingRecordsVM model);
        (ExecutionState executionState, PostingRecordsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PostingRecordsVM entity, string message) Update(PostingRecordsVM model);
        (ExecutionState executionState, PostingRecordsVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) GetFilterData(PostingRecordsFilterVM model);
    }
}