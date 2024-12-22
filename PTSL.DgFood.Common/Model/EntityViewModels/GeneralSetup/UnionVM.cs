using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class UnionVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM Upazilla { get; set; }

        //Add New
        public string? GeoCode { get; set; }
    }
}
