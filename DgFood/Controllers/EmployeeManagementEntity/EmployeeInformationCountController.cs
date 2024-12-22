using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInformationCountController : BaseController<IEmployeeInformationCountService, EmployeeInformationCountVM, EmployeeInformationCount>
    {
        public EmployeeInformationCountController(IEmployeeInformationCountService employeeInformationCountService) :
            base(employeeInformationCountService)
        { }

        //Implement here new api, if we want.
    }
}
