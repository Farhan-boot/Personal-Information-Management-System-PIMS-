using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IEmployeeInformationService
    {
        (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) List();
        (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) EmployeeList();
        (ExecutionState executionState, EmployeeInformationVM entity, string message) Create(EmployeeInformationVM model);
        (ExecutionState executionState, EmployeeInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeeInformationVM entity, string message) GetEmployeeFullInfoById(long? id);
        (ExecutionState executionState, EmployeeInformationVM entity, string message) GetEmployeeBasicInfoById(long? id);
        (ExecutionState executionState, EmployeeInformationVM entity, string message) Update(EmployeeInformationVM model);
        (ExecutionState executionState, EmployeeInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) GetFilterData(EmployeeInformationFilterVM model);
        (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) EmployeeListBySP(EmployeeInformationFilterVM model);
        (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeByEmail(EmployeeInformationVM model);
        (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeByEmailWithAllIncluding(EmployeeInformationVM model);
        (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeList();
        (ExecutionState executionState, string message) UpdateExistingEmployeeData();

    }
}