using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.Repositories.Implementation;
using PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.Repositories.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model;
using PTSL.GENERIC.DAL.Repositories.Implementation.EmployeeManagementEntity;
using PTSL.GENERIC.DAL.Repositories.Implementation.GeneralSetup;
using PTSL.GENERIC.DAL.Repositories.Interface.EmployeeManagementEntity;
using PTSL.GENERIC.DAL.Repositories.Interface.GeneralSetup;

namespace PTSL.DgFood.DAL.UnitOfWork
{
    public class DgFoodUnitOfWork : IDgFoodUnitOfWork
    {
        private DgFoodWriteOnlyCtx WriteOnlyCtx { get; }
        private DgFoodReadOnlyCtx ReadOnlyCtx { get; }

        public IUserRepository users { get; set; }
        public IUserGroupRepository usergroups { get; set; }
        public IEmployeeStatusRepository EmployeeStatuss { get; set; }
        public ICategoryRepository Categoriess { get; set; }
        public IDegreeRepository Degrees { get; set; }
        public IDesignationRepository Designations { get; set; }
        public IDesignationClassRepository DesignationClasses { get; set; }
        public IUpazillaRepository Upazilla { get; set; }
        public IDistrictRepository Districts { get; set; }
        public IDivisionRepository Divisions { get; set; }
        public IPoliceStationRepository PoliceStations { get; set; }
        public IPostingRepository Postings { get; set; }
        public IPostingTypeRepository PostingTypes { get; set; }
        public IPostResponsibilityRepository PostResponsibilities { get; set; }
        public IPresentStatusRepository PresentStatuses { get; set; }
        public IPromtionNatureRepository PromtionNatures { get; set; }
        public IRankRepository Ranks { get; set; }
        public IColorRepository Color { get; set; }
        public IPayScaleYearInfoRepository PayScaleYearInfo { get; set; }

        public ITrainingInformationRepository TrainingInformation { get; set; }
        public ISpouseInformationRepository SpouseInformation { get; set; }

        public IServiceHistoryRepository ServiceHistory { get; set; }
        public IUserRolesRepository UserRoles { get; set; }
        public IAccesslistRepository Accesslist { get; set; }
        public IAccessMapperRepository AccessMapper { get; set; }
        public IModuleRepository Module { get; set; }
        public IPmsGroupRepository PmsGroup { get; set; }
        public IEmployeeInformationRepository EmployeeInformation { get; set; }
        public IChildrenInformationRepository ChildrenInformation { get; set; }
        public IPresentAddressRepository PresentAddress { get; set; }
        public IPermanentAddressRepository PermanentAddress { get; set; }
        public IDisciplinaryActionsAndCriminalProsecutionRepository DisciplinaryActionsAndCriminalProsecution { get; set; }
        public IEducationalQualificationRepository EducationalQualification { get; set; }
        public IEmployeeTransferRepository EmployeeTransfer { get; set; }
        public IOfficialInformationRepository OfficialInformation { get; set; }
        public IPostingRecordsRepository PostingRecords { get; set; }
        public IPromotionPartcularsRepository PromotionPartculars { get; set; }
        public IJobCategoryRepository JobCategory { get; set; }
        public IEmployeeTypeRepository EmployeeType { get; set; }
        public IGradationTypeRepository GradationType { get; set; }
        public IRoutesRepository Routes { get; set; }
        public IRoutesDetailsRepository RoutesDetails { get; set; }
        public IRoutesLineStringJsonsRepository RoutesLineStringJsons { get; set; }
        public ILanguageRepository Language { get; set; }
        public ILanguageInformationRepository LanguageInformation { get; set; }
        public IYearsRepository Years { get; set; }
        public ISpecialHolydaySetupRepository SpecialHoliday { get; set; }
        public IWeeklyHolydaySetupRepository WeeklyHoliday { get; set; }
        public ILeaveTypeInformationRepository LeaveTypeInformation { get; set; }
        public ICalculationMethodRepository CalculationMethod { get; set; }
        public ILeaveApplicationRepository LeaveApplication { get; set; }
        public ITrainingManagementTypeRepository TrainingManagementType { get; set; }
        public ITrainingInformationManagementRepository TrainingInformationManagement { get; set; }
        public ITrainingInformationManagementMasterRepository TrainingInformationManagementMaster { get; set; }
        public IPromotionManagementRepository PromotionManagement { get; set; }
        public IEmployeeInformationCountRepository EmployeeInformationCount { get; set; }
        public IOrganogramRepository Organogram { get; set; }
        public IDisciplinaryHistoryRepository DisciplinaryHistoryRepository { get; set; }
        public IPRLRepository PRLRepository { get; set; }
        public IUniversityInformationRepository UniversityInformationRepository { get; set; }
        public IUnionRepository UnionRepository { get; set; }
        public ITrainingPlanRepository TrainingPlanRepository { get; set; }
        public IOtherTrainingMemberRepository OtherTrainingMemberRepository { get; set; }

