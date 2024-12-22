using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PostingVM : BaseModel
    {
        [MaxLength(100)]
        public string PostingName { get; set; }
        [MaxLength(100)]
        public string PostingNameBangla { get; set; }
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? ThanaId { get; set; }
        public long PostingTypeId { get; set; }
        public virtual PostingTypeVM PostingTypeDTO { get; set; }
    }
}
