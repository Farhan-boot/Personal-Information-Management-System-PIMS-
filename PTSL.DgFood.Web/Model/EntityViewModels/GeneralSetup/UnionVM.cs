namespace PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup
{
    public class UnionVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long UpazillaId { get; set; }
        public UpazillaVM Upazilla { get; set; }

        //Add New
        public string GeoCode { get; set; }
    }
}
