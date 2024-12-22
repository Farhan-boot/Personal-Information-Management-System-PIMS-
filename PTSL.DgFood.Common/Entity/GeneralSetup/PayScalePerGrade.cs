using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PayScalePerGrade : BaseEntity
    { 
        public int ScaleYear { get; set; }
        public string ScaleOfPay { get; set; }
        public decimal basic_pay { get; set; }
        public long RankId { get; set; }
        public Rank Rank { get; set; }
    }
}
