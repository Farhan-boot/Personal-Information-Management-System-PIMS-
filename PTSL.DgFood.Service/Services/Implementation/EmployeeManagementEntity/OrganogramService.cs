using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class OrganogramService : BaseService<OrganogramVM, Organogram>, IOrganogramService
    {
        public readonly IOrganogramBusiness _OrganogramBusiness;
        public IMapper _mapper;
        public OrganogramService(IOrganogramBusiness OrganogramBusiness, IMapper mapper) : base(OrganogramBusiness)
        {
            _OrganogramBusiness = OrganogramBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Organogram CastModelToEntity(OrganogramVM model)
        {
            try
            {
                return _mapper.Map<Organogram>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override OrganogramVM CastEntityToModel(Organogram entity)
        {
            try
            {
                OrganogramVM model = _mapper.Map<OrganogramVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public IList<EmployeeInformationVM>  CastEntityToModel(IList<EmployeeInformation> empList)
        {
            try
            {
                 IList<EmployeeInformationVM> model = _mapper.Map<IList<EmployeeInformationVM>>(empList);

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<OrganogramVM> CastEntityToModel(IQueryable<Organogram> entity)
        {
            try
            {
                IList<OrganogramVM> colorList = _mapper.Map<IList<OrganogramVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<OrganogramDetailsVM> entity, string message)> ListDetails()
        {
            (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) result = 
                (ExecutionState.Failure, new List<OrganogramDetailsVM>(), "Failed to load data.");
            var organograms = await base.List();
            var organogramWithEmployeeCount = new List<OrganogramDetailsVM>();

            // Loop over organogram and count the employee
            if (organograms.entity != null)
            {
                foreach (var organogram in organograms.entity)
                {
                    // Get Employee Count from db
                    var employeeCount = await _OrganogramBusiness.CountEmployeeByPostDesignation(
                        organogram.OrganogramOfficeType,
                        organogram.PostingId,
                        organogram.DesignationID,
                        organogram.IsPermanent
                        );

                    // Map to OrganogramDetailsVM
                    OrganogramDetailsVM mapped;
                    try
                    {
                        mapped = _mapper.Map<OrganogramDetailsVM>(organogram);
                    }
                    catch
                    {
                        return result;
                    }

                    // Add to the list
                    if (employeeCount.executionState != ExecutionState.Failure)
                        mapped.EmployeeCount = employeeCount.entity;
                    organogramWithEmployeeCount.Add(mapped);
                }
            }

            result.executionState = organograms.executionState;
            result.entity = organogramWithEmployeeCount;
            result.message = organograms.message;

            return result;
        }

        public async Task<(ExecutionState executionState, IList<OrganogramVM> entity, string message)> CustomDelete(long id)
        {
            try
            {
                (ExecutionState executionState, IList<OrganogramVM> entity, string message) result = await _OrganogramBusiness.CustomDelete(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, OrganogramVM entity, string message)> GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            try
            {
                (ExecutionState executionState, Organogram entity, string message) result = await _OrganogramBusiness.GetOrganogramByPostDesignation(officeType, postingId, designationId, isPermanent);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    return (result.executionState, CastEntityToModel(result.entity), result.message);
                }
                return (result.executionState, null, result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<EmployeeInformationVM> organogramList, string message)> GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            try
            {
                (ExecutionState executionState, IList<EmployeeInformation> organogramList, string message) result = await _OrganogramBusiness.GetEmployeeByPostDesignation(officeType, postingId, designationId, isPermanent);

                if(result.executionState == ExecutionState.Retrieved)
                {
                    var mapped = new List<EmployeeInformationVM>();

                    foreach (var employee in result.organogramList)
                    {
                        var emp = _mapper.Map<EmployeeInformationVM>(employee);
                        var official = employee.OfficialInformation.FirstOrDefault();

                        var joinDesg = official.JoiningDesg?.DesignationName;
                        var presentDesg = official.PresentDesignation?.DesignationName;
                        var attachDesg = official.CrntDesg?.DesignationName;

                        emp.JoiningDesignation = joinDesg;
                        emp.JoiningDesignationId = official?.JoiningDesgId;
                        emp.PresentDesignation = presentDesg;
                        emp.PresentDesignationId = official?.PresentDesignationId;
                        emp.AttachDesignation = attachDesg;
                        emp.AttachDesignationId = official?.CrntDesgId;

                        mapped.Add(emp);
                    }

                    return (result.executionState, mapped, result.message);
                    //return (result.executionState, CastEntityToModel(result.organogramList), result.message);
                }
                return (result.executionState, null, result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
