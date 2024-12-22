using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model
{
    public class LanguageVM : BaseModel
    {
        [MaxLength(100)]
        public string LanguageName { get; set; }
        public string LanguageNameBn { get; set; }
        public IList<LanguageInformationVM> LanguageInformationList { get; set; }
    }
}