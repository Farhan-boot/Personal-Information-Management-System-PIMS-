using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class ServiceHistoryVM : BaseModel
    {
        public Nullable<DateTime> DateOfGovtService { get; set; }
        public Nullable<DateTime> DateOfGazetted { get; set; }
        public string EncadrementNumber { get; set; }
        public Nullable<DateTime> EncadrementDate { get; set; }
        public string NationalSeniority { get; set; }
        //public long CadreId { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public Enum.Cadre? CadreId { get; set; }
    }
}
