using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : BaseController<IModuleService, ModuleVM, Module>
    {
        public ModuleController(IModuleService Moduleervice) :
            base(Moduleervice)
        { }

        //Implement here new api, if we want.
    }
}
