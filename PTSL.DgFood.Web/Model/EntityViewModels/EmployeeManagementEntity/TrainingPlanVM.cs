using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class TrainingPlanVM : BaseModel
    {
        //public long? No { get; set; }
        public string PossibleTrainingWorkshopTopics { get; set; }
        public double? TrainingHours { get; set; }
        public Grade? GradeId { get; set; }
        public long? NumberOfParticipants { get; set; }
        public double? TotalTrainingHours { get; set; }
        public string InstructorOrConsultant { get; set; }
        public DateTime? ProbableStartDate { get; set; }
        public DateTime? ProbableEndDate { get; set; }
        public string GradeName { get; set; }
    }
}
