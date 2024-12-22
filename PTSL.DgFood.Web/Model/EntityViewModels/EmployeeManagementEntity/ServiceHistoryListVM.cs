using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class ServiceHistoryListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public DateTime? DateOfGovtService {get;set;}
        public DateTime? DateOfGazatted {get;set;}
        public string EncadrementNumber { get; set; }
        public DateTime? EncadrementDate {get; set;}
    }
}
