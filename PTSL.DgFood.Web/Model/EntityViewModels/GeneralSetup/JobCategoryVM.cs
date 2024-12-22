using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class JobCategoryVM : BaseModel
    {
        [MaxLength(100)]
        public string JobCategoryName { get; set; }
        public string JobCategoryNameBn { get; set; }
        public IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }

    
}
