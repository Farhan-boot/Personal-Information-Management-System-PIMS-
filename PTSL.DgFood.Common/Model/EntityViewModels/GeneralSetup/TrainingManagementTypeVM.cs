using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class TrainingManagementTypeVM : BaseModel
    {
        [SwaggerExclude]
        public IList<OtherTrainingMemberVM> OtherTrainingMembers { get; set; }

        public TrainingLocationType? TrainingLocationType { get; set; }
        public TrainingManagementTypeLocalType? TrainingManagementTypeLocalType { get; set; }
        public TrainingManagementTypeForeignType? TrainingManagementTypeForeignType { get; set; }

        // Local Location
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM Division { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM District { get; set; }
        public long? UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM Upazilla { get; set; }

        // Foreign Location
        public List<CountryTrainingManagementTypeMapVM> CountryTrainingManagementTypeMaps { get; set; }

        public string TrainingTitle { get; set; }
        public string TrainingBatch { get; set; }
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
        [SwaggerExclude]
        public IList<TrainingInformationManagementMasterVM> TrainingInformationManagementMasterLists { get; set; }

        //Add New
        public string TrainingPlan { get; set; }
        public TrainingPlanType TrainingPlanType { get; set; }
        public long? TrainingPlanId { get; set; }
        public SpecialTrainingType SpecialTrainingType { get; set; }

    }
}