        public IEmployeePostingDetailsRepository EmployeePostingDetailsRepository { get; set; }

        public DgFoodUnitOfWork(
            DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
            DgFoodReadOnlyCtx ecommarceReadOnlyCtx,
            IUserRepository userRepository,
            IUserGroupRepository userGroupRepository,
            IEmployeeStatusRepository employeeStatusRepository,
            ICategoryRepository categoryRepository,
            IDesignationRepository designationRepository,
            IDegreeRepository degreeRepository,
            IDesignationClassRepository designationClassRepository,
            IUpazillaRepository upazillaRepository,
            IDistrictRepository districtRepository,
            IDivisionRepository divisionRepository,
            IPoliceStationRepository policeStationRepository,
            IPostingRepository postingRepository,
            IPostingTypeRepository postingTypeRepository,
            IPostResponsibilityRepository postResponsibilityRepository,
            IPresentStatusRepository presentStatusRepository,
            IPromtionNatureRepository promtionNatureRepository,
            IRankRepository rankRepository,
            IColorRepository colorRepository,
            ITrainingInformationRepository trainingInformationRepository,
            ISpouseInformationRepository spouseInformationRepository,
            IServiceHistoryRepository serviceHistoryRepository,
            IUserRolesRepository userRolesRepository,
            IAccesslistRepository accesslistRepository,
            IAccessMapperRepository accessMapperRepository,
            IModuleRepository moduleRepository,
            IPmsGroupRepository pmsGroupRepository,
            IEmployeeInformationRepository employeeInformationRepository,
            IChildrenInformationRepository childrenInformationRepository,
            IPresentAddressRepository presentAddressRepository,
            IPermanentAddressRepository permanentAddressRepository,
            IDisciplinaryActionsAndCriminalProsecutionRepository disciplinaryActionsAndCriminalProsecutionRepository,
            IEducationalQualificationRepository educationalQualificationRepository,
            IEmployeeTransferRepository employeeTransferRepository,
            IOfficialInformationRepository officialInformationRepository,
            IPostingRecordsRepository postingRecordsRepository,
            IPromotionPartcularsRepository promotionPartcularsRepository,
            IGradationTypeRepository gradationTypeRepository,
            IEmployeeTypeRepository employeeTypeRepository,
            IJobCategoryRepository jobCategoryRepository,
            IRoutesRepository RoutesRepository,
            IRoutesDetailsRepository RoutesDetailsRepository,
            IRoutesLineStringJsonsRepository RoutesLineStringJsonsRepository,
            ILanguageRepository LanguageRepository,
            ILanguageInformationRepository LanguageInformationRepository,
            IYearsRepository YearsRepository,
            ISpecialHolydaySetupRepository SpecialHolydaySetupRepository,
            IWeeklyHolydaySetupRepository WeeklyHolydaySetupRepository,
            ICalculationMethodRepository CalculationMethodRepository,
            ILeaveTypeInformationRepository LeaveTypeInformationRepository,
            ILeaveApplicationRepository LeaveApplicationRepository,
            IPayScaleYearInfoRepository PayScaleYearInfoRepository,
            ITrainingManagementTypeRepository TrainingManagementTypeRepository,
            ITrainingInformationManagementRepository TrainingInformationManagementRepository,
            ITrainingInformationManagementMasterRepository TrainingInformationManagementMasterRepository,
            IPromotionManagementRepository PromotionManagementRepository,
            IEmployeeInformationCountRepository EmployeeInformationCountRepository,
            IOrganogramRepository OrganogramRepository,
            IDisciplinaryHistoryRepository disciplinaryHistoryRepository,
            IPRLRepository prlRepository,
            IUniversityInformationRepository universityInformationRepository,
            IUnionRepository unionRepository,
            ITrainingPlanRepository trainingPlanRepository,
            IOtherTrainingMemberRepository otherTrainingMemberRepository,
            IEmployeePostingDetailsRepository employeePostingDetailsRepository
            )
        {
            WriteOnlyCtx = ecommarceWriteOnlyCtx;
            ReadOnlyCtx = ecommarceReadOnlyCtx;
            users = userRepository;
            usergroups = userGroupRepository;
            EmployeeStatuss = employeeStatusRepository;
            Categoriess = categoryRepository;
            Degrees = degreeRepository;
            Designations = designationRepository;
            DesignationClasses = designationClassRepository;
            Upazilla = upazillaRepository;
            Districts = districtRepository;
            Divisions = divisionRepository;
            PoliceStations = policeStationRepository;
            Postings = postingRepository;
            PostingTypes = postingTypeRepository;
            PostResponsibilities = postResponsibilityRepository;
            PresentStatuses = presentStatusRepository;
            PromtionNatures = promtionNatureRepository;
            Ranks = rankRepository;
            Color = colorRepository;
            PayScaleYearInfo = PayScaleYearInfoRepository;

            TrainingInformation = trainingInformationRepository;
            SpouseInformation = spouseInformationRepository;
            ServiceHistory = serviceHistoryRepository;
            UserRoles = userRolesRepository;
            Accesslist = accesslistRepository;
            AccessMapper = accessMapperRepository;
            Module = moduleRepository;
            PmsGroup = pmsGroupRepository;
            EmployeeInformation = employeeInformationRepository;
            ChildrenInformation = childrenInformationRepository;
            PresentAddress = presentAddressRepository;
            PermanentAddress = permanentAddressRepository;
            DisciplinaryActionsAndCriminalProsecution = disciplinaryActionsAndCriminalProsecutionRepository;
            EducationalQualification = educationalQualificationRepository;
            EmployeeTransfer = employeeTransferRepository;
            OfficialInformation = officialInformationRepository;
            PostingRecords = postingRecordsRepository;
            PromotionPartculars = promotionPartcularsRepository;
            JobCategory = jobCategoryRepository;
            EmployeeType = employeeTypeRepository;
            GradationType = gradationTypeRepository;
            Routes = RoutesRepository;
            RoutesDetails = RoutesDetailsRepository;
            RoutesLineStringJsons = RoutesLineStringJsonsRepository;
            Language = LanguageRepository;
            LanguageInformation = LanguageInformationRepository;
            Years = YearsRepository;
            SpecialHoliday = SpecialHolydaySetupRepository;
            WeeklyHoliday = WeeklyHolydaySetupRepository;
            LeaveTypeInformation = LeaveTypeInformationRepository;
            CalculationMethod = CalculationMethodRepository;
            LeaveApplication = LeaveApplicationRepository;
            TrainingManagementType = TrainingManagementTypeRepository;
            TrainingInformationManagement = TrainingInformationManagementRepository;
            TrainingInformationManagementMaster = TrainingInformationManagementMasterRepository;
            PromotionManagement = PromotionManagementRepository;
            EmployeeInformationCount = EmployeeInformationCountRepository;
            Organogram = OrganogramRepository;
            DisciplinaryHistoryRepository = disciplinaryHistoryRepository;
            PRLRepository = prlRepository;
            UniversityInformationRepository = universityInformationRepository;
            UnionRepository = unionRepository;
            TrainingPlanRepository = trainingPlanRepository;
            OtherTrainingMemberRepository = otherTrainingMemberRepository;
            EmployeePostingDetailsRepository = employeePostingDetailsRepository;
        }

