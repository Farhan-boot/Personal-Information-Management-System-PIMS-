using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPresentAddressService
    {
        (ExecutionState executionState, List<PresentAddressVM> entity, string message) List();
        (ExecutionState executionState, PresentAddressVM entity, string message) Create(PresentAddressVM model);
        (ExecutionState executionState, PresentAddressVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PresentAddressVM entity, string message) Update(PresentAddressVM model);
        (ExecutionState executionState, PresentAddressVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<PresentAddressListVM> entity, string message) GetFilterData(PresentAddressFilterVM model);
    }
}