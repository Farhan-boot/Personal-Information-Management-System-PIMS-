using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PostingRecordsListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string Rank { get; set; }
        public string Designation { get; set; }
        public string PostResponsibility { get; set; }
        public string PostingName { get; set; }
        public string PostingPlace { get; set; }
        public string Section { get; set; }
        public string CrntDesgName { get; set; }
        public string DepPostingName { get; set; }
        public string AttachSection { get; set; }
        public string WorkingAs { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public long? EmployeeTransferId { get; set; }

    }
}
