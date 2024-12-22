using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PromotionPartcularsVM : BaseModel
    {
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public DateTime? PromotionDate { get; set; }
        [MaxLength(100)]
        public string GONumber { get; set; }
        public DateTime? GODate { get; set; }
        [MaxLength(200)]
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
