using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model.CustomModal
{
    public class TrainingImplementationReportVM
    {
        public string Grade { get; set; }
        public long? EmployeesNumber { get; set; }
        public double? TotalTrainingHours { get; set; }

       //Month Info
        //Running
        public double? RunningMonthWiseValue { get; set; } = Convert.ToDouble("0");
        public double? RunningAchievementHours { get; set; } = Convert.ToDouble("0");
        public double? RunningAchievementPercentage { get; set; } = Convert.ToDouble("0");

        //Current
        public double? CurrentMonthWiseValue { get; set; } = Convert.ToDouble("0");
        public double? CurrentAchievementHours { get; set; } = Convert.ToDouble("0");
        public double? CurrentAchievementPercentage { get; set; } = Convert.ToDouble("0");

    }
}
