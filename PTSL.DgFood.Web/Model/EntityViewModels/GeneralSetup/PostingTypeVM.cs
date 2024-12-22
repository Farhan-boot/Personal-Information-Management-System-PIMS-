using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PostingTypeVM : BaseModel
    {
        [MaxLength(100)]
        public string PostingTypeName { get; set; }
        [MaxLength(100)]
        public string PostingTypeNameBangla { get; set; }
        public IList<PostingVM> PostingList { get; set; }
    }
}
