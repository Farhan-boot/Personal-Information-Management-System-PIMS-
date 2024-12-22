using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class DisciplinaryActionsAndCriminalProsecutionBusiness : BaseBusiness<DisciplinaryActionsAndCriminalProsecution>, IDisciplinaryActionsAndCriminalProsecutionBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public DisciplinaryActionsAndCriminalProsecutionBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<(ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message) returnResponse;

            FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.PresentStatus).Include(x => x.Category).Include(x => x.DisciplinaryHistories).ThenInclude(x => x.Documents);
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);
            if (entityObject.entity != null)
            {
                returnResponse = entityObject;
            }
            else
            {
                returnResponse = entityObject;
            }


            return returnResponse;
        }
        public async Task<(ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message)> GetFilterData(QueryOptions<DisciplinaryActionsAndCriminalProsecution> queryOptions, DisciplinaryActionsAndCriminalProsecutionFilterVM entity)
        {
            (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<DisciplinaryActionsAndCriminalProsecution>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.Category).Include(x => x.PresentStatus);
            (ExecutionState executionState, IQueryable<DisciplinaryActionsAndCriminalProsecution> entity, string message) entityObject = await _unitOfWork.List<DisciplinaryActionsAndCriminalProsecution>(queryOptions);
            List<DisciplinaryActionsAndCriminalProsecutionListVM> entityData = new List<DisciplinaryActionsAndCriminalProsecutionListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    DisciplinaryActionsAndCriminalProsecutionListVM tempData = new DisciplinaryActionsAndCriminalProsecutionListVM();
                    tempData.Category = data.Category != null ? data.Category.CategoryName : "";
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.PresentStatus = data.PresentStatus != null ? data.PresentStatus.PresentStatusName : "";
                    tempData.Document = data.Document;
                    entityData.Add(tempData);
                }
            }
            returnResponse.entity = entityData;
            returnResponse.message = entityObject.message;
            returnResponse.executionState = entityObject.executionState;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IList<EmployeeInformationByDisciplinaryVM> entity, string message)> GetEmployeeByFilter(DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM model)
        {
            var disciplinaryQueryOptions = new QueryOptions<DisciplinaryActionsAndCriminalProsecution>();

            if (model.PresentStatusId != null)
                disciplinaryQueryOptions.FilterExpression = e => e.PresentStatusId == model.PresentStatusId;
            if (model.CategoryId != null)
                disciplinaryQueryOptions.FilterExpression = e => e.CategoryId == model.CategoryId;
            disciplinaryQueryOptions.IncludeExpression = e => e.Include(x => x.EmployeeInformation);

            var dbResult = await _unitOfWork.List(disciplinaryQueryOptions);

            var employeeList = new List<EmployeeInformationByDisciplinaryVM>();
            foreach (var disciplinaryAction in dbResult.entity)
            {
                var employee = new EmployeeInformationByDisciplinaryVM();
                var dbEmployee = disciplinaryAction.EmployeeInformation;

                employee.Id = dbEmployee.Id;
                employee.MobileNumber = dbEmployee.MobileNumber;
                employee.Email = dbEmployee.Email;
                employee.NationalID = dbEmployee.NationalID;
                employee.NameEnglish = dbEmployee.NameEnglish;
                employee.NameBangla = dbEmployee.NameBangla;

                // TODO: Fix the relation of OfficialInformation and EmployeeInformation
                //employee.DesignationName = dbEmployee.OfficialInformation
                employeeList.Add(employee);
            }

            return (ExecutionState.Success, employeeList, "Sucessfully loaded employee information.");
        }
        public override async Task<(ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message)> UpdateAsync(DisciplinaryActionsAndCriminalProsecution entity)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    if (entity != null)
                    {
                        FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
                        filterOptions.FilterExpression = x => x.Id == entity.Id && x.EmployeeInformationId == entity.EmployeeInformationId;
                        (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                        if (entityObject.executionState == ExecutionState.Success)
                        {
                            //IList<Document> document = new Document()
                            //{
                            //    Name = entity.Document
                            //};
                            IList<Document> documents= new List<Document>()
                            {
                                new Document()
                                {
                                    Name = entity.Document
                                }
                            };
                            DisciplinaryHistory history = new DisciplinaryHistory()
                            {
                                SubmissonDate = DateTime.Now,
                                Documents = documents,
                                DisciplinaryAndCriminalId = entity.Id,
                                Description= entity.Description,
                                PresentStatusId= entity.PresentStatusId ?? 0,
                            };
                            await _unitOfWork.UpdateAsync(history);
                            await _unitOfWork.SaveAsync(transaction);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(District).Name} update.");
                }
            }
            return await base.UpdateAsync(entity);
        }
        public override async Task<(ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message)> CreateAsync(DisciplinaryActionsAndCriminalProsecution entity)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message) updateResponse;
            await using (IDbContextTransaction transaction = _unitOfWork.Begin())
            {
                try
                {
                    if (entity != null)
                    {
                        IList<Document> documents = new List<Document>()
                        {
                            new Document()
                            {
                                Name = entity.Document
                            }
                        };
                        var history = new DisciplinaryHistory()
                        {
                            PresentStatusId = entity.PresentStatusId ?? 0,
                            Description = entity.Description,
                            Documents = documents,
                            SubmissonDate = entity.CreatedAt
                        };

                        entity.DisciplinaryHistories.Add(history);
                        await _unitOfWork.CreateAsync<DisciplinaryActionsAndCriminalProsecution>(entity);
                        (ExecutionState executionState, string message) saveResponse = await _unitOfWork.SaveAsync(transaction);
                        transaction.Commit();
                    }
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Criminal action not found.");
                    }

                    updateResponse = (executionState: ExecutionState.Created, entity: null, message: $"Disciplinary action create successfully.");
                }
                catch (Exception)
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }
                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(DisciplinaryActionsAndCriminalProsecution).Name} update.");
                }
            }
            return updateResponse;
        }
    }
}