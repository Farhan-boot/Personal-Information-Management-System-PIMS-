using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class RecruitPromoVM : BaseModel
    {
        [MaxLength(100)]
        public string RecruitPromoEnglish { get; set; }
        [MaxLength(100)]
        public string RecruitPromoBangla { get; set; }
        public virtual IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}
