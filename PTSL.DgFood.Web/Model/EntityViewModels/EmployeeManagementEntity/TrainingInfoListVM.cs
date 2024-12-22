using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class TrainingInfoListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string InstituteName { get; set; }
        public string CourseTitle { get; set; }
        public DateTime PeriodFrom {get;set;}
        public DateTime PeriodTo {get;set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Grade { get; set; }
        public string Position { get; set; }
        public string TrainingType { get; set; }


    }
}
