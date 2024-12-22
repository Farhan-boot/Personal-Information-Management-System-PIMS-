using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PresentAddressListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string AddressInBangla { get; set; }
        public string AddressInEnglish { get; set; }
        public string PostOfficeInBangla { get; set; }
        public string PostOfficeInEnglish { get; set; }
    }
}
