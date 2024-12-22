using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface
{
    public interface IOrganogramService
    {
        (ExecutionState executionState, List<OrganogramVM> entity, string message) List();
        (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) ListDetails();
        (ExecutionState executionState, OrganogramVM entity, string message) Create(OrganogramVM model);
        (ExecutionState executionState, OrganogramVM entity, string message) GetById(long? id);
        (ExecutionState executionState, OrganogramVM entity, string message) Update(OrganogramVM model);
        (ExecutionState executionState, OrganogramVM entity, string message) Delete(long? id);
        (ExecutionState executionState, OrganogramVM entity, string message) GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
		(ExecutionState executionState, bool entity, string message) IsOrganogramPostAvailable(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
	}
}