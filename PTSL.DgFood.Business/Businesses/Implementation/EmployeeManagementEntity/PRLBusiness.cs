using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation.EmployeeManagementEntity
{
	public class PRLBusiness : BaseBusiness<PRL>, IPRLBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        private readonly DgFoodReadOnlyCtx _readOnlyCtx;
        private readonly DgFoodWriteOnlyCtx _writeOnlyCtx;
        public PRLBusiness(DgFoodUnitOfWork unitOfWork, DgFoodReadOnlyCtx readOnlyCtx, DgFoodWriteOnlyCtx writeOnlyCtx) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx= writeOnlyCtx;

        }
        public async Task<(ExecutionState executionState, IList<PRL> entity, string[] empsendingWay, string message)> CreateAsync(IList<PRL> entitys, string noticeType)
        {
            (ExecutionState executionState, IList<PRL> entitys, string[] empsendingWay, string message) updateResponse;
            await using (IDbContextTransaction transaction = _unitOfWork.Begin())
            {
                string[] toWay = null;
                var prlList = new List<PRL>();
                try
                {
                    var employeeIds = entitys.Select(x => x.EmployeeInformationId).ToList();

                    if (entitys != null)
                    {
                        var sendingWayList = await _readOnlyCtx.Set<EmployeeInformation>().Where(x => employeeIds.Contains(x.Id))
                                        .Select(x => noticeType == "E-Mail" ? x.Email : x.MobileNumber).ToListAsync();
                        if(sendingWayList != null)
                        {
                            for (int i=0; i< sendingWayList.Count; i++)
                            {
                                string[] sendingWay = sendingWayList[i].Split(',');

                                var containSpace = noticeType == "E-Mail" ? !Regex.IsMatch(sendingWay[0], @"^[^@\s]+@[^@\s]+\.[^@\s]+$") : false;
                                if (string.IsNullOrEmpty(sendingWay[0]) || string.IsNullOrWhiteSpace(sendingWay[0]) || containSpace || noticeType == "E-Mail" ? !sendingWay[0].Contains(".com") : false)
                                {
                                    continue;
                                }
                                else if (toWay == null)
                                {
                                    toWay = sendingWay;
                                }
                                else
                                {
                                    int length = toWay.Length + sendingWay.Length;
                                    string[] newsendingWay = new string[length];
                                    Array.Copy(toWay, 0, newsendingWay, 0, toWay.Length);
                                    Array.Copy(sendingWay, 0, newsendingWay, toWay.Length, sendingWay.Length);
                                    toWay = newsendingWay;
                                }

                                var prl = new PRL()
                                {
                                    CreatedBy = entitys[i].CreatedBy,
                                    MessageSubject = entitys[i].MessageSubject,
                                    MessageBody = entitys[i].MessageBody,
                                    EmployeeInformationId = entitys[i].EmployeeInformationId,
                                    IsEmail = entitys[i].IsEmail,
                                    IsSMS = entitys[i].IsSMS,
                                    NoticeBy = entitys[i].NoticeBy,
                                    NoticeDate = entitys[i].NoticeDate,
                                };
                                prlList.Add(prl);
                            }

                            await _writeOnlyCtx.Set<PRL>().AddRangeAsync(prlList);
                            await _writeOnlyCtx.SaveChangesAsync();
                            transaction.Commit();
                        }
                        else
                        {
                            updateResponse = (executionState: ExecutionState.Failure, entitys: prlList,empsendingWay: null, message: noticeType == "E-Mail" ? $"Email not founds." : $"Mobile number not founds");
                        }
                    }
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entitys: null, empsendingWay: null, message: $"PRL not found.");
                    }

                    updateResponse = (executionState: ExecutionState.Created, entitys: prlList, empsendingWay: toWay, message: $"PRL create successfully.");
                }
                catch (Exception)
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }
                    updateResponse = (executionState: ExecutionState.Failure,entitys: prlList, empsendingWay: null, message: $"Problem on {typeof(PRL).Name}.");
                }
            }
            return updateResponse;
        }
        public override async Task<(ExecutionState executionState, PRL entity, string message)> GetAsync(long key)
        {
            (ExecutionState executionState, PRL entity, string message) retunResponse;
            await using (IDbContextTransaction transaction = _unitOfWork.Begin())
            {
                try
                {
                    var prlQueryOptions = new QueryOptions<EmployeeInformation>();
                    if (key != 0)
                        prlQueryOptions.FilterExpression = e => e.Id == key;
                    var dbResult = await _unitOfWork.List(prlQueryOptions);
                    var prl = new PRL();
                    foreach (var result in dbResult.entity)
                    {
                        prl.EmployeeInformation = new EmployeeInformation
                        {
                            Email = result.Email,
                        };
                    }
                    retunResponse = (ExecutionState.Success, prl, "Sucessfully loaded employee information.");
                }
                catch (Exception)
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }
                    retunResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(PRL).Name} update.");
                }
            }
            return retunResponse;
        }

        public async Task<(ExecutionState executionState, IList<OfficialInformation> entity, string message)> List()
        {
            (ExecutionState executionState, IList<OfficialInformation> prlList, string message) returnPRlList;

            var currentDate = DateTime.Now;
            var endDate = currentDate.AddDays(-90.0);

            var prlList = _readOnlyCtx.Set<OfficialInformation>()
                                      .Where(x => x.PRLDate >= endDate && x.PRLDate < currentDate)
                                      .Include(x => x.EmployeeInformation)
                                      .OrderBy(x => x.EmployeeInformationId)
                                      .ToList();

            returnPRlList = (executionState: ExecutionState.Success, prlList, message:"PRL list get successfully");

            return returnPRlList;
        }
    }
}