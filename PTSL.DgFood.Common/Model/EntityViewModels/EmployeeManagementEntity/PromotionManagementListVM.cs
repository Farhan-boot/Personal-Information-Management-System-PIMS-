using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class PromotionManagementListVM
    {
        public long Id { get; set; }
        public long EmployeeInformationId { get; set; }
        public string EmployeeName { get; set; }
        public string Rank { get; set; }
        public string Designation { get; set; }
        public DateTime? PromotionDate { get; set; }
        public DateTime? GODate { get; set; }
        public string NatureOfPromotion { get; set; }
        public string PayScale { get; set; }
    }
}
