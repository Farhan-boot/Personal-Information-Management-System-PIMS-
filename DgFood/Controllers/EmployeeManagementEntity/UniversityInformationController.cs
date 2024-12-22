using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services;
using PTSL.GENERIC.Service.Services.EmployeeManagementEntity;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityInformationController : BaseController<IUniversityInformationService, UniversityInformationVM, UniversityInformation>
    {
        public UniversityInformationController(IUniversityInformationService UniversityInformationService) :
            base(UniversityInformationService)
        { }

        //Implement here new api, if we want.
    }
}