        public IDbContextTransaction Begin()
        {
            try
            {
                IDbContextTransaction transaction = WriteOnlyCtx.Database.BeginTransaction();
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Complete(IDbContextTransaction transaction, CompletionState completionState)
        {
            try
            {
                if (transaction != null && transaction.TransactionId != null && transaction.GetDbTransaction() != null)
                {
                    if (completionState == CompletionState.Success)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                transaction.Rollback();
            }
        }

        #region Select a Repository based on given type

        //public string GetEnumDisplayName(this Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

        //    if (attributes != null && attributes.Length > 0)
        //        return attributes[0].Name;
        //    else
        //        return value.ToString();
        //}

        public IBaseRepository<T> Select<T>(T entity) where T : BaseEntity
        {

            IBaseRepository<T> repository = default(IBaseRepository<T>);
            switch (entity)
            {
                //case Colors _:
                //    repository = (IBaseRepository<T>)colors;
                //    break;
                //case Category _:
                //    repository = (IBaseRepository<T>)categorys;
                //    break;

                case User _:
                    repository = (IBaseRepository<T>)users;
                    break;
                case UserGroup _:
                    repository = (IBaseRepository<T>)usergroups;
                    break;
                case EmployeeStatus _:
                    repository = (IBaseRepository<T>)EmployeeStatuss;
                    break;
                case Degree _:
                    repository = (IBaseRepository<T>)Degrees;
                    break;

                case Category _:
                    repository = (IBaseRepository<T>)Categoriess;
                    break;
                case Designation _:
                    repository = (IBaseRepository<T>)Designations;
                    break;
                case DesignationClass _:
                    repository = (IBaseRepository<T>)DesignationClasses;
                    break;
                case District _:
                    repository = (IBaseRepository<T>)Districts;
                    break;
                case Upazilla _:
                    repository = (IBaseRepository<T>)Upazilla;
                    break;
                case Division _:
                    repository = (IBaseRepository<T>)Divisions;
                    break;
                case PoliceStation _:
                    repository = (IBaseRepository<T>)PoliceStations;
                    break;
                case Posting _:
                    repository = (IBaseRepository<T>)Postings;
                    break;
                case PostingType _:
                    repository = (IBaseRepository<T>)PostingTypes;
                    break;
                case PostResponsibility _:
                    repository = (IBaseRepository<T>)PostResponsibilities;
                    break;
                case PresentStatus _:
                    repository = (IBaseRepository<T>)PresentStatuses;
                    break;
                case PromtionNature _:
                    repository = (IBaseRepository<T>)PromtionNatures;
                    break;
                case Rank _:
                    repository = (IBaseRepository<T>)Ranks;
                    break;
                case Color _:
                    repository = (IBaseRepository<T>)Color;
                    break;
                case PayScaleYearInfo _:
                    repository = (IBaseRepository<T>)PayScaleYearInfo;
                    break;

                case SpouseInformation _:
                    repository = (IBaseRepository<T>)SpouseInformation;
                    break;

                case TrainingInformation _:
                    repository = (IBaseRepository<T>)TrainingInformation;
                    break;
                case ServiceHistory _:
                    repository = (IBaseRepository<T>)ServiceHistory;
                    break;
                case UserRoles _:
                    repository = (IBaseRepository<T>)UserRoles;
                    break;
                case Accesslist _:
                    repository = (IBaseRepository<T>)Accesslist;
                    break;
                case AccessMapper _:
                    repository = (IBaseRepository<T>)AccessMapper;
                    break;
                case Common.Entity.Module _:
                    repository = (IBaseRepository<T>)Module;
                    break;
                case PmsGroup _:
                    repository = (IBaseRepository<T>)PmsGroup;
                    break;
                case EmployeeInformation _:
                    repository = (IBaseRepository<T>)EmployeeInformation;
                    break;
                case ChildrenInformation _:
                    repository = (IBaseRepository<T>)ChildrenInformation;
                    break;

                case PresentAddress _:
                    repository = (IBaseRepository<T>)PresentAddress;
                    break;
                case PermanentAddress _:
                    repository = (IBaseRepository<T>)PermanentAddress;
                    break;
                case DisciplinaryActionsAndCriminalProsecution _:
                    repository = (IBaseRepository<T>)DisciplinaryActionsAndCriminalProsecution;
                    break;
                case EducationalQualification _:
                    repository = (IBaseRepository<T>)EducationalQualification;
                    break;
                case EmployeeTransfer _:
                    repository = (IBaseRepository<T>)EmployeeTransfer;
                    break;
                case OfficialInformation _:
                    repository = (IBaseRepository<T>)OfficialInformation;
                    break;
                case PostingRecords _:
                    repository = (IBaseRepository<T>)PostingRecords;
                    break;
                case PromotionPartculars _:
                    repository = (IBaseRepository<T>)PromotionPartculars;
                    break;
                case GradationType _:
                    repository = (IBaseRepository<T>)GradationType;
                    break;
                case EmployeeType _:
                    repository = (IBaseRepository<T>)EmployeeType;
                    break;
                case JobCategory _:
                    repository = (IBaseRepository<T>)JobCategory;
                    break;
                case Routes _:
                    repository = (IBaseRepository<T>)Routes;
                    break;
                case RoutesDetails _:
                    repository = (IBaseRepository<T>)RoutesDetails;
                    break;
                case RoutesLineStringJsons _:
                    repository = (IBaseRepository<T>)RoutesLineStringJsons;
                    break;
                case Language _:
                    repository = (IBaseRepository<T>)Language;
                    break;
                case LanguageInformation _:
                    repository = (IBaseRepository<T>)LanguageInformation;
                    break;
                case Years _:
                    repository = (IBaseRepository<T>)Years;
                    break;
                case SpecialHolydaySetup _:
                    repository = (IBaseRepository<T>)SpecialHoliday;
                    break;
                case WeeklyHolydaySetup _:
                    repository = (IBaseRepository<T>)WeeklyHoliday;
                    break;
                case CalculationMethod _:
                    repository = (IBaseRepository<T>)CalculationMethod;
                    break;
                case LeaveTypeInformation _:
                    repository = (IBaseRepository<T>)LeaveTypeInformation;
                    break;
                case LeaveApplication _:
                    repository = (IBaseRepository<T>)LeaveApplication;
                    break;
                case TrainingManagementType _:
                    repository = (IBaseRepository<T>)TrainingManagementType;
                    break;
                case TrainingInformationManagement _:
                    repository = (IBaseRepository<T>)TrainingInformationManagement;
                    break;
                case TrainingInformationManagementMaster _:
                    repository = (IBaseRepository<T>)TrainingInformationManagementMaster;
                    break;
                case PromotionManagement _:
                    repository = (IBaseRepository<T>)PromotionManagement;
                    break;

                case EmployeeInformationCount _:
                    repository = (IBaseRepository<T>)EmployeeInformationCount;
                    break;
                case Organogram _:
                    repository = (IBaseRepository<T>)Organogram;
                    break;
                case DisciplinaryHistory _:
                    repository = (IBaseRepository<T>)DisciplinaryHistoryRepository;
                    break;
                case PRL _:
                    repository = (IBaseRepository<T>)PRLRepository;
                    break;

                case UniversityInformation _:
                    repository = (IBaseRepository<T>)UniversityInformationRepository;
                    break;

                case Union _:
                    repository = (IBaseRepository<T>)UnionRepository;
                    break;

                case TrainingPlan _:
                    repository = (IBaseRepository<T>)TrainingPlanRepository;
                    break;
                case OtherTrainingMember _:
                    repository = (IBaseRepository<T>)OtherTrainingMemberRepository;
                    break;
                case EmployeePostingDetails _:
                    repository = (IBaseRepository<T>)EmployeePostingDetailsRepository;
                    break;

            }
            return repository;
        }

        public IBaseRepository<T> Select<T>() where T : BaseEntity
        {
            IBaseRepository<T> repository = default(IBaseRepository<T>);

            Type type = typeof(T);

            if (type == typeof(User))
            {
                repository = (IBaseRepository<T>)users;
            }
            else if (type == typeof(UserGroup))
            {
                repository = (IBaseRepository<T>)usergroups;
            }
            else if (type == typeof(EmployeeStatus))
            {
                repository = (IBaseRepository<T>)EmployeeStatuss;
            }
            else if (type == typeof(Degree))
            {
                repository = (IBaseRepository<T>)Degrees;
            }

            else if (type == typeof(Category))
            {
                repository = (IBaseRepository<T>)Categoriess;
            }
            else if (type == typeof(Designation))
            {
                repository = (IBaseRepository<T>)Designations;
            }
            else if (type == typeof(DesignationClass))
            {
                repository = (IBaseRepository<T>)DesignationClasses;
            }
            else if (type == typeof(Upazilla))
            {
                repository = (IBaseRepository<T>)Upazilla;
            }
            else if (type == typeof(District))
            {
                repository = (IBaseRepository<T>)Districts;
            }
            else if (type == typeof(Division))
            {
                repository = (IBaseRepository<T>)Divisions;
            }
            else if (type == typeof(PoliceStation))
            {
                repository = (IBaseRepository<T>)PoliceStations;
            }
            else if (type == typeof(Posting))
            {
                repository = (IBaseRepository<T>)Postings;
            }
            else if (type == typeof(PostingType))
            {
                repository = (IBaseRepository<T>)PostingTypes;
            }
            else if (type == typeof(PostResponsibility))
            {
                repository = (IBaseRepository<T>)PostResponsibilities;
            }
            else if (type == typeof(PresentStatus))
            {
                repository = (IBaseRepository<T>)PresentStatuses;
            }
            else if (type == typeof(PromtionNature))
            {
                repository = (IBaseRepository<T>)PromtionNatures;
            }
            else if (type == typeof(Rank))
            {
                repository = (IBaseRepository<T>)Ranks;
            }

            else if (type == typeof(Color))
            {
                repository = (IBaseRepository<T>)Color;
            }
            else if (type == typeof(PayScaleYearInfo))
            {
                repository = (IBaseRepository<T>)PayScaleYearInfo;
            }

            else if (type == typeof(TrainingInformation))
            {
                repository = (IBaseRepository<T>)TrainingInformation;
            }
            else if (type == typeof(SpouseInformation))
            {
                repository = (IBaseRepository<T>)SpouseInformation;
            }
            else if (type == typeof(ServiceHistory))
            {
                repository = (IBaseRepository<T>)ServiceHistory;
            }
            else if (type == typeof(UserRoles))
            {
                repository = (IBaseRepository<T>)UserRoles;
            }
            else if (type == typeof(Accesslist))
            {
                repository = (IBaseRepository<T>)Accesslist;
            }
            else if (type == typeof(AccessMapper))
            {
                repository = (IBaseRepository<T>)AccessMapper;
            }
            else if (type == typeof(Common.Entity.Module))
            {
                repository = (IBaseRepository<T>)Module;
            }
            else if (type == typeof(PmsGroup))
            {
                repository = (IBaseRepository<T>)PmsGroup;
            }
            else if (type == typeof(EmployeeInformation))
            {
                repository = (IBaseRepository<T>)EmployeeInformation;
            }
            else if (type == typeof(ChildrenInformation))
            {
                repository = (IBaseRepository<T>)ChildrenInformation;
            }

            else if (type == typeof(PresentAddress))
            {
                repository = (IBaseRepository<T>)PresentAddress;
            }
            else if (type == typeof(PermanentAddress))
            {
                repository = (IBaseRepository<T>)PermanentAddress;
            }
            else if (type == typeof(DisciplinaryActionsAndCriminalProsecution))
            {
                repository = (IBaseRepository<T>)DisciplinaryActionsAndCriminalProsecution;
            }
            else if (type == typeof(EducationalQualification))
            {
                repository = (IBaseRepository<T>)EducationalQualification;
            }
            else if (type == typeof(EmployeeTransfer))
            {
                repository = (IBaseRepository<T>)EmployeeTransfer;
            }
            else if (type == typeof(OfficialInformation))
            {
                repository = (IBaseRepository<T>)OfficialInformation;
            }
            else if (type == typeof(PostingRecords))
            {
                repository = (IBaseRepository<T>)PostingRecords;
            }
            else if (type == typeof(PromotionPartculars))
            {
                repository = (IBaseRepository<T>)PromotionPartculars;
            }
            else if (type == typeof(GradationType))
            {
                repository = (IBaseRepository<T>)GradationType;
            }
            else if (type == typeof(EmployeeType))
            {
                repository = (IBaseRepository<T>)EmployeeType;
            }
            else if (type == typeof(JobCategory))
            {
                repository = (IBaseRepository<T>)JobCategory;
            }
            else if (type == typeof(Routes))
            {
                repository = (IBaseRepository<T>)Routes;
            }
            else if (type == typeof(RoutesDetails))
            {
                repository = (IBaseRepository<T>)RoutesDetails;
            }
            else if (type == typeof(RoutesLineStringJsons))
            {
                repository = (IBaseRepository<T>)RoutesLineStringJsons;
            }
            else if (type == typeof(Language))
            {
                repository = (IBaseRepository<T>)Language;
            }
            else if (type == typeof(LanguageInformation))
            {
                repository = (IBaseRepository<T>)LanguageInformation;
            }
            else if (type == typeof(Years))
            {
                repository = (IBaseRepository<T>)Years;
            }
            else if (type == typeof(SpecialHolydaySetup))
            {
                repository = (IBaseRepository<T>)SpecialHoliday;
            }
            else if (type == typeof(WeeklyHolydaySetup))
            {
                repository = (IBaseRepository<T>)WeeklyHoliday;
            }
            else if (type == typeof(CalculationMethod))
            {
                repository = (IBaseRepository<T>)CalculationMethod;
            }
            else if (type == typeof(LeaveTypeInformation))
            {
                repository = (IBaseRepository<T>)LeaveTypeInformation;
            }
            else if (type == typeof(LeaveApplication))
            {
                repository = (IBaseRepository<T>)LeaveApplication;
            }
            else if (type == typeof(TrainingManagementType))
            {
                repository = (IBaseRepository<T>)TrainingManagementType;
            }
            else if (type == typeof(TrainingInformationManagement))
            {
                repository = (IBaseRepository<T>)TrainingInformationManagement;
            }
            else if (type == typeof(TrainingInformationManagementMaster))
            {
                repository = (IBaseRepository<T>)TrainingInformationManagementMaster;
            }
            else if (type == typeof(PromotionManagement))
            {
                repository = (IBaseRepository<T>)PromotionManagement;
            }
            else if (type == typeof(EmployeeInformationCount))
            {
                repository = (IBaseRepository<T>)EmployeeInformationCount;
            }
            else if (type == typeof(Organogram))
            {
                repository = (IBaseRepository<T>)Organogram;
            }
            else if (type == typeof(DisciplinaryHistory))
            {
                repository = (IBaseRepository<T>)DisciplinaryHistoryRepository;
            }
            else if (type == typeof(PRL))
            {
                repository = (IBaseRepository<T>)PRLRepository;
            }
            else if (type == typeof(UniversityInformation))
            {
                repository = (IBaseRepository<T>)UniversityInformationRepository;
            }
            else if (type == typeof(Union))
            {
                repository = (IBaseRepository<T>)UnionRepository;
            }
            else if (type == typeof(TrainingPlan))
            {
                repository = (IBaseRepository<T>)TrainingPlanRepository;
            }
            else if (type == typeof(OtherTrainingMember))
            {
                repository = (IBaseRepository<T>)OtherTrainingMemberRepository;
            }
            else if (type == typeof(EmployeePostingDetails))
            {
                repository = (IBaseRepository<T>)EmployeePostingDetailsRepository;
            }

            return repository;
        }

        public virtual async Task<(ExecutionState executionState, string message)> SaveAsync(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                {
                    try
                    {
                        await WriteOnlyCtx.SaveChangesAsync();
                        return (executionState: ExecutionState.Success, message: "Transaction completed.");
                    }
                    catch (Exception ex)
                    {
                        return (executionState: ExecutionState.Failure, message: ex.Message);
                    }
                }
                else
                {
                    return (executionState: ExecutionState.Failure, message: "Transaction not found.");
                }
            }
            else
            {
                return (executionState: ExecutionState.Failure, message: "Transaction not found.");
            }
        }
        public async Task<(ExecutionState executionState, T entity, string message)> CreateAsync<T>(T entity) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select(entity);

            (ExecutionState executionState, T entity, string message) createdEntity = await repository.CreateAsync(entity);

            return createdEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) retrievedEntity = await repository.GetAsync(id);
            return retrievedEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select(entity);
            (ExecutionState executionState, T entity, string message) updateEntity = await repository.UpdateAsync(entity);
            return updateEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> RemoveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) removeEntity = await repository.RemoveAsync(id);
            return removeEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>
            (FilterOptions<T> filterOptions, RetrievalPurpose retrievalPurpose = RetrievalPurpose.Consumption)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState retrievedEntityExecutionState, T retrievedEntity, string retrievedEntityMessage) =
                await repository.GetAsync(filterOptions, retrievalPurpose);

