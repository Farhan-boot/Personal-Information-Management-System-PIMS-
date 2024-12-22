using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Api.Controllers;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnionController : BaseController<IUnionService, UnionVM, Union>
    {
        public UnionController(IUnionService service) :
            base(service)
        {
        }
    }
}