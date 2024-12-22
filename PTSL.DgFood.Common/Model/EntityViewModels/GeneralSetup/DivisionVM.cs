using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class DivisionVM : BaseModel
    {
        public string DivisionName { get; set; }
        public string DivisionNameBangla { get; set; }
        public List<DistrictVM> DistrictList { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
        //public IList<SpouseInformation> SpouseInformation { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }

        //Add New
        public string? GeoCode { get; set; }
    }
}
