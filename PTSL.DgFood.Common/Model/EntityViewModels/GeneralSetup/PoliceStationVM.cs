using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PoliceStationVM : BaseModel
    {
        public string PoliceStationName { get; set; }
        public string PoliceStationNameBangla { get; set; }
        public long DistrictId { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        public IList<EmployeeInformationVM> EmployeeInformationList { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
    }
}
