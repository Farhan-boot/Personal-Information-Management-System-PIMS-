using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaryHistoryController : BaseController<IDisciplinaryHistoryService, DisciplinaryHistoryVM, DisciplinaryHistory>
    {
        private readonly IDisciplinaryHistoryService _disciplinaryHistoryService;
        public DisciplinaryHistoryController(IDisciplinaryHistoryService disciplinaryHistoryService) :
            base(disciplinaryHistoryService)
        {
            _disciplinaryHistoryService = disciplinaryHistoryService;
        }
    }
}