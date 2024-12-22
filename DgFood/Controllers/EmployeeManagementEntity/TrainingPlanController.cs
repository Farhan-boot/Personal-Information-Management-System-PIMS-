using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Api.Controllers;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.GENERIC.Service.Services.EmployeeManagementEntity;

namespace PTSL.GENERIC.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : BaseController<ITrainingPlanService, TrainingPlanVM, TrainingPlan>
    {
        public TrainingPlanController(ITrainingPlanService service) :
            base(service)
        {
        }
    }
}