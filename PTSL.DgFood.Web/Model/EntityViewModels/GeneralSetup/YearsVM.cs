using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class YearsVM : BaseModel
    {
        //[MaxLength(4)]
        public int YearsName { get; set; }
        public int? YearsNameBn { get; set; }
        //public DisciplinaryActionsAndCriminalProsecution DisciplinaryActionsAndCriminalProsecution { get; set; }
    }
     
}
