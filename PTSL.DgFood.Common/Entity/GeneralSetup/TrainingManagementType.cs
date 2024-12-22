using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class TrainingManagementType : BaseEntity
    {
        public IList<OtherTrainingMember> OtherTrainingMembers { get; set; }

        public TrainingLocationType? TrainingLocationType { get; set; }
        public TrainingManagementTypeLocalType? TrainingManagementTypeLocalType { get; set; }
        public TrainingManagementTypeForeignType? TrainingManagementTypeForeignType { get; set; }

        // Local Location
        public long? DivisionId { get; set; }
        public Division Division { get; set; }
        public long? DistrictId { get; set; }
        public District District { get; set; }
        public long? UpazillaId { get; set; }
        public Upazilla Upazilla { get; set; }

        // Foreign Location
        public List<CountryTrainingManagementTypeMap> CountryTrainingManagementTypeMaps { get; set; }

        public string TrainingTitle { get; set; }
        public string TrainingBatch { get; set; }
        public string TrainingSubject { get; set; }
        public string TrainingObjective { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Vanue { get; set; }

        public int DurationHour { get; set; }

        public string Institute { get; set; }
        public string SuggestedBy { get; set; }
        public string Remarks { get; set; }
        //public long EmployeeInformationId { get; set; } 
        public IList<TrainingInformationManagementMaster> TrainingInformationManagementMasterLists { get; set; }

        //Add New
        public string TrainingPlan { get; set; }
        public TrainingPlanType TrainingPlanType { get; set; }
        public long? TrainingPlanId { get; set; }
        public SpecialTrainingType SpecialTrainingType { get; set; }

    }
}
