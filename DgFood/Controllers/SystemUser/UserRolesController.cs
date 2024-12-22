using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.SystemUser
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : BaseController<IUserRolesService, UserRolesVM, UserRoles>
    {
        public UserRolesController(IUserRolesService userRolesService) :
            base(userRolesService)
        { }
    }
}
