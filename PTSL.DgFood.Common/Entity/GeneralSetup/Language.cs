using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Language : BaseEntity
    {
        public string LanguageName { get; set; }
        public string LanguageNameBn { get; set; }
        public IList<LanguageInformation> LanguageInformation { get; set; }
    }
}
