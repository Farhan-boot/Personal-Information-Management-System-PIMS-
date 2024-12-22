using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PayScalePerGradeVM : BaseModel
    {
        public int ScaleYear { get; set; }
        public string ScaleOfPay { get; set; }
        public decimal basic_pay { get; set; }
        public long RankId { get; set; }
        public RankVM RankDTO { get; set; }

    }
}
