using PTSL.DgFood.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class UpazillaVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long DistrictId { get; set; }
        public DistrictVM DistrictVM { get; set; }
        public IList<UnionVM> UnionList { get; set; }

        //Add New
        public string? GeoCode { get; set; }
    }
}
