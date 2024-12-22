using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : BaseController<IJobCategoryService, JobCategoryVM, JobCategory>
    {
        public JobCategoryController(IJobCategoryService JobCategoryervice) :
            base(JobCategoryervice)
        { }

        //Implement here new api, if we want.
    }
}
