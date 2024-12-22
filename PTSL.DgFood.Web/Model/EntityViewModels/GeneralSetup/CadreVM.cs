using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class CadreVM : BaseModel
    {
        [MaxLength(100)]
        public string CadreNameEnglish { get; set; }
        [MaxLength(100)]
        public string CadreNameBangla { get; set; }
        [MaxLength(100)]
        public string ClassType { get; set; }
    }
 
}
