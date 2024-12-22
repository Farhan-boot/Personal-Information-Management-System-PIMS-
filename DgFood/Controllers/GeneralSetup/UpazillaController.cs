using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.Services;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UpazillaController : BaseController<IUpazillaService, UpazillaVM, Upazilla>
    {
        public UpazillaController(IUpazillaService UpazillaService) : base(UpazillaService)
        {
        }
    }
}
