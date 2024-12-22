using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity
{
    public interface IUniversityInformationService
    {
        (ExecutionState executionState, List<UniversityInformationVM> entity, string message) List();
        (ExecutionState executionState, UniversityInformationVM entity, string message) Create(UniversityInformationVM model);
        (ExecutionState executionState, UniversityInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, UniversityInformationVM entity, string message) Update(UniversityInformationVM model);
        (ExecutionState executionState, UniversityInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}