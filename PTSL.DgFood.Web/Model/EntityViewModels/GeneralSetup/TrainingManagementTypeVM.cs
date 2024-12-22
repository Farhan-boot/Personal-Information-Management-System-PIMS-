using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class TrainingManagementTypeVM : BaseModel
    {
        public IList<OtherTrainingMemberVM> OtherTrainingMembers { get; set; }
        public TrainingLocationType? TrainingLocationType { get; set; }
        public TrainingManagementTypeLocalType? TrainingManagementTypeLocalType { get; set; }
        public TrainingManagementTypeForeignType? TrainingManagementTypeForeignType { get; set; }

        // Local Location
        public long? DivisionId { get; set; }
        public DivisionVM Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM Upazilla { get; set; }

        // Foreign Location
        public List<CountryTrainingManagementTypeMapVM> CountryTrainingManagementTypeMaps { get; set; }

        [MaxLength(500)]
        public string TrainingTitle { get; set; }
        [MaxLength(200)]
        public string TrainingBatch { get; set; }
        [MaxLength(500)]
        public string TrainingSubject { get; set; }
        public string TrainingObjective { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Vanue { get; set; }

        public int DurationHour { get; set; }

        public TrainingManagementTypeStatus TrainingManagementTypeStatusEnum { get; set; }

        public string Institute { get; set; }
        public string SuggestedBy { get; set; }
        public string Remarks { get; set; }
        //public long EmployeeInformationId { get; set; } 
        public IList<TrainingInformationManagementMasterVM> TrainingInformationManagementMasterLists { get; set; } = new List<TrainingInformationManagementMasterVM>();

        //Add New
        public string TrainingPlan { get; set; }
        public TrainingPlanType TrainingPlanType { get; set; }
        //For Display
        public string TrainingPlanTypeName { get; set; }
        public long? TrainingPlanId { get; set; }
        public SpecialTrainingType SpecialTrainingType { get; set; }
    }
}
