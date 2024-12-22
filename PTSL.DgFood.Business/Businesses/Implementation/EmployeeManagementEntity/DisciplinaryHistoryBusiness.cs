using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation.EmployeeManagementEntity
{
    public class DisciplinaryHistoryBusiness : BaseBusiness<DisciplinaryHistory>, IDisciplinaryHistoryBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public DisciplinaryHistoryBusiness(DgFoodUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, DisciplinaryHistory entity, string message)> CreateAsync(DisciplinaryHistory entity)
        {
            (ExecutionState executionState, DisciplinaryHistory entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = _unitOfWork.Begin())
            {
                try
                {
                    (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecution entity, string message) updatedEntity = await _unitOfWork.GetAsync<DisciplinaryActionsAndCriminalProsecution>(entity.DisciplinaryAndCriminalId);
                    
                    if(updatedEntity.entity != null)
                    {
                        updatedEntity.entity.PresentStatusId = entity.PresentStatusId;
                        updatedEntity.entity.Description= entity.Description;
                        var Documents = new List<Document>();
                        foreach (var document in entity.Documents)
                        {
                            updatedEntity.entity.Document = document.Name;
                        }
                        await _unitOfWork.UpdateAsync(updatedEntity.entity);
                        await _unitOfWork.CreateAsync<DisciplinaryHistory>(entity);

                        (ExecutionState executionState, string message) saveResponse = await _unitOfWork.SaveAsync(transaction);
                        transaction.Commit();
                    } 
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Criminal action not found.");
                    }

                    updateResponse = (executionState: ExecutionState.Created, entity: null, message: $"Disciplinary history create successfully.");
                }
                catch (Exception)
                {

                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }
                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(DisciplinaryHistory).Name} update.");
                }
            }
            return updateResponse;
        }
    }
}