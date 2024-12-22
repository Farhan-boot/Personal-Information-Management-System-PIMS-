using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class ServiceHistory : BaseEntity
    {
        public Nullable<DateTime> DateOfGovtService { get; set; }
        public Nullable<DateTime> DateOfGazetted { get; set; }
        public string EncadrementNumber { get; set; }
        public Nullable<DateTime> EncadrementDate { get; set; }
        public string NationalSeniority { get; set; }
        //public long CadreId { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public Enum.Cadre? CadreId { get; set; }
    }
}
