using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
   public class TrainingPlanVM : BaseModel
    {
        //public long? No { get; set; }
        public string? PossibleTrainingWorkshopTopics { get; set; }
        public double? TrainingHours { get; set; }
        public Grade? GradeId { get; set; }
        public long? NumberOfParticipants { get; set; }
        public double? TotalTrainingHours { get; set; }
        public string? InstructorOrConsultant { get; set; }
        public DateTime? ProbableStartDate { get; set; }
        public DateTime? ProbableEndDate { get; set; }
    }
}
