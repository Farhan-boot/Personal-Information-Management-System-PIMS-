using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Upazilla : BaseEntity
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long DistrictId { get; set; }
        public District District { get; set; }

        public IList<Union> Unions { get; set; }
        public IList<PresentAddress> PresentAddresses { get; set; }
        public IList<PermanentAddress> PermanentAddresses { get; set; }

        //Add New
        public string? GeoCode { get; set; }

    }
}
