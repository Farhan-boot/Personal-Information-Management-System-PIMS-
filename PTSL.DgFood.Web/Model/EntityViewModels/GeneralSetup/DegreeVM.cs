using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class DegreeVM : BaseModel
    {
        [MaxLength(100)]
        public string DegreeName { get; set; }
        public string DegreeNameBn { get; set; }
    }
}
