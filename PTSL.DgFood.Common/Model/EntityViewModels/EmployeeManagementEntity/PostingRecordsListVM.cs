using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class PostingRecordsListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string Rank { get; set; }
        public string Designation { get; set; }
        public string PostResponsibility { get; set; }
        public string PostingPlace { get; set; }
        public long? EmployeeTransferId { get; set; }
    }
}
