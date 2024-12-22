using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class InstituteVM : BaseModel
    {
        [MaxLength(250)]
        public string InstituteName { get; set; }
    } 
}
