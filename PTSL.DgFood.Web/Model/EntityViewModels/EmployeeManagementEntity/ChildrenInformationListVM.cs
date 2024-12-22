using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class ChildrenInformationListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        [MaxLength(100)]
        public string NameInBangla {get;set;}
        [MaxLength(100)]
        public string NameInEnglish { get; set; } 
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
    }
}
