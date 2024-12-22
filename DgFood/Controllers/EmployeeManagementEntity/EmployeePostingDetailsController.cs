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
    public class EmployeePostingDetailsController : BaseController<IEmployeePostingDetailsService, EmployeePostingDetailsVM, EmployeePostingDetails>
    {
        public EmployeePostingDetailsController(IEmployeePostingDetailsService service) :
            base(service)
        {
        }
    }
}