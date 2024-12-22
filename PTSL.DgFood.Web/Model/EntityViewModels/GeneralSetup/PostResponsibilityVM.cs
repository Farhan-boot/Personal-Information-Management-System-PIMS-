using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PostResponsibilityVM : BaseModel
    {
        [MaxLength(100)]
        public string PostResponsibilityName { get; set; }
        public string PostResponsibilityNameBn { get; set; }
    }
}
