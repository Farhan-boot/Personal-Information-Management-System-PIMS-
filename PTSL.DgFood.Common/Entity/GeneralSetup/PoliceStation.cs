
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PoliceStation : BaseEntity
    {
        public string PoliceStationName { get; set; }
        public string PoliceStationNameBangla { get; set; }
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
        public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<PermanentAddress> PermanentAddresses { get; set; }
        public IList<PresentAddress> PresentAddresses { get; set; }
    }
}
