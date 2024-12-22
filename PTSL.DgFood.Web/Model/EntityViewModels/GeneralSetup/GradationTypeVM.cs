using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class GradationTypeVM : BaseModel
    {
        [MaxLength(100)]
        public string GradationTypeName { get; set; }
        public string GradationTypeNameBn { get; set; }
        public IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}
