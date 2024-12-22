using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class PromotionPartcularsVM : BaseModel
    {
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public DateTime? PromotionDate { get; set; }
        public string GONumber { get; set; }
        public DateTime? GODate { get; set; }
        public string PayScale { get; set; }
        public bool PresentPosting { get; set; }
        public long EmployeeInformationId { get; set; }   
        public long? PromtionNatureId { get; set; }
        public long PayScaleYearInfoId { get; set; }
        public bool PromotionStatus { get; set; }
        public virtual PromtionNatureVM PromtionNatureDTO { get; set; }
        public virtual PayScaleYearInfoVM PayScaleYearInfoDTO { get; set; } 
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual RankVM RankDTO { get; set; }
        public virtual DesignationVM DesignationDTO { get; set; }
    }
}
