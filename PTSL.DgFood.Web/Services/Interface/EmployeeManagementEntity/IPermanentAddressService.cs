using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPermanentAddressService
    {
        (ExecutionState executionState, List<PermanentAddressVM> entity, string message) List();
        (ExecutionState executionState, PermanentAddressVM entity, string message) Create(PermanentAddressVM model);
        (ExecutionState executionState, PermanentAddressVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PermanentAddressVM entity, string message) Update(PermanentAddressVM model);
        (ExecutionState executionState, PermanentAddressVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) GetFilterData(PermanentAddressFilterVM model);
    }
}