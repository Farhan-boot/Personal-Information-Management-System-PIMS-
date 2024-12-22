using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IJobCategoryService
    {
        (ExecutionState executionState, List<JobCategoryVM> entity, string message) List();
        (ExecutionState executionState, JobCategoryVM entity, string message) Create(JobCategoryVM model);
        (ExecutionState executionState, JobCategoryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, JobCategoryVM entity, string message) Update(JobCategoryVM model);
        (ExecutionState executionState, JobCategoryVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
