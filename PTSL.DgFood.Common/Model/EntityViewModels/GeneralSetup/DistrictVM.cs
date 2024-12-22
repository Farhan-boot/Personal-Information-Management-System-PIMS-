using PTSL.DgFood.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class DistrictVM : BaseModel
    {
        public string DistrictName { get; set; }
        public string DistrictNameBangla { get; set; }
        public long DivisionId { get; set; }
        public DivisionVM DivisionDTO { get; set; }
        public IList<PoliceStationVM> PoliceStationList { get; set; }
        public IList<UpazillaVM> UpazillaList { get; set; }
        //public IList<PermanentAddressVM> PermanentAddresses { get; set; }
        //public IList<PresentAddressVM> PresentAddresses { get; set; }
        //public IList<SpouseInformationVM> SpouseInformation { get; set; }
        //public IList<EmployeeInformationVM> EmployeeInformation { get; set; }

        //public string DistrictName { get; set; }
        //public long DivisionId { get; set; }
        //public virtual Division Division { get; set; }
        //public IList<PoliceStation> PoliceStations { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
        //public IList<SpouseInformation> SpouseInformation { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }

        //Add New
        public string? GeoCode { get; set; }
    }
}
