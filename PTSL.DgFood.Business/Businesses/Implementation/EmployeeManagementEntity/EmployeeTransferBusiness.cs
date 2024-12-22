using Microsoft.EntityFrameworkCore;
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
    public class EmployeeTransferBusiness : BaseBusiness<EmployeeTransfer>, IEmployeeTransferBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public EmployeeTransferBusiness(DgFoodUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message)> GetFilterData(QueryOptions<EmployeeTransfer> queryOptions, EmployeeTransferFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeTransfer>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message) entityObject = await _unitOfWork.List<EmployeeTransfer>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public override async Task<(ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message)> List(QueryOptions<EmployeeTransfer> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeTransfer>();
            queryOptions.FilterExpression = x => x.IfEmployeeContinuing == true;
            queryOptions.IncludeExpression = x => x.Include(i => i.EmployeeInformation).Include(y => y.Rank)
            .Include(a => a.Designation).Include(b => b.TransferFromDistrict).Include(c => c.TransferFromDivision)
            .Include(d => d.TransferToDistrict).Include(e => e.TransferToDivision).Include(e => e.PostingRecords);
            (ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message) entityObject = await _unitOfWork.List<EmployeeTransfer>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
    }
}