            return (executionState: retrievedEntityExecutionState, entity: retrievedEntity, message: retrievedEntityMessage);
        }
        public async Task<(ExecutionState executionState, IQueryable<T> entity, string message)> List<T>(QueryOptions<T> queryOptions = null) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState retrievedEntitiesExecutionState, IQueryable<T> retrievedEntities, string retrievedEntitiesMessage) =
                await repository.List(queryOptions);

            return (executionState: retrievedEntitiesExecutionState, entity: retrievedEntities, message: retrievedEntitiesMessage);
        }
        public async Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(FilterOptions<T> filterOptions)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState entitityExistsExecutionState, string entitityExistsMessage) =
                await repository.DoesExistAsync(filterOptions);

            return (executionState: entitityExistsExecutionState, message: entitityExistsMessage);
        }
        public async Task<(ExecutionState executionState, long entityCount, string message)> CountAsync<T>(CountOptions<T> countOptions = null)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState entitiesCountExecutionState, long entitiesCount, string entityCountMessage) =
                await repository.CountAsync(countOptions);

            return (executionState: entitiesCountExecutionState, entityCount: entitiesCount, message: entityCountMessage);
        }
        public async Task<(ExecutionState executionState, T entity, string message)> MarkAsActiveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) activeEntity = await repository.MarkAsActiveAsync(id);
            return activeEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> MarkAsInactiveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) inactiveEntity = await repository.MarkAsInactiveAsync(id);
            return inactiveEntity;
        }
        public async Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, string message) doesExist = await repository.DoesExistAsync(id);
            return doesExist;
        }

        #endregion

        public void Dispose()
        {
            WriteOnlyCtx?.Dispose();
            ReadOnlyCtx?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
