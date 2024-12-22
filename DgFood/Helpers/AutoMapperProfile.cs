using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Helpers
{ 
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var currentDate = DateTime.Now;

            //general setup
            base.CreateMap<Category, CategoryVM>().ReverseMap();
            base.CreateMap<EmployeeInformationCount, EmployeeInformationCountVM>().ReverseMap();
            base.CreateMap<Degree, DegreeVM>().ReverseMap();
            base.CreateMap<Designation, DesignationVM>()
                .ForMember(x => x.DesignationClassDTO, y => y.MapFrom(z => z.DesignationClasses)).ReverseMap();
            base.CreateMap<DesignationClass, DesignationClassVM>()
                .ForMember(x => x.DesignationList, y => y.MapFrom(z => z.Designations)).ReverseMap();
            base.CreateMap<Upazilla, UpazillaVM>()
                .ForMember(x => x.DistrictVM, y => y.MapFrom(z => z.District)).ReverseMap();
            base.CreateMap<District, DistrictVM>()
                .ForMember(x => x.DivisionDTO, y => y.MapFrom(z => z.Division))
                .ForMember(x => x.PoliceStationList, y => y.MapFrom(z => z.PoliceStations))
                .ForMember(x => x.UpazillaList, y => y.MapFrom(z => z.Upazillas)).ReverseMap();
            base.CreateMap<Division, DivisionVM>()
                .ForMember(x => x.DistrictList, y => y.MapFrom(z => z.Districts)).ReverseMap();
            base.CreateMap<EmployeeStatus, EmployeeStatusVM>().ReverseMap();
            base.CreateMap<PoliceStation, PoliceStationVM>()
                .ForMember(x => x.DistrictDTO, y => y.MapFrom(z => z.District)).ReverseMap();
            base.CreateMap<PostingType, PostingTypeVM>()
                .ForMember(x => x.PostingList, y => y.MapFrom(z => z.Postings)).ReverseMap();
            base.CreateMap<Posting, PostingVM>()
                .ForMember(x => x.PostingTypeDTO, y => y.MapFrom(z => z.PostingType)).ReverseMap();
            base.CreateMap<PostResponsibility, PostResponsibilityVM>().ReverseMap();
            base.CreateMap<PresentStatus, PresentStatusVM>().ReverseMap();
            base.CreateMap<PromtionNature, PromtionNatureVM>().ReverseMap();
            
            base.CreateMap<Rank, RankVM>()
                .ForMember(x => x.DesignationList, y => y.MapFrom(z => z.Designations))
                .ForMember(x => x.PromotionPartcularList, y => y.Ignore())
                .ForMember(x => x.PostingRecordList, y => y.Ignore())
                .ForMember(x => x.PresentPostingDetailList, y => y.Ignore())
                .ForMember(x => x.JoiningPostingDetailList, y => y.Ignore())
                .ReverseMap();
            base.CreateMap<Years, YearsVM>().ReverseMap();
            base.CreateMap<EmployeeType, EmployeeTypeVM>().ReverseMap();
            base.CreateMap<GradationType, GradationTypeVM>().ReverseMap();
            base.CreateMap<JobCategory, JobCategoryVM>().ReverseMap();
            base.CreateMap<Language, LanguageVM>().ReverseMap();
            base.CreateMap<PayScaleYearInfo, PayScaleYearInfoVM>().ReverseMap();
            base.CreateMap<WeeklyHolydaySetup, WeeklyHolydaySetupVM>()
                .ForMember(x => x.YearDTO, y => y.MapFrom(z => z.Years)).ReverseMap();
            base.CreateMap<SpecialHolydaySetup, SpecialHolydaySetupVM>().ReverseMap();

            base.CreateMap<CalculationMethod, CalculationMethodVM>().ReverseMap();
            base.CreateMap<LeaveTypeInformation, LeaveTypeInformationVM>()
                .ForMember(x => x.CalculationMethodDTO, y => y.MapFrom(z => z.CalculationMethod)).ReverseMap();

            base.CreateMap<TrainingManagementType, TrainingManagementTypeVM>()
                .ForMember(x => x.TrainingManagementTypeStatusEnum, y => y.MapFrom(z => 
					currentDate <= z.ToDate && currentDate >= z.FromDate ? TrainingManagementTypeStatus.Active : currentDate < z.FromDate ? TrainingManagementTypeStatus.Upcoming : TrainingManagementTypeStatus.Past))
                .ReverseMap();

            base.CreateMap<TrainingInformationManagement, TrainingInformationManagementVM>()
                .ForMember(x => x.EmployeeInformationDto, y => y.MapFrom(z => z.EmployeeInformation))
                .ForMember(x => x.TrainingInformationManagementMasterDto, y => y.MapFrom(z => z.TrainingInformationManagementMaster)).
                ReverseMap();
            base.CreateMap<TrainingInformationManagementMaster, TrainingInformationManagementMasterVM>()
                .ForMember(x => x.TrainingManagementTypeDto, y => y.MapFrom(z => z.TrainingManagementType))
                .ForMember(x => x.TrainingInformationManagementLists, y => y.MapFrom(z => z.TrainingInformationManagements)).
                ReverseMap();
            base.CreateMap<RecruitPromo, RecruitPromoVM>()
                .ForMember(x => x.OfficialInformationList, y => y.MapFrom(z => z.OfficialInformations)).
                ReverseMap();


            //employee information
            base.CreateMap<UniversityInformation, UniversityInformationVM>().ReverseMap();

            base.CreateMap<EmployeeInformation, EmployeeInformationListVM>()
                .ReverseMap();
            base.CreateMap<EmployeeInformation, EmployeeInformationVM>()
                //.ForMember(x => x.JoiningDesignation, y => y.MapFrom(source => (source.OfficialInformation.FirstOrDefault()).JoiningDesg.DesignationName))

                .ForMember(x => x.PermanentAddressesList, y => y.MapFrom(source => source.PermanentAddresses))
                .ForMember(x => x.PresentAddressesList, y => y.MapFrom(source => source.PresentAddresses))
                .ForMember(x => x.SpouseInformationList, y => y.MapFrom(source => source.SpouseInformation))
                .ForMember(x => x.EducationalQualificationList, y => y.MapFrom(source => source.EducationalQualification))
                .ForMember(x => x.TrainingInformationList, y => y.MapFrom(source => source.TrainingInformation))
                .ForMember(x => x.ChildrenInformationList, y => y.MapFrom(source => source.ChildrenInformation))
                .ForMember(x => x.ServiceHistoriesList, y => y.MapFrom(source => source.ServiceHistories))
                //.ForMember(x => x.OfficialInformationList, y => y.MapFrom(source => source.OfficialInformation))
                .ForMember(x => x.DisciplinaryActionsAndCriminalProsecutionsList, y => y.MapFrom(source => source.DisciplinaryActionsAndCriminalProsecutions))
                .ForMember(x => x.PostingRecordsList, y => y.MapFrom(source => source.PostingRecords))
                .ForMember(x => x.EmployeeTransfersList, y => y.MapFrom(source => source.EmployeeTransfers))
                .ForMember(x => x.PromotionPartcularsList, y => y.MapFrom(source => source.PromotionPartculars))
                .ForMember(x => x.LanguageInformationsList, y => y.MapFrom(source => source.LanguageInformations))
                .ForMember(x => x.LeaveApplicationsList, y => y.MapFrom(source => source.LeaveApplications))
                .ForMember(x => x.PoliceStationDTO, y => y.MapFrom(source => source.PoliceStation))
                .ForMember(x => x.DivisionDTO, y => y.MapFrom(source => source.Division))
                .ForMember(x => x.DistrictDTO, y => y.MapFrom(source => source.District))
                .ForMember(x => x.EmployeeStatusDTO, y => y.MapFrom(source => source.EmployeeStatus))
                .ReverseMap();

            base.CreateMap<OfficialInformation, OfficialInformationVM>()
                .ForMember(x => x.JoiningRankDTO, y => y.MapFrom(source => source.JoiningRank))
                .ForMember(x => x.PresentRankDTO, y => y.MapFrom(source => source.PresentRank))
                .ForMember(x => x.PresentDesignationClassDTO, y => y.MapFrom(source => source.PresentDesignationClass))
                .ForMember(x => x.PresentDesignationDTO, y => y.MapFrom(source => source.PresentDesignation))
                .ForMember(x => x.CrntDesgDTO, y => y.MapFrom(source => source.CrntDesg))
                .ForMember(x => x.CurrDesignationClassDTO, y => y.MapFrom(source => source.CurrDesignationClass))
                .ForMember(x => x.PostResponsibilityDTO, y => y.MapFrom(source => source.PostResponsibility))
                .ForMember(x => x.PromtionNatureDTO, y => y.MapFrom(source => source.PromtionNature))
                .ForMember(x => x.PostingTypeDTO, y => y.MapFrom(source => source.PostingType))
                .ForMember(x => x.DeppostingTypeDTO, y => y.MapFrom(source => source.DeppostingType))
                .ForMember(x => x.PostingDTO, y => y.MapFrom(source => source.Posting))
                .ForMember(x => x.DeppostingDTO, y => y.MapFrom(source => source.Depposting))
                .ForMember(x => x.EmployeeInformationDTO, y => y.MapFrom(source => source.EmployeeInformation))
                .ForMember(x => x.JoinPostingTypeDTO, y => y.MapFrom(source => source.JoinPostingType))
                .ForMember(x => x.JoinPostingDTO, y => y.MapFrom(source => source.JoinPosting))
                .ForMember(x => x.JoiningDesignationClassDTO, y => y.MapFrom(source => source.JoiningDesignationClass))
                .ForMember(x => x.JoiningDesgDTO, y => y.MapFrom(source => source.JoiningDesg))
                .ForMember(x => x.GradationTypeDTO, y => y.MapFrom(source => source.GradationType))
                .ForMember(x => x.EmployeeTypeDTO, y => y.MapFrom(source => source.EmployeeType))
                .ForMember(x => x.RecruitPromoDTO, y => y.MapFrom(source => source.RecruitPromo))
                .ForMember(x => x.JobCategoryDTO, y => y.MapFrom(source => source.JobCategory)).ReverseMap();
            base.CreateMap<PermanentAddress, PermanentAddressVM>()
                .ForMember(x => x.DivisionDTO, y => y.MapFrom(z => z.Division))
                .ForMember(x => x.DistrictDTO, y => y.MapFrom(z => z.District))
                .ForMember(x => x.PoliceStationDTO, y => y.MapFrom(z => z.PoliceStation)).ReverseMap();
            base.CreateMap<PresentAddress, PresentAddressVM>()
                .ForMember(x => x.DivisionDTO, y => y.MapFrom(z => z.Division))
                .ForMember(x => x.DistrictDTO, y => y.MapFrom(z => z.District))
                .ForMember(x => x.PoliceStationDTO, y => y.MapFrom(z => z.PoliceStation)).ReverseMap();
            base.CreateMap<SpouseInformation, SpouseInformationVM>()
                .ForMember(x => x.DivisionDTO, y => y.MapFrom(z => z.Division))
                .ForMember(x => x.DistrictDTO, y => y.MapFrom(z => z.District)).ReverseMap();
            base.CreateMap<ChildrenInformation, ChildrenInformationVM>().ReverseMap();
            base.CreateMap<EducationalQualification, EducationalQualificationVM>()
                .ForMember(x => x.DegreeDTO, y => y.MapFrom(z => z.Degree)).ReverseMap();
            base.CreateMap<TrainingInformation, TrainingInformationVM>().ReverseMap();
            base.CreateMap<CountryTrainingManagementTypeMap, CountryTrainingManagementTypeMapVM>()
                .ForMember(x => x.TrainingManagementTypeVM, y => y.MapFrom(z => z.TrainingManagementType)).ReverseMap();
            base.CreateMap<ServiceHistory, ServiceHistoryVM>().ReverseMap();
            base.CreateMap<PromotionPartculars, PromotionPartcularsVM>()
                .ForMember(x => x.RankDTO, y => y.MapFrom(z => z.Rank))
                .ForMember(x => x.DesignationDTO, y => y.MapFrom(z => z.Designation))
                .ForMember(x => x.PromtionNatureDTO, y => y.MapFrom(z => z.PromtionNature))
                .ForMember(x => x.PayScaleYearInfoDTO, y => y.MapFrom(z => z.PayScaleYearInfo))
                .ReverseMap();
            base.CreateMap<DisciplinaryActionsAndCriminalProsecution, DisciplinaryActionsAndCriminalProsecutionVM>()
                 .ForMember(x => x.CategoryDTO, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.PresentStatusDTO, y => y.MapFrom(z => z.PresentStatus)).ReverseMap();
            base.CreateMap<PostingRecords, PostingRecordsVM>()
                .ForMember(x => x.RankDTO, y => y.MapFrom(z => z.Rank))
                .ForMember(x => x.PostResponsibilityDTO, y => y.MapFrom(z => z.PostResponsibility))
                .ForMember(x => x.DesignationClassDTO, y => y.MapFrom(z => z.DesignationClass))
                .ForMember(x => x.DesignationDTO, y => y.MapFrom(z => z.Designation))
                .ForMember(x => x.MainPostingTypeDTO, y => y.MapFrom(z => z.MainPostingType))
                .ForMember(x => x.PostingDTO, y => y.MapFrom(z => z.Posting))
                .ForMember(x => x.CurrDesignationClassDTO, y => y.MapFrom(z => z.CurrDesignationClass))
                .ForMember(x => x.CrntDesgDTO, y => y.MapFrom(z => z.CrntDesg))
                .ForMember(x => x.DeppostingTypeDTO, y => y.MapFrom(z => z.DeppostingType))
                .ForMember(x => x.DepPostingDTO, y => y.MapFrom(z => z.DepPosting))
                .ForMember(x => x.TransferFromDivisionDTO, y => y.MapFrom(z => z.TransferFromDivision))
                .ForMember(x => x.TransferFromDistrictDTO, y => y.MapFrom(z => z.TransferFromDistrict))
                .ForMember(x => x.TransferToDivisionDTO, y => y.MapFrom(z => z.TransferToDivision))
                .ForMember(x => x.TransferToDistrictDTO, y => y.MapFrom(z => z.TransferToDistrict))
                .ReverseMap();
            base.CreateMap<LanguageInformation, LanguageInformationVM>()
                .ForMember(x => x.LanguageDTO, y => y.MapFrom(z => z.Language)).ReverseMap();
            base.CreateMap<EmployeeTransfer, EmployeeTransferVM>()
                .ForMember(x => x.EmployeeInformationDTO, y => y.MapFrom(z => z.EmployeeInformation))
                .ForMember(x => x.DesignationDTO, y => y.MapFrom(z => z.Designation))
                .ForMember(x => x.TransferFromDistrictDTO, y => y.MapFrom(z => z.TransferFromDistrict))
                .ForMember(x => x.TransferFromDivisionDTO, y => y.MapFrom(z => z.TransferFromDivision))
                .ForMember(x => x.TransferToDistrictDTO, y => y.MapFrom(z => z.TransferToDistrict))
                .ForMember(x => x.TransferToDivisionDTO, y => y.MapFrom(z => z.TransferToDivision))
                .ForMember(x => x.PostingRecordsDTO, y => y.MapFrom(z => z.PostingRecords))
                .ReverseMap();
            base.CreateMap<LeaveApplication, LeaveApplicationVM>()
                .ForMember(x => x.EmployeeInformationDTO, y => y.MapFrom(z => z.EmployeeInformation))
                .ForMember(x => x.LeaveTypeInformationDTO, y => y.MapFrom(z => z.LeaveTypeInformation));

            base.CreateMap<LeaveApplicationVM, LeaveApplication>()
                //.ForMember(x => x.EmployeeInformationDTO, y => y.MapFrom(z => z.EmployeeInformation))
                .ForMember(x => x.LeaveTypeInformation, y => y.MapFrom(z => z.LeaveTypeInformationDTO));

            //User Manager

            base.CreateMap<User, UserVM>().ReverseMap(); //Source to Destination
            base.CreateMap<UserGroup, UserGroupVM>().ReverseMap();
           
            base.CreateMap<Color, ColorVM>().ReverseMap();
            base.CreateMap<UserRoles, UserRolesVM>().ReverseMap();
            base.CreateMap<Accesslist, AccesslistVM>().ReverseMap();
            base.CreateMap<AccessMapper, AccessMapperVM>().ReverseMap();
            base.CreateMap<Module, ModuleVM>().ReverseMap();
            base.CreateMap<PmsGroup, PmsGroupVM>().ReverseMap();
            base.CreateMap<DisciplinaryHistory, DisciplinaryHistoryVM>().ReverseMap();
            base.CreateMap<PRL, PRL_VM>().ReverseMap();
            base.CreateMap<EmployeeInformation, EmployeeInformationVM>().ReverseMap();

            base.CreateMap<Union, UnionVM>().ReverseMap();


            //bd army
            base.CreateMap<Routes, RoutesVM>()
                .ForMember(q => q.RoutesDetails, s => s.MapFrom(a => a.RoutesDetails))
                .ForMember(q => q.LineStringJsons, s => s.MapFrom(a => a.LineStringJsons)).ReverseMap();
            base.CreateMap<RoutesDetails, RoutesDetailsVM>().ReverseMap();
            base.CreateMap<RoutesLineStringJsons, RoutesLineStringJsonsVM>().ReverseMap();

            base.CreateMap<PromotionManagement, PromotionManagementVM>()
            .ForMember(x => x.RankDTO, y => y.MapFrom(z => z.Rank))
            .ForMember(x => x.DesignationDTO, y => y.MapFrom(z => z.Designation))
            .ForMember(x => x.PromtionNatureDTO, y => y.MapFrom(z => z.PromtionNature))
            .ForMember(x => x.PayScaleYearInfoDTO, y => y.MapFrom(z => z.PayScaleYearInfo))
            .ReverseMap();

            base.CreateMap<OrganogramVM, OrganogramDetailsVM>().ReverseMap();

            base.CreateMap<Organogram, OrganogramVM>()
                .ForMember(x => x.NonPermanentDeadLineString, y => y.MapFrom(z => z.NonPermanentDeadLine.ToString()))
                .ForMember(x => x.PostingTypeDto, y => y.MapFrom(z => z.PostingType))
                .ForMember(x => x.PostingDto, y => y.MapFrom(z => z.Posting))
                .ForMember(x => x.ParentPostingDto, y => y.MapFrom(z => z.ParentPosting))
                .ForMember(x => x.DesignationDto, y => y.MapFrom(z => z.Designation))
                .ReverseMap();

            base.CreateMap<TrainingPlan, TrainingPlanVM>().ReverseMap();
            base.CreateMap<OtherTrainingMember, OtherTrainingMemberVM>().ReverseMap();

            base.CreateMap<EmployeePostingDetails, EmployeePostingDetailsVM>().ReverseMap();

        }
    }
}
