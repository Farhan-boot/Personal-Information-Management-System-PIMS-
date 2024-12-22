using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class ServiceHistoryVM : BaseModel
    {
        public Nullable<DateTime> DateOfGovtService { get; set; }
        public Nullable<DateTime> DateOfGazetted { get; set; }
        [MaxLength(100)]
        public string EncadrementNumber { get; set; }
        public Nullable<DateTime> EncadrementDate { get; set; }
        [MaxLength(100)]
        public string NationalSeniority { get; set; }
        //public long CadreId { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public Cadre? CadreId { get; set; }
    }
}
