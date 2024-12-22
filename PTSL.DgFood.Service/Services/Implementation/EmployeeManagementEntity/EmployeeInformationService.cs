using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Business;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Business.Businesses.Implementation;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System.Data;
using System.Data.SqlClient;
using ProcedureCollection;

namespace PTSL.DgFood.Service.Services
{
    public class EmployeeInformationService : BaseService<EmployeeInformationVM, EmployeeInformation>, IEmployeeInformationService
    {
        public readonly IEmployeeInformationBusiness _EmployeeInformationBusiness;
        public IMapper _mapper;
        //public readonly IStoredProcedureCollection _StoredProcedureCollection;
        public readonly StoredProcedureCollection _StoredProcedureCollection;
        public EmployeeInformationService(IEmployeeInformationBusiness EmployeeInformationBusiness, IMapper mapper) : base(EmployeeInformationBusiness)
        {
            _EmployeeInformationBusiness = EmployeeInformationBusiness;
            _mapper = mapper;
            _StoredProcedureCollection = new StoredProcedureCollection();
            // _StoredProcedureCollection = spc;
        }

        //Implement System Busniess Logic here

        public virtual async Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetFilterData(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                    //returnResponse = (executionState: Getentity.executionState, entity: CastEmpEntityToEmpListData(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public virtual async Task<(ExecutionState executionState, EmployeeInformationVM entity, string message)> GetEmployeeFullInfoById(long? id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeeInformation entity, string message) Getentity = await _EmployeeInformationBusiness.GetEmployeeFullInfoById(id);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        public virtual async Task<(ExecutionState executionState, EmployeeInformationListVM entity, string message)> GetEmployeeBasicInfoByEmployeeCode(string EmployeeCode)
        {
            (ExecutionState executionState, EmployeeInformationListVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeeInformation entity, string message) Getentity = await _EmployeeInformationBusiness.GetEmployeeBasicInfoByEmployeeCode(EmployeeCode);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEmpEntityToEmpData(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(FilterOptions<EmployeeInformationVM> filterOptions)
        {
            (ExecutionState executionState, string message) returnResponse = await _EmployeeInformationBusiness.DoesExistAsync(1);
            returnResponse.executionState = ExecutionState.Activated;
            returnResponse.message = "";
            return returnResponse;
        }
        //public override async Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> List(QueryOptions<EmployeeInformationVM> queryOptions = null)
        //{
        //    (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) returnResponse;
        //    try
        //    {
        //        QueryOptions<EmployeeInformation> queryOptions2 = new QueryOptions<EmployeeInformation>();
        //        (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.List(queryOptions2);

        //        if (Getentity.executionState == ExecutionState.Retrieved)
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModelList(Getentity.entity), message: Getentity.message);
        //        }
        //        else
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
        //    }

        //    return returnResponse;
        //}
        public virtual async Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> EmployeeList(QueryOptions<EmployeeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                //QueryOptions<EmployeeInformation> queryOptions2 = new QueryOptions<EmployeeInformation>();
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.EmployeeList(queryOptions);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEmpEntityToEmpList(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> List(QueryOptions<EmployeeInformationVM> queryOptions = null)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            //(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) returnResponse2;
            try
            {
                queryOptions = new QueryOptions<EmployeeInformationVM>();
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.List(null);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    List<EmployeeInformationVM> employeeData = new List<EmployeeInformationVM>();
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }


            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeList(QueryOptions<EmployeeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.GetEmployeeList(queryOptions);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeByEmail(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.GetEmployeeByEmail(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeByEmailWithAllIncluding(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) Getentity = await _EmployeeInformationBusiness.GetEmployeeByEmailWithAllIncluding(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        //public async Task<(ExecutionState executionState, string message)> UpdateExistingEmployeeData()
        //{
        //    (ExecutionState executionState,  string message) returnResponse;
        //    try
        //    {
        //        (ExecutionState executionState, string message) Getentity = await _EmployeeInformationBusiness.UpdateExistingEmployeeData();

        //        if (Getentity.executionState == ExecutionState.Retrieved)
        //        {
        //            returnResponse = (executionState: Getentity.executionState, message: Getentity.message);
        //        }
        //        else
        //        {
        //            returnResponse = (executionState: Getentity.executionState, message: Getentity.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure,  message: ex.Message);
        //    }

        //    return returnResponse;
        //}

        public override EmployeeInformation CastModelToEntity(EmployeeInformationVM model)
        {
            try
            {
                return _mapper.Map<EmployeeInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override EmployeeInformationVM CastEntityToModel(EmployeeInformation entity)
        {
            try
            {
                EmployeeInformationVM model = _mapper.Map<EmployeeInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<EmployeeInformationVM> CastEntityToModel(IQueryable<EmployeeInformation> entity)
        {
            try
            {
                //IQueryable<EmployeeInformationVM> EmployeeInformationList = _mapper.Map<IQueryable<EmployeeInformationVM>>(entity).ToList();
                IList<EmployeeInformationVM> EmployeeInformationList = _mapper.Map<IList<EmployeeInformationVM>>(entity).ToList();
                return EmployeeInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<EmployeeInformationListVM> CastEntityToModelList(IQueryable<EmployeeInformation> entity)
        {
            try
            {
                //IQueryable<EmployeeInformationVM> EmployeeInformationList = _mapper.Map<IQueryable<EmployeeInformationVM>>(entity).ToList();
                IList<EmployeeInformationListVM> EmployeeInformationList = _mapper.Map<IList<EmployeeInformationListVM>>(entity).ToList();
                return EmployeeInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmployeeInformationListVM CastEmpEntityToEmpData(EmployeeInformation entity)
        {
            EmployeeInformationListVM employeeData = new EmployeeInformationListVM();
            var data = entity;

            EmployeeInformationListVM tempData = new EmployeeInformationListVM();
            tempData.Id = data.Id;
            tempData.NameEnglish = data.NameEnglish;
            tempData.DateOfBirth = data.DateOfBirth;
            tempData.MobileNumber = data.MobileNumber;
            tempData.Email = data.Email;
            tempData.GovtID = data.GovtID;
            tempData.NationalID = data.NationalID;


            tempData.MobileNumber = data.MobileNumber;
            tempData.NameBangla = data.NameBangla;
            tempData.NameEnglish = data.NameEnglish;

            tempData.FathersNameBangla = data.FathersNameBangla;
            tempData.FathersNameEnglish = data.FathersNameEnglish;
            tempData.MothersNameBangla = data.MothersNameBangla;
            tempData.MothersNameEnglish = data.MothersNameEnglish;

            tempData.OtherReligion = data.OtherReligion;
            tempData.BloodGroup = data.BloodGroup.ToString();
            // tempData.RecruitmentType = data.RecruitmentType.ToString();

            tempData.Gender = data.GenderId.ToString() == "1" ? data.GenderId.ToString() == "2" ? "Female" : "Other" : "Other";
            tempData.TIN = data.TIN;
            tempData.PassportNumber = data.PassportNumber;
            tempData.PassportIssueDate = data.PassportIssueDate;
            tempData.PassportIssuePlace = data.PassportIssuePlace;
            tempData.PassportDateOfExpire = data.PassportDateOfExpire;
            tempData.DrivingLicenceNo = data.DrivingLicenceNo;
            tempData.CircularDate = data.CircularDate;
            tempData.BCSNo = data.BCSNo;
            tempData.MeritOrder = data.MeritOrder;
            tempData.EmployeeCode = data.EmployeeCode;
            string Designation = "";
            string ByPromo = "";
            string OriginalPosting = "";
            DateTime promotionDate = new DateTime();
            var PromotionDesignation = data.PromotionPartculars.OrderByDescending(x => x.Id);
            if (PromotionDesignation != null && PromotionDesignation.Count() > 0)
            {
                if (PromotionDesignation.FirstOrDefault().Designation != null)
                {
                    promotionDate = (DateTime)PromotionDesignation.FirstOrDefault().PromotionDate;
                    Designation = PromotionDesignation.FirstOrDefault().Designation.DesignationName;
                }
            }
            var PostingDesignation = data.PostingRecords.OrderByDescending(x => x.Id);
            if (PostingDesignation != null && PostingDesignation.Count() > 0)
            {
                if (PostingDesignation.FirstOrDefault().Designation != null)
                {
                    if (promotionDate < PostingDesignation.FirstOrDefault().PeriodFrom)
                    {
                        Designation = PostingDesignation.FirstOrDefault().Designation.DesignationName;
                    }
                }
            }
            var designationData = data.OfficialInformation.OrderByDescending(x => x.Id);

            if (designationData != null && designationData.Count() > 0)
            {
                if (Designation == "" && designationData.FirstOrDefault().PresentDesignation != null)
                {
                    Designation = designationData.FirstOrDefault().PresentDesignation.DesignationName;
                }
                ByPromo = designationData.FirstOrDefault().RecruitPromoId != 0 ? designationData.FirstOrDefault().RecruitPromo.RecruitPromoEnglish : "";
                OriginalPosting = designationData.FirstOrDefault().Posting.PostingName;
            }

            tempData.DesignationName = Designation;
            //tempData.ByPromo = ByPromo;

            string Grade = "";
            var PromotionGrade = data.PromotionPartculars.OrderByDescending(x => x.Id);
            if (PromotionGrade != null && PromotionGrade.Count() > 0)
            {
                Grade = PromotionGrade.FirstOrDefault().Rank.RankName;
            }
            var PostingGrade = data.PostingRecords.OrderByDescending(x => x.Id);
            if (PostingGrade != null && PostingGrade.Count() > 0)
            {
                if (PostingGrade.FirstOrDefault().Designation != null)
                {
                    if (promotionDate < PostingGrade.FirstOrDefault().PeriodFrom)
                    {
                        Grade = PostingGrade.FirstOrDefault().Rank.RankName;
                    }
                }
            }
            var gradeData = data.OfficialInformation.OrderByDescending(x => x.Id);

            if (gradeData != null && gradeData.Count() > 0 && Grade == "" && gradeData.FirstOrDefault().PresentRank != null)
            {
                Grade = gradeData.FirstOrDefault().PresentRank.RankName;
            }
            //tempData.Grade = Grade;
            //tempData.OriginalPosting = OriginalPosting;

            employeeData = tempData;

            return employeeData;
        }
        public List<EmployeeInformationListVM> CastEmpEntityToEmpList(IQueryable<EmployeeInformation> entity)
        {
            List<EmployeeInformationListVM> employeeData = new List<EmployeeInformationListVM>();
            foreach (var data in entity.ToList())
            {
                EmployeeInformationListVM tempData = new EmployeeInformationListVM();
                tempData.Id = data.Id;
                tempData.NameEnglish = data.NameEnglish;
                tempData.DateOfBirth = data.DateOfBirth;
                tempData.MobileNumber = data.MobileNumber;
                tempData.Email = data.Email;
                tempData.GovtID = data.GovtID;
                tempData.NationalID = data.NationalID;


                tempData.MobileNumber = data.MobileNumber;
                tempData.NameBangla = data.NameBangla;
                tempData.NameEnglish = data.NameEnglish;

                tempData.FathersNameBangla = data.FathersNameBangla;
                tempData.FathersNameEnglish = data.FathersNameEnglish;
                tempData.MothersNameBangla = data.MothersNameBangla;
                tempData.MothersNameEnglish = data.MothersNameEnglish;

                tempData.OtherReligion = data.OtherReligion;
                tempData.BloodGroup = data.BloodGroup.ToString();
                // tempData.RecruitmentType =  data.RecruitmentType.ToString();

                tempData.Gender = data.GenderId.ToString() == "1" ? data.GenderId.ToString() == "2" ? "Female" : "Other" : "Other";
                tempData.TIN = data.TIN;
                tempData.PassportNumber = data.PassportNumber;
                tempData.PassportIssueDate = data.PassportIssueDate;
                tempData.PassportIssuePlace = data.PassportIssuePlace;
                tempData.PassportDateOfExpire = data.PassportDateOfExpire;
                tempData.DrivingLicenceNo = data.DrivingLicenceNo;
                tempData.CircularDate = data.CircularDate;
                tempData.BCSNo = data.BCSNo;
                tempData.MeritOrder = data.MeritOrder;
                tempData.EmployeeCode = data.EmployeeCode;

                //EmployeeInformationListVM tempData = new EmployeeInformationListVM();
                //tempData.Id = data.Id;
                //tempData.NameEnglish = data.NameEnglish;
                //tempData.DateOfBirth = data.DateOfBirth;
                //tempData.MobileNumber = data.MobileNumber;
                //tempData.Email = data.Email;
                string Designation = "";
                string ByPromo = "";
                string OriginalPosting = "";
                DateTime promotionDate = new DateTime();
                var PromotionDesignation = data.PromotionPartculars.OrderByDescending(x => x.Id);
                if (PromotionDesignation != null && PromotionDesignation.Count() > 0)
                {
                    if (PromotionDesignation.FirstOrDefault().Designation != null)
                    {
                        promotionDate = (DateTime)PromotionDesignation.FirstOrDefault().PromotionDate;
                        Designation = PromotionDesignation.FirstOrDefault().Designation.DesignationName;
                    }
                }
                var PostingDesignation = data.PostingRecords.OrderByDescending(x => x.Id);
                if (PostingDesignation != null && PostingDesignation.Count() > 0)
                {
                    if (PostingDesignation.FirstOrDefault().Designation != null)
                    {
                        if (promotionDate < PostingDesignation.FirstOrDefault().PeriodFrom)
                        {
                            Designation = PostingDesignation.FirstOrDefault().Designation.DesignationName;
                        }
                    }
                }
                var designationData = data.OfficialInformation.OrderByDescending(x => x.Id);

                if (designationData != null && designationData.Count() > 0)
                {
                    if (Designation == "" && designationData.FirstOrDefault().PresentDesignation != null)
                    {
                        Designation = designationData.FirstOrDefault().PresentDesignation.DesignationName;
                    }
                    ByPromo = designationData.FirstOrDefault().RecruitPromoId != 0 ? designationData.FirstOrDefault().RecruitPromo.RecruitPromoEnglish : "";
                    OriginalPosting = designationData.FirstOrDefault().Posting.PostingName;
                }

                tempData.DesignationName = Designation;
                //tempData.ByPromo = ByPromo;

                string Grade = "";
                var PromotionGrade = data.PromotionPartculars.OrderByDescending(x => x.Id);
                if (PromotionGrade != null && PromotionGrade.Count() > 0)
                {
                    Grade = PromotionGrade.FirstOrDefault().Rank.RankName;
                }
                var PostingGrade = data.PostingRecords.OrderByDescending(x => x.Id);
                if (PostingGrade != null && PostingGrade.Count() > 0)
                {
                    if (PostingGrade.FirstOrDefault().Designation != null)
                    {
                        if (promotionDate < PostingGrade.FirstOrDefault().PeriodFrom)
                        {
                            Grade = PostingGrade.FirstOrDefault().Rank.RankName;
                        }
                    }
                }
                var gradeData = data.OfficialInformation.OrderByDescending(x => x.Id);

                if (gradeData != null && gradeData.Count() > 0 && Grade == "" && gradeData.FirstOrDefault().PresentRank != null)
                {
                    Grade = gradeData.FirstOrDefault().PresentRank.RankName;
                }
                //tempData.Grade = Grade;
                //tempData.OriginalPosting = OriginalPosting;

                employeeData.Add(tempData);
            }

            return employeeData;
        }

        public List<EmployeeInformationListVM> CastEmpEntityToEmpListData(IQueryable<EmployeeInformation> entity)
        {
            List<EmployeeInformationListVM> employeeData = new List<EmployeeInformationListVM>();
            foreach (var data in entity.ToList())
            {
                EmployeeInformationListVM tempData = new EmployeeInformationListVM();
                tempData.Id = data.Id;
                tempData.NameEnglish = data.NameEnglish;
                tempData.DateOfBirth = data.DateOfBirth;
                tempData.MobileNumber = data.MobileNumber;
                tempData.Email = data.Email;
                string Designation = "";
                string ByPromo = "";
                string OriginalPosting = "";
                DateTime promotionDate = new DateTime();
                var PromotionDesignation = data.PromotionPartculars.OrderByDescending(x => x.Id);
                if (PromotionDesignation != null && PromotionDesignation.Count() > 0)
                {
                    if (PromotionDesignation.FirstOrDefault().Designation != null)
                    {
                        promotionDate = (DateTime)PromotionDesignation.FirstOrDefault().PromotionDate;
                        Designation = PromotionDesignation.FirstOrDefault().Designation.DesignationName;
                    }
                }
                var PostingDesignation = data.PostingRecords.OrderByDescending(x => x.Id);
                if (PostingDesignation != null && PostingDesignation.Count() > 0)
                {
                    if (PostingDesignation.FirstOrDefault().Designation != null)
                    {
                        if (promotionDate < PostingDesignation.FirstOrDefault().PeriodFrom)
                        {
                            Designation = PostingDesignation.FirstOrDefault().Designation.DesignationName;
                        }
                    }
                }
                var designationData = data.OfficialInformation.OrderByDescending(x => x.Id);

                if (designationData != null && designationData.Count() > 0)
                {
                    if (Designation == "" && designationData.FirstOrDefault().PresentDesignation != null)
                    {
                        Designation = designationData.FirstOrDefault().PresentDesignation.DesignationName;
                    }
                    ByPromo = designationData.FirstOrDefault().RecruitPromoId != 0 ? designationData.FirstOrDefault().RecruitPromo.RecruitPromoEnglish : "";

                    OriginalPosting = designationData.FirstOrDefault().Posting.PostingName;
                }

                tempData.DesignationName = Designation;
                //tempData.ByPromo = ByPromo;

                string Grade = "";
                var PromotionGrade = data.PromotionPartculars.OrderByDescending(x => x.Id);
                if (PromotionGrade != null && PromotionGrade.Count() > 0)
                {
                    Grade = PromotionGrade.FirstOrDefault().Rank.RankName;
                }
                var PostingGrade = data.PostingRecords.OrderByDescending(x => x.Id);
                if (PostingGrade != null && PostingGrade.Count() > 0)
                {
                    if (PostingGrade.FirstOrDefault().Designation != null)
                    {
                        if (promotionDate < PostingGrade.FirstOrDefault().PeriodFrom)
                        {
                            Grade = PostingGrade.FirstOrDefault().Rank.RankName;
                        }
                    }
                }
                var gradeData = data.OfficialInformation.OrderByDescending(x => x.Id);

                if (gradeData != null && gradeData.Count() > 0 && Grade == "" && gradeData.FirstOrDefault().PresentRank != null)
                {
                    Grade = gradeData.FirstOrDefault().PresentRank.RankName;
                }
                //tempData.Grade = Grade;
                //tempData.OriginalPosting = OriginalPosting;

                employeeData.Add(tempData);
            }

            return employeeData;
        }

        public async Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> EmployeeListBySP(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity, string ConnectionString)
        {
            (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                (bool success, DataTable entity, string Message) responseSpData;

                List<SqlParameter> parameters = new List<SqlParameter>
                    {
                    new SqlParameter() {ParameterName = "@RankId", SqlDbType = SqlDbType.BigInt, Value= entity.RankId != null ? (long)entity.RankId : 0},
                    new SqlParameter() {ParameterName = "@DesignationId", SqlDbType = SqlDbType.BigInt,Value = entity.DesignationId != null ? (long)entity.DesignationId : 0},
                    new SqlParameter() {ParameterName = "@PostingTypeId", SqlDbType = SqlDbType.BigInt, Value = entity.PostingTypeId != null ? (long)entity.PostingTypeId : 0},
                    new SqlParameter() {ParameterName = "@PostingId", SqlDbType = SqlDbType.BigInt,Value= entity.PostingId != null ? (long)entity.PostingId : 0},
                    new SqlParameter() {ParameterName = "@DivisionId", SqlDbType = SqlDbType.BigInt, Value = entity.DivisionId != null ? (long)entity.DivisionId : 0},
                    new SqlParameter() {ParameterName = "@DistrictId", SqlDbType = SqlDbType.BigInt, Value = entity.DistrictId != null ? (long)entity.DistrictId : 0},
                    new SqlParameter() {ParameterName = "@PoliceStationId", SqlDbType = SqlDbType.BigInt, Value = entity.PoliceStationId != null ? (long)entity.PoliceStationId : 0},
                    new SqlParameter() {ParameterName = "@EmployeeInformationId", SqlDbType = SqlDbType.BigInt, Value = entity.Id != null ? (long)entity.Id : 0},

                    new SqlParameter() {ParameterName = "@PageIndex", SqlDbType = SqlDbType.Int, Value = entity.PageIndex == 0 ? 1 : entity.PageIndex},
                    new SqlParameter() {ParameterName = "@PageSize", SqlDbType = SqlDbType.Int, Value = entity.PageSize},
                    new SqlParameter() {ParameterName = "@RecordCount", SqlDbType = SqlDbType.Int, Value = entity.RecordCount},

                    new SqlParameter() {ParameterName = "@NameEnglish", SqlDbType = SqlDbType.NVarChar, Value = entity.NameEnglish},
                    new SqlParameter() {ParameterName = "@Designation", SqlDbType = SqlDbType.NVarChar, Value = entity.Designation},
                    new SqlParameter() {ParameterName = "@Grade", SqlDbType = SqlDbType.NVarChar, Value = entity.Grade},
                    new SqlParameter() {ParameterName = "@PromoRecruit", SqlDbType = SqlDbType.NVarChar, Value = entity.PromoRecruit},
                    new SqlParameter() {ParameterName = "@PostingPlace", SqlDbType = SqlDbType.NVarChar, Value = entity.PostingPlace},
                    new SqlParameter() {ParameterName = "@MobileNo", SqlDbType = SqlDbType.NVarChar, Value = entity.MobileNumber},
                    new SqlParameter() {ParameterName = "@FirstJoiningDate", SqlDbType = SqlDbType.DateTime2, Value = entity.FirstJoiningDate},
                    new SqlParameter() {ParameterName = "@PRLFromDate", SqlDbType = SqlDbType.DateTime2, Value = entity.PRLFromDate},
                    new SqlParameter() {ParameterName = "@PRLToDate", SqlDbType = SqlDbType.DateTime2, Value = entity.PRLToDate},
                    new SqlParameter() {ParameterName = "@GradationTypeId", SqlDbType = SqlDbType.BigInt, Value = entity.GradationTypeId},
                    new SqlParameter() {ParameterName = "@BloodGroup", SqlDbType = SqlDbType.NVarChar, Value = entity.BloodGroup},
                    new SqlParameter() {ParameterName = "@ReturnAllRow", SqlDbType = SqlDbType.Bit, Value = entity.ReturnAllRow},
                    };
                responseSpData = _StoredProcedureCollection.GetProcedureData("EmployeeDetailsInformation_4", parameters, ConnectionString);

                if (responseSpData.success == true)
                {
                    //returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                    returnResponse = (executionState: ExecutionState.Retrieved, entity: CastEmployeeListoModel(responseSpData.entity), message: responseSpData.Message);
                }
                else
                {
                    returnResponse = (executionState: ExecutionState.Failure, entity: null, message: responseSpData.Message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public static List<EmployeeInformationListVM> CastEmployeeListoModel(DataTable table)
        {
            List<EmployeeInformationListVM> data = new List<EmployeeInformationListVM>();

            try
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        EmployeeInformationListVM model = new EmployeeInformationListVM();
                        model.Id = Convert.ToInt64(row["Id"].ToString());
                        model.GovtID = row["GovtID"].ToString();
                        model.NationalID = row["NationalID"].ToString();
                        model.MobileNumber = row["MobileNumber"].ToString();
                        model.Email = row["Email"].ToString();
                        model.NameBangla = row["NameBangla"].ToString();
                        model.NameEnglish = row["NameEnglish"].ToString();
                        model.DivisionId = row["DivisionId"] != DBNull.Value ? Convert.ToInt64(row["DivisionId"].ToString()) : 0;
                        model.DistrictId = row["DistrictId"] != DBNull.Value ? Convert.ToInt64(row["DistrictId"].ToString()) : 0;
                        model.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"].ToString());
                        model.FathersNameBangla = row["FathersNameBangla"].ToString();
                        model.FathersNameEnglish = row["FathersNameEnglish"].ToString();
                        model.MothersNameBangla = row["MothersNameBangla"].ToString();
                        model.MothersNameEnglish = row["MothersNameEnglish"].ToString();
                        model.oclsd = row["oclsd"].ToString();
                        model.EmployeeStatusId = Convert.ToInt64(row["EmployeeStatusId"].ToString());
                        model.OtherReligion = row["OtherReligion"].ToString();
                        model.FreedomFighter = Convert.ToBoolean(row["FreedomFighter"].ToString());
                        model.ChildGrandChildOfFreedomFighter = Convert.ToBoolean(row["ChildGrandChildOfFreedomFighter"].ToString());
                        model.BloodGroup = row["BloodGroup"].ToString();
                        model.RecruitmentType = row["RecruitmentType"] != DBNull.Value ? Convert.ToInt32(row["RecruitmentType"].ToString()) : 0;
                        model.GenderId = Convert.ToInt64(row["GenderId"].ToString());
                        model.MaritalStatusId = Convert.ToInt64(row["MaritalStatusId"].ToString());
                        model.ReligionId = row["ReligionId"] != DBNull.Value ? Convert.ToInt32(row["ReligionId"].ToString()) : 0;
                        model.TIN = row["TIN"].ToString();
                        model.NumberOfChildren = row["NumberOfChildren"] != DBNull.Value ? Convert.ToInt32(row["NumberOfChildren"].ToString()) : 0;
                        model.PassportNumber = row["PassportNumber"].ToString();
                        model.PassportIssueDate = row["PassportIssueDate"].ToString() != "" ? Convert.ToDateTime(row["PassportIssueDate"].ToString()) : (DateTime?)null;
                        model.PassportIssuePlace = row["PassportIssuePlace"].ToString();
                        model.PassportDateOfExpire = row["PassportDateOfExpire"].ToString() != "" ? Convert.ToDateTime(row["PassportDateOfExpire"].ToString()) : (DateTime?)null;
                        model.DrivingLicenceNo = row["DrivingLicenceNo"].ToString();
                        model.CircularDate = row["CircularDate"].ToString() != "" ? Convert.ToDateTime(row["CircularDate"].ToString()) : (DateTime?)null;
                        model.BCSNo = row["BCSNo"].ToString();
                        model.MeritOrder = row["MeritOrder"].ToString();
                        model.PoliceStationId = row["PoliceStationId"] != DBNull.Value ? Convert.ToInt64(row["PoliceStationId"].ToString()) : 0;
                        model.EmployeeCode = row["EmployeeCode"].ToString();
                        model.RankId = row["RankId"] != DBNull.Value ? Convert.ToInt64(row["RankId"].ToString()) : 0;
                        model.DesignationId = row["DesignationId"] != DBNull.Value ? Convert.ToInt64(row["DesignationId"].ToString()) : 0;
                        model.RankName = row["RankName"].ToString();
                        model.DesignationName = row["DesignationName"].ToString();
                        model.DivisionName = row["DivisionName"].ToString();
                        model.DistrictName = row["DistrictName"].ToString();
                        model.PoliceStationName = row["PoliceStationName"].ToString();
                        model.RecruitPromo = row["RecruitPromo"].ToString();
                        model.PostingTypeId = row["PostingTypeId"] != DBNull.Value ? Convert.ToInt64(row["PostingTypeId"].ToString()) : 0;
                        model.PostingType = row["PostingType"].ToString();
                        model.PostingPlaceId = row["PostingPlaceId"] != DBNull.Value ? Convert.ToInt64(row["PostingPlaceId"].ToString()) : 0;
                        model.PostingPlace = row["PostingPlace"].ToString();
                        model.FirstJoiningDate = row["FirstJoiningDate"].ToString() != "" ? Convert.ToDateTime(row["FirstJoiningDate"].ToString()) : (DateTime?)null;
                        model.PRLDate = row["PRLDate"].ToString() != "" ? Convert.ToDateTime(row["PRLDate"].ToString()) : (DateTime?)null;
                        model.EmployeeStatusName = row["EmployeeStatusName"].ToString();
                        model.RecruitmentTypeName = row["RecruitmentTypeName"].ToString();
                        model.Gender = row["Gender"].ToString();
                        model.MaritalStatusName = row["MaritalStatusName"].ToString();
                        model.ReligionName = row["ReligionName"].ToString();
                        model.PostingFromDate = row["PostingFromDate"].ToString() != "" ? Convert.ToDateTime(row["PostingFromDate"].ToString()) : (DateTime?)null;
                        model.PostingToDate = row["PostingToDate"].ToString() != "" ? Convert.ToDateTime(row["PostingToDate"].ToString()) : (DateTime?)null;
                        model.PromotionDate = row["PromotionDate"].ToString() != "" ? Convert.ToDateTime(row["PromotionDate"].ToString()) : (DateTime?)null;
                        model.AttachmentPosting = row["AttachmentPosting"].ToString();
                        model.TotalRowCount = row["TotalRowCount"] != DBNull.Value ? Convert.ToInt32(row["TotalRowCount"].ToString()) : 0;
                        model.GradationTypeName = row["GradationTypeName"].ToString();
                        model.HasUser = row["HasUser"].ToString() == "True";
                        data.Add(model);
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return data;

        }

    }
}
