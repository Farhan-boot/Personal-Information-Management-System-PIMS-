using Microsoft.Extensions.DependencyInjection;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Implementation;
using PTSL.DgFood.Business.Businesses.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories;
using PTSL.DgFood.DAL.Repositories.Implementation;
using PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.Repositories.Interface.EmployeeManagementEntity;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Implementation;
using PTSL.DgFood.Service.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services.Implementation.MailService;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services.Interface.GeneralSetup;
using PTSL.DgFood.Service.Services.Interface.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Helpers
{
    public static class ServiceRegistration
    {
        public static void RegisterAllServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterBusniesses(services);
            RegisterRepositorys(services);
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDegreeService, DegreeService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IDesignationClassService, DesignationClassService>();
            services.AddScoped<IUpazillaService, UpazillaService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IPoliceStationService, PoliceStationService>();
            services.AddScoped<IPostingService, PostingService>();
            services.AddScoped<IPostingTypeService, PostingTypeService>();
            services.AddScoped<IPostResponsibilityService, PostResponsibilityService>();
            services.AddScoped<IPresentStatusService, PresentStatusService>();
            services.AddScoped<IPromtionNatureService, PromtionNatureService>();
            services.AddScoped<IRankService, RankService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IPayScaleYearInfoService, PayScaleYearInfoService>();

            services.AddScoped<ISpouseInformationService, SpouseInformationService>();
            services.AddScoped<ITrainingInformationService, TrainingInformationService>();
            services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<IAccesslistService, AccesslistService>();
            services.AddScoped<IAccessMapperService, AccessMapperService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IPmsGroupService, PmsGroupService>();
            services.AddScoped<IEmployeeInformationService, EmployeeInformationService>();
            services.AddScoped<IChildrenInformationService, ChildrenInformationService>();
            services.AddScoped<IPresentAddressService, PresentAddressService>();
            services.AddScoped<IEducationalQualificationService, EducationalQualificationService>();
            services.AddScoped<ITrainingInformationService, TrainingInformationService>();
            services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
            services.AddScoped<IOfficialInformationService, OfficialInformationService>();
            services.AddScoped<IDisciplinaryActionsAndCriminalProsecutionService, DisciplinaryActionsAndCriminalProsecutionService>();
            services.AddScoped<IPostingRecordsService, PostingRecordsService>();
            services.AddScoped<IEmployeeTransferService, EmployeeTransferService>();
            services.AddScoped<IPromotionPartcularsService, PromotionPartcularsService>();
            services.AddScoped<IJobCategoryService, JobCategoryService>();
            services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
            services.AddScoped<IGradationTypeService, GradationTypeService>();
            services.AddScoped<IRoutesService, RoutesService>();
            services.AddScoped<IRoutesDetailsService, RoutesDetailsService>();
            services.AddScoped<IRoutesLineStringJsonsService, RoutesLineStringJsonsService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILanguageInformationService, LanguageInformationService>();
            services.AddScoped<IYearsService, YearsService>();
            services.AddScoped<ISpecialHolydaySetupService, SpecialHolydaySetupService>();
            services.AddScoped<IWeeklyHolydaySetupService, WeeklyHolydaySetupService>();
            services.AddScoped<ICalculationMethodService, CalculationMethodService>();
            services.AddScoped<ILeaveTypeInformationService, LeaveTypeInformationService>();
            services.AddScoped<ILeaveApplicationService, LeaveApplicationService>();
            services.AddScoped<ITrainingManagementTypeService, TrainingManagementTypeService>();
            services.AddScoped<ITrainingInformationManagementService, TrainingInformationManagementService>();
            services.AddScoped<ITrainingInformationManagementMasterService, TrainingInformationManagementMasterService>();
            services.AddScoped<IPromotionManagementService, PromotionManagementService>();
            services.AddScoped<IEmployeeInformationCountService, EmployeeInformationCountService>();
            services.AddScoped<IOrganogramService, OrganogramService>();
            services.AddScoped<IDisciplinaryHistoryService, DisciplinaryHistoryService>();
            services.AddScoped<IPRLService, PRLService>();
            services.AddScoped<IMailService, MailService>();

        }
        private static void RegisterBusniesses(IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserGroupBusiness, UserGroupBusiness>();
            services.AddScoped<IEmployeeStatusBusiness, EmployeeStatusBusiness>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IDegreeBusiness, DegreeBusiness>();
            services.AddScoped<IDesignationBusiness, DesignationBusiness>();
            services.AddScoped<IDesignationClassBusiness, DesignationClassBusiness>();
            services.AddScoped<IUpazillaBusiness, UpazillaBusiness>();
            services.AddScoped<IDistrictBusiness, DistrictBusiness>();
            services.AddScoped<IDivisionBusiness, DivisionBusiness>();
            services.AddScoped<IPoliceStationBusiness, PoliceStationBusiness>();
            services.AddScoped<IPostingBusiness, PostingBusiness>();
            services.AddScoped<IPostingTypeBusiness, PostingTypeBusiness>();
            services.AddScoped<IPostResponsibilityBusiness, PostResponsibilityBusiness>();
            services.AddScoped<IPresentStatusBusiness, PresentStatusBusiness>();
            services.AddScoped<IPromtionNatureBusiness, PromtionNatureBusiness>();
            services.AddScoped<IRankBusiness, RankBusiness>();
            services.AddScoped<IColorBusiness, ColorBusiness>();
            services.AddScoped<IPayScaleYearInfoBusiness, PayScaleYearInfoBusiness>();

            services.AddScoped<IServiceHistoryBusiness, ServiceHistoryBusiness>();
            services.AddScoped<ITrainingInformationBusiness, TrainingInformationBusiness>();
            services.AddScoped<ISpouseInformationBusiness, SpouseInformationBusiness>();
            services.AddScoped<IUserRolesBusiness, UserRolesBusiness>();
            services.AddScoped<IAccesslistBusiness, AccesslistBusiness>();
            services.AddScoped<IAccessMapperBusiness, AccessMapperBusiness>();
            services.AddScoped<IModuleBusiness, ModuleBusiness>();
            services.AddScoped<IPmsGroupBusiness, PmsGroupBusiness>();
            services.AddScoped<IEmployeeInformationBusiness, EmployeeInformationBusiness>();
            services.AddScoped<IChildrenInformationBusiness, ChildrenInformationBusiness>();
            services.AddScoped<IPermanentAddressBusiness, PermanentAddressBusiness>();

            services.AddScoped<IPresentAddressBusiness, PresentAddressBusiness>();
            services.AddScoped<IEducationalQualificationBusiness, EducationalQualificationBusiness>();
            services.AddScoped<ITrainingInformationBusiness, TrainingInformationBusiness>();
            services.AddScoped<IServiceHistoryBusiness, ServiceHistoryBusiness>();
            services.AddScoped<IOfficialInformationBusiness, OfficialInformationBusiness>();
            services.AddScoped<IDisciplinaryActionsAndCriminalProsecutionBusiness, DisciplinaryActionsAndCriminalProsecutionBusiness>();
            services.AddScoped<IPostingRecordsBusiness, PostingRecordsBusiness>();
            services.AddScoped<IEmployeeTransferBusiness, EmployeeTransferBusiness>();
            services.AddScoped<IPromotionPartcularsBusiness, PromotionPartcularsBusiness>();
            services.AddScoped<IJobCategoryBusiness, JobCategoryBusiness>();
            services.AddScoped<IEmployeeTypeBusiness, EmployeeTypeBusiness>();
            services.AddScoped<IGradationTypeBusiness, GradationTypeBusiness>();
            services.AddScoped<IRoutesBusiness, RoutesBusiness>();
            services.AddScoped<IRoutesDetailsBusiness, RoutesDetailsBusiness>();
            services.AddScoped<IRoutesLineStringJsonsBusiness, RoutesLineStringJsonsBusiness>();
            services.AddScoped<ILanguageBusiness, LanguageBusiness>();
            services.AddScoped<ILanguageInformationBusiness, LanguageInformationBusiness>();
            services.AddScoped<IYearsBusiness, YearsBusiness>();
            services.AddScoped<ISpecialHolydaySetupBusiness, SpecialHolydaySetupBusiness>();
            services.AddScoped<IWeeklyHolydaySetupBusiness, WeeklyHolydaySetupBusiness>();
            services.AddScoped<ICalculationMethodBusiness, CalculationMethodBusiness>();
            services.AddScoped<ILeaveTypeInformationBusiness, LeaveTypeInformationBusiness>();
            services.AddScoped<ILeaveApplicationBusiness, LeaveApplicationBusiness>();
            services.AddScoped<ITrainingManagementTypeBusiness, TrainingManagementTypeBusiness>();
            services.AddScoped<ITrainingInformationManagementBusiness, TrainingInformationManagementBusiness>();
            services.AddScoped<ITrainingInformationManagementMasterBusiness, TrainingInformationManagementMasterBusiness>();
            services.AddScoped<IPromotionManagementBusiness, PromotionManagementBusiness>();
            services.AddScoped<IEmployeeInformationCountBusiness, EmployeeInformationCountBusiness>();
            services.AddScoped<IOrganogramBusiness, OrganogramBusiness>();
            services.AddScoped<IDisciplinaryHistoryBusiness, DisciplinaryHistoryBusiness>();
            services.AddScoped<IPRLBusiness, PRLBusiness>();
        }
        private static void RegisterRepositorys(IServiceCollection services)
        {
            services.AddScoped<IDgFoodUnitOfWork, DgFoodUnitOfWork>();

            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IDesignationClassRepository, DesignationClassRepository>();
            services.AddScoped<IUpazillaRepository, UpazillaRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IPoliceStationRepository, PoliceStationRepository>();
            services.AddScoped<IPostingRepository, PostingRepository>();
            services.AddScoped<IPostingTypeRepository, PostingTypeRepository>();
            services.AddScoped<IPostResponsibilityRepository, PostResponsibilityRepository>();
            services.AddScoped<IPresentStatusRepository, PresentStatusRepository>();
            services.AddScoped<IPromtionNatureRepository, PromtionNatureRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IPayScaleYearInfoRepository, PayScaleYearInfoRepository>();

            services.AddScoped<ISpouseInformationRepository, SpouseInformationRepository>();
            services.AddScoped<ITrainingInformationRepository, TrainingInformationRepository>();
            services.AddScoped<IServiceHistoryRepository, ServiceHistoryRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IAccesslistRepository, AccesslistRepository>();
            services.AddScoped<IAccessMapperRepository, AccessMapperRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPmsGroupRepository, PmsGroupRepository>();
            services.AddScoped<IEmployeeInformationRepository, EmployeeInformationRepository>();
            services.AddScoped<IChildrenInformationRepository, ChildrenInformationRepository>();
            services.AddScoped<IPresentAddressRepository, PresentAddressRepository>();
            services.AddScoped<IEducationalQualificationRepository, EducationalQualificationRepository>();
            services.AddScoped<ITrainingInformationRepository, TrainingInformationRepository>();
            services.AddScoped<IServiceHistoryRepository, ServiceHistoryRepository>();
            services.AddScoped<IOfficialInformationRepository, OfficialInformationRepository>();
            services.AddScoped<IDisciplinaryActionsAndCriminalProsecutionRepository, DisciplinaryActionsAndCriminalProsecutionRepository>();
            services.AddScoped<IPostingRecordsRepository, PostingRecordsRepository>();
            services.AddScoped<IEmployeeTransferRepository, EmployeeTransferRepository>();
            services.AddScoped<IPromotionPartcularsRepository, PromotionPartcularsRepository>();
            services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddScoped<IGradationTypeRepository, GradationTypeRepository>();
            services.AddScoped<IRoutesRepository, RoutesRepository>();
            services.AddScoped<IRoutesDetailsRepository, RoutesDetailsRepository>();
            services.AddScoped<IRoutesLineStringJsonsRepository, RoutesLineStringJsonsRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageInformationRepository, LanguageInformationRepository>();
            services.AddScoped<IYearsRepository, YearsRepository>();
            services.AddScoped<ISpecialHolydaySetupRepository, SpecialHolydaySetupRepository>();
            services.AddScoped<IWeeklyHolydaySetupRepository, WeeklyHolydaySetupRepository>();
            services.AddScoped<ICalculationMethodRepository, CalculationMethodRepository>();
            services.AddScoped<ILeaveTypeInformationRepository, LeaveTypeInformationRepository>();
            services.AddScoped<ILeaveApplicationRepository, LeaveApplicationRepository>();
            services.AddScoped<ITrainingManagementTypeRepository, TrainingManagementTypeRepository>();
            services.AddScoped<ITrainingInformationManagementRepository, TrainingInformationManagementRepository>();
            services.AddScoped<ITrainingInformationManagementMasterRepository, TrainingInformationManagementMasterRepository>();
            services.AddScoped<IPromotionManagementRepository, PromotionManagementRepository>();
            services.AddScoped<IEmployeeInformationCountRepository, EmployeeInformationCountRepository>();
            services.AddScoped<IOrganogramRepository, OrganogramRepository>();
            services.AddScoped<IDisciplinaryHistoryRepository, DisciplinaryHistoryRepository>();
            services.AddScoped<IPRLRepository, PRLRepository>();
        }
    }
}