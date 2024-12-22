using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class LanguageVM : BaseModel
    {
        public string LanguageName { get; set; }
        public string LanguageNameBn { get; set; }
        public IList<LanguageInformationVM> LanguageInformationList { get; set; }
    }
}
