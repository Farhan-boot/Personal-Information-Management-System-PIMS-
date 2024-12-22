using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model.CustomModal
{
    public class TrainingMonthlyDetailsReportVM
    {
        public string Grade { get; set; }
        public long? EmployeesNumber { get; set; }
        public double? EmployeesWiseTrainingHours { get; set; }
        public double? TotalTrainingHours { get; set; }

        //Month Name
        public double January { get; set; } = Convert.ToDouble("0");
        public double February { get; set; } = Convert.ToDouble("0");
        public double March { get; set; } = Convert.ToDouble("0");
        public double April { get; set; } = Convert.ToDouble("0");
        public double May { get; set; } = Convert.ToDouble("0");
        public double June { get; set; } = Convert.ToDouble("0");
        public double July { get; set; } = Convert.ToDouble("0");
        public double August { get; set; } = Convert.ToDouble("0");
        public double September { get; set; } = Convert.ToDouble("0");
        public double October { get; set; } = Convert.ToDouble("0");
        public double November { get; set; } = Convert.ToDouble("0");
        public double December { get; set; } = Convert.ToDouble("0");
    }
}
